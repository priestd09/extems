-->-->-- C:/Users/Mohan/Desktop/ExtEMS/db/1.x/1.0/src/00.db core/0.verbosity.sql --<--<--
SET CLIENT_MIN_MESSAGES TO WARNING;


-->-->-- C:/Users/Mohan/Desktop/ExtEMS/db/1.x/1.0/src/00.db core/2.install-unit-test.sql --<--<--
/********************************************************************************
The PostgreSQL License

Copyright (c) 2014, Binod Nepal, Mix Open Foundation (http://mixof.org).

Permission to use, copy, modify, and distribute this software and its documentation 
for any purpose, without fee, and without a written agreement is hereby granted, 
provided that the above copyright notice and this paragraph and 
the following two paragraphs appear in all copies.

IN NO EVENT SHALL MIX OPEN FOUNDATION BE LIABLE TO ANY PARTY FOR DIRECT, INDIRECT, 
SPECIAL, INCIDENTAL, OR CONSEQUENTIAL DAMAGES, INCLUDING LOST PROFITS, 
ARISING OUT OF THE USE OF THIS SOFTWARE AND ITS DOCUMENTATION, EVEN IF 
MIX OPEN FOUNDATION HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

MIX OPEN FOUNDATION SPECIFICALLY DISCLAIMS ANY WARRANTIES, INCLUDING, 
BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
FOR A PARTICULAR PURPOSE. THE SOFTWARE PROVIDED HEREUNDER IS ON AN "AS IS" BASIS, 
AND MIX OPEN FOUNDATION HAS NO OBLIGATIONS TO PROVIDE MAINTENANCE, SUPPORT, 
UPDATES, ENHANCEMENTS, OR MODIFICATIONS.
***********************************************************************************/

DROP SCHEMA IF EXISTS assert CASCADE;
DROP SCHEMA IF EXISTS unit_tests CASCADE;
DROP DOMAIN IF EXISTS public.test_result CASCADE;

CREATE SCHEMA assert AUTHORIZATION postgres;
CREATE SCHEMA unit_tests AUTHORIZATION postgres;
CREATE DOMAIN public.test_result AS text;

CREATE TABLE unit_tests.tests
(
    test_id                                 SERIAL NOT NULL PRIMARY KEY,
    started_on                              TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'),
    completed_on                            TIMESTAMP WITHOUT TIME ZONE NULL,
    total_tests                             integer NULL DEFAULT(0),
    failed_tests                            integer NULL DEFAULT(0)
);

CREATE INDEX unit_tests_tests_started_on_inx
ON unit_tests.tests(started_on);

CREATE INDEX unit_tests_tests_completed_on_inx
ON unit_tests.tests(completed_on);

CREATE INDEX unit_tests_tests_failed_tests_inx
ON unit_tests.tests(failed_tests);

CREATE TABLE unit_tests.test_details
(
    id                                      BIGSERIAL NOT NULL PRIMARY KEY,
    test_id                                 integer NOT NULL REFERENCES unit_tests.tests(test_id),
    function_name                           text NOT NULL,
    message                                 text NOT NULL,
    ts                                      TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'),
    status                                  boolean NOT NULL
);

CREATE INDEX unit_tests_test_details_test_id_inx
ON unit_tests.test_details(test_id);

CREATE INDEX unit_tests_test_details_status_inx
ON unit_tests.test_details(status);

CREATE FUNCTION assert.fail(message text)
RETURNS text
AS
$$
BEGIN
    IF $1 IS NULL OR trim($1) = '' THEN
        message := 'NO REASON SPECIFIED';
    END IF;
    
    RAISE WARNING 'ASSERT FAILED : %', message;
    RETURN message;
END
$$
LANGUAGE plpgsql
IMMUTABLE STRICT;

CREATE FUNCTION assert.pass(message text)
RETURNS text
AS
$$
BEGIN
    RAISE NOTICE 'ASSERT PASSED : %', message;
    RETURN '';
END
$$
LANGUAGE plpgsql
IMMUTABLE STRICT;

CREATE FUNCTION assert.ok(message text)
RETURNS text
AS
$$
BEGIN
    RAISE NOTICE 'OK : %', message;
    RETURN '';
END
$$
LANGUAGE plpgsql
IMMUTABLE STRICT;

CREATE FUNCTION assert.is_equal(IN have anyelement, IN want anyelement, OUT message text, OUT result boolean)
AS
$$
BEGIN
    IF($1 = $2) THEN
        message := 'Assert is equal.';
        PERFORM assert.ok(message);
        result := true;
        RETURN;
    END IF;

    message := E'ASSERT IS_EQUAL FAILED.\n\nHave -> ' || $1::text || E'\nWant -> ' || $2::text || E'\n';    
    PERFORM assert.fail(message);
    result := false;
    RETURN;
END
$$
LANGUAGE plpgsql
IMMUTABLE STRICT;


CREATE FUNCTION assert.are_equal(VARIADIC anyarray, OUT message text, OUT result boolean)
AS
$$
    DECLARE count integer=0;
BEGIN
    SELECT COUNT(DISTINCT $1[s.i]) INTO count
    FROM generate_series(array_lower($1,1), array_upper($1,1)) AS s(i)
    ORDER BY 1;

    IF count <> 1 THEN
        MESSAGE := 'ASSERT ARE_EQUAL FAILED.';  
        PERFORM assert.fail(MESSAGE);
        RESULT := FALSE;
        RETURN;
    END IF;

    message := 'Asserts are equal.';
    PERFORM assert.ok(message);
    result := true;
    RETURN;
END
$$
LANGUAGE plpgsql
IMMUTABLE STRICT;

CREATE FUNCTION assert.is_not_equal(IN already_have anyelement, IN dont_want anyelement, OUT message text, OUT result boolean)
AS
$$
BEGIN
    IF($1 != $2) THEN
        message := 'Assert is not equal.';
        PERFORM assert.ok(message);
        result := true;
        RETURN;
    END IF;
    
    message := E'ASSERT IS_NOT_EQUAL FAILED.\n\nAlready Have -> ' || $1::text || E'\nDon''t Want   -> ' || $2::text || E'\n';   
    PERFORM assert.fail(message);
    result := false;
    RETURN;
END
$$
LANGUAGE plpgsql
IMMUTABLE STRICT;

CREATE FUNCTION assert.are_not_equal(VARIADIC anyarray, OUT message text, OUT result boolean)
AS
$$
    DECLARE count integer=0;
BEGIN
    SELECT COUNT(DISTINCT $1[s.i]) INTO count
    FROM generate_series(array_lower($1,1), array_upper($1,1)) AS s(i)
    ORDER BY 1;

    IF count <> array_upper($1,1) THEN
        MESSAGE := 'ASSERT ARE_NOT_EQUAL FAILED.';  
        PERFORM assert.fail(MESSAGE);
        RESULT := FALSE;
        RETURN;
    END IF;

    message := 'Asserts are not equal.';
    PERFORM assert.ok(message);
    result := true;
    RETURN;
END
$$
LANGUAGE plpgsql
IMMUTABLE STRICT;


CREATE FUNCTION assert.is_null(IN anyelement, OUT message text, OUT result boolean)
AS
$$
BEGIN
    IF($1 IS NULL) THEN
        message := 'Assert is NULL.';
        PERFORM assert.ok(message);
        result := true;
        RETURN;
    END IF;
    
    message := E'ASSERT IS_NULL FAILED. NULL value was expected.\n\n\n';    
    PERFORM assert.fail(message);
    result := false;
    RETURN;
END
$$
LANGUAGE plpgsql
IMMUTABLE STRICT;


CREATE FUNCTION assert.is_not_null(IN anyelement, OUT message text, OUT result boolean)
AS
$$
BEGIN
    IF($1 IS NOT NULL) THEN
        message := 'Assert is not NULL.';
        PERFORM assert.ok(message);
        result := true;
        RETURN;
    END IF;
    
    message := E'ASSERT IS_NOT_NULL FAILED. The value is NULL.\n\n\n';  
    PERFORM assert.fail(message);
    result := false;
    RETURN;
END
$$
LANGUAGE plpgsql
IMMUTABLE STRICT;


CREATE FUNCTION assert.is_true(IN boolean, OUT message text, OUT result boolean)
AS
$$
BEGIN
    IF($1 == true) THEN
        message := 'Assert is true.';
        PERFORM assert.ok(message);
        result := true;
        RETURN;
    END IF;
    
    message := E'ASSERT IS_TRUE FAILED. A true condition was expected.\n\n\n';  
    PERFORM assert.fail(message);
    result := false;
    RETURN;
END
$$
LANGUAGE plpgsql
IMMUTABLE STRICT;


CREATE FUNCTION assert.is_false(IN boolean, OUT message text, OUT result boolean)
AS
$$
BEGIN
    IF($1 == true) THEN
        message := 'Assert is false.';
        PERFORM assert.ok(message);
        result := true;
        RETURN;
    END IF;
    
    message := E'ASSERT IS_FALSE FAILED. A false condition was expected.\n\n\n';    
    PERFORM assert.fail(message);
    result := false;
    RETURN;
END
$$
LANGUAGE plpgsql
IMMUTABLE STRICT;


CREATE FUNCTION assert.is_greater_than(IN x anyelement, IN y anyelement, OUT message text, OUT result boolean)
AS
$$
BEGIN
    IF($1 > $2) THEN
        message := 'Assert greater than condition is satisfied.';
        PERFORM assert.ok(message);
        result := true;
        RETURN;
    END IF;
    
    message := E'ASSERT IS_GREATER_THAN FAILED.\n\n X : -> ' || $1::text || E'\n is not greater than Y:   -> ' || $2::text || E'\n';    
    PERFORM assert.fail(message);
    result := false;
    RETURN;
END
$$
LANGUAGE plpgsql
IMMUTABLE STRICT;


CREATE FUNCTION assert.is_less_than(IN x anyelement, IN y anyelement, OUT message text, OUT result boolean)
AS
$$
BEGIN
    IF($1 < $2) THEN
        message := 'Assert less than condition is satisfied.';
        PERFORM assert.ok(message);
        result := true;
        RETURN;
    END IF;
    
    message := E'ASSERT IS_LESS_THAN FAILED.\n\n X : -> ' || $1::text || E'\n is not  than Y:   -> ' || $2::text || E'\n';  
    PERFORM assert.fail(message);
    result := false;
    RETURN;
END
$$
LANGUAGE plpgsql
IMMUTABLE STRICT;


CREATE FUNCTION assert.function_exists(function_name text, OUT message text, OUT result boolean)
AS
$$
BEGIN
    IF NOT EXISTS
    (
        SELECT  1
        FROM    pg_catalog.pg_namespace n
        JOIN    pg_catalog.pg_proc p
        ON      pronamespace = n.oid
        WHERE replace(nspname || '.' || proname || '(' || oidvectortypes(proargtypes) || ')', ' ' , '')::text=$1
    ) THEN
        message := 'The function % does not exist.', $1;
        PERFORM assert.fail(message);

        result := false;
        RETURN;
    END IF;

    message := 'OK. The function ' || $1 || ' exists.';
    PERFORM assert.ok(message);
    result := true;
    RETURN;
END
$$
LANGUAGE plpgsql;



DROP FUNCTION IF EXISTS assert.if_functions_compile
(
    VARIADIC _schema_name text[],
    OUT message text, 
    OUT result boolean    
);

CREATE OR REPLACE FUNCTION assert.if_functions_compile
(
    VARIADIC _schema_name text[],
    OUT message text, 
    OUT result boolean
)
AS
$$
    DECLARE all_parameters              text;
    DECLARE current_function            RECORD;
    DECLARE current_function_name       text;
    DECLARE current_type                text;
    DECLARE current_type_schema         text;
    DECLARE current_parameter           text;
    DECLARE functions_count             smallint := 0;
    DECLARE current_parameters_count    int;
    DECLARE i                           int;
    DECLARE command_text                text;
    DECLARE failed_functions            text;
BEGIN
    FOR current_function IN 
        SELECT proname, proargtypes, nspname 
        FROM pg_proc 
        INNER JOIN pg_namespace 
        ON pg_proc.pronamespace = pg_namespace.oid 
        WHERE pronamespace IN 
        (
            SELECT oid FROM pg_namespace 
            WHERE nspname = ANY($1) 
            AND nspname NOT IN
            (
                'assert', 'unit_tests', 'information_schema'
            ) 
            AND proname NOT IN('if_functions_compile')
        ) 
    LOOP
        current_parameters_count := array_upper(current_function.proargtypes, 1) + 1;

        i := 0;
        all_parameters := '';

        LOOP
        IF i < current_parameters_count THEN
            IF i > 0 THEN
                all_parameters := all_parameters || ', ';
            END IF;

            SELECT 
                nspname, typname 
            INTO 
                current_type_schema, current_type 
            FROM pg_type 
            INNER JOIN pg_namespace 
            ON pg_type.typnamespace = pg_namespace.oid
            WHERE pg_type.oid = current_function.proargtypes[i];

            IF(current_type IN('int4', 'int8', 'numeric', 'integer_strict', 'money_strict','decimal_strict', 'integer_strict2', 'money_strict2','decimal_strict2', 'money','decimal', 'numeric', 'bigint')) THEN
                current_parameter := '1::' || current_type_schema || '.' || current_type;
            ELSIF(substring(current_type, 1, 1) = '_') THEN
                current_parameter := 'NULL::' || current_type_schema || '.' || substring(current_type, 2, length(current_type)) || '[]';
            ELSIF(current_type in ('date')) THEN            
                current_parameter := '''1-1-2000''::' || current_type;
            ELSIF(current_type = 'bool') THEN
                current_parameter := 'false';            
            ELSE
                current_parameter := '''''::' || quote_ident(current_type_schema) || '.' || quote_ident(current_type);
            END IF;
            
            all_parameters = all_parameters || current_parameter;

            i := i + 1;
        ELSE
            EXIT;
        END IF;
    END LOOP;

    BEGIN
        current_function_name := quote_ident(current_function.nspname)  || '.' || quote_ident(current_function.proname);
        command_text := 'SELECT * FROM ' || current_function_name || '(' || all_parameters || ');';

        EXECUTE command_text;
        functions_count := functions_count + 1;

        EXCEPTION WHEN OTHERS THEN
            IF(failed_functions IS NULL) THEN 
                failed_functions := '';
            END IF;

            IF(SQLSTATE IN('42702', '42704')) THEN
                failed_functions := failed_functions || E'\n' || command_text || E'\n' || SQLERRM || E'\n';                
            END IF;
    END;


    END LOOP;

    IF(failed_functions != '') THEN
        message := E'The test if_functions_compile failed. The following functions failed to compile : \n\n' || failed_functions;
        result := false;
        PERFORM assert.fail(message);
        RETURN;
    END IF;
END;
$$
LANGUAGE plpgsql 
VOLATILE;

DROP FUNCTION IF EXISTS assert.if_views_compile
(
    VARIADIC _schema_name text[],
    OUT message text, 
    OUT result boolean    
);

CREATE FUNCTION assert.if_views_compile
(
    VARIADIC _schema_name text[],
    OUT message text, 
    OUT result boolean    
)
AS
$$

    DECLARE message                     test_result;
    DECLARE current_view                RECORD;
    DECLARE current_view_name           text;
    DECLARE command_text                text;
    DECLARE failed_views                text;
BEGIN
    FOR current_view IN 
        SELECT table_name, table_schema 
        FROM information_schema.views
        WHERE table_schema = ANY($1) 
    LOOP

    BEGIN
        current_view_name := quote_ident(current_view.table_schema)  || '.' || quote_ident(current_view.table_name);
        command_text := 'SELECT * FROM ' || current_view_name || ' LIMIT 1;';

        RAISE NOTICE '%', command_text;
        
        EXECUTE command_text;

        EXCEPTION WHEN OTHERS THEN
            IF(failed_views IS NULL) THEN 
                failed_views := '';
            END IF;

            failed_views := failed_views || E'\n' || command_text || E'\n' || SQLERRM || E'\n';                
    END;


    END LOOP;

    IF(failed_views != '') THEN
        message := E'The test if_views_compile failed. The following views failed to compile : \n\n' || failed_views;
        result := false;
        PERFORM assert.fail(message);
        RETURN;
    END IF;

    RETURN;
END;
$$
LANGUAGE plpgsql 
VOLATILE;

CREATE FUNCTION unit_tests.begin(v int DEFAULT 9)
RETURNS TABLE(message text, result character(1))
AS
$$
    DECLARE this record;
    DECLARE _function_name text;
    DECLARE _sql text;
    DECLARE _message text;
    DECLARE _result character(1);
    DECLARE _test_id integer;
    DECLARE _status boolean;
    DECLARE _total_tests integer = 0;
    DECLARE _failed_tests integer = 0;
    DECLARE _list_of_failed_tests text;
    DECLARE _started_from TIMESTAMP WITHOUT TIME ZONE;
    DECLARE _completed_on TIMESTAMP WITHOUT TIME ZONE;
    DECLARE _delta integer;
    DECLARE _ret_val text = '';
    DECLARE _verbosity text[] = ARRAY['debug5', 'debug4', 'debug3', 'debug2', 'debug1', 'log', 'notice', 'warning', 'error', 'fatal', 'panic'];
BEGIN
    _started_from := clock_timestamp() AT TIME ZONE 'UTC';

    RAISE INFO 'Test started from : %', _started_from; 

    IF(v > 10) THEN
        v := 9;
    END IF;
    
    EXECUTE 'SET CLIENT_MIN_MESSAGES TO ' || _verbosity[v];

    RAISE WARNING 'CLIENT_MIN_MESSAGES set to : %' , _verbosity[v];
    

    SELECT nextval('unit_tests.tests_test_id_seq') INTO _test_id;

    INSERT INTO unit_tests.tests(test_id)
    SELECT _test_id;

    FOR this IN
        SELECT proname as function_name
        FROM    pg_catalog.pg_namespace n
        JOIN    pg_catalog.pg_proc p
        ON      pronamespace = n.oid
        WHERE   nspname = 'unit_tests'
        AND prorettype='test_result'::regtype::oid
    LOOP
        BEGIN
            _status := false;
            _total_tests := _total_tests + 1;
            
            _function_name = 'unit_tests.' || this.function_name || '()';
            _sql := 'SELECT ' || _function_name || ';';
            
            RAISE NOTICE 'RUNNING TEST : %.', _function_name;

            EXECUTE _sql INTO _message;

            IF _message = '' THEN
                _status := true;
            END IF;

            
            INSERT INTO unit_tests.test_details(test_id, function_name, message, status)
            SELECT _test_id, _function_name, _message, _status;

            IF NOT _status THEN
                _failed_tests := _failed_tests + 1;         
                RAISE WARNING 'TEST % FAILED.', _function_name;
                RAISE WARNING 'REASON: %', _message;
            ELSE
                RAISE NOTICE 'TEST % COMPLETED WITHOUT ERRORS.', _function_name;
            END IF;

        EXCEPTION WHEN OTHERS THEN
            _message := 'ERR' || SQLSTATE || ': ' || SQLERRM;
            INSERT INTO unit_tests.test_details(test_id, function_name, message, status)
            SELECT _test_id, _function_name, _message, false;

            _failed_tests := _failed_tests + 1;         
            RAISE WARNING 'TEST % FAILED.', _function_name;
            RAISE WARNING 'REASON: %', _message;
        END;
    END LOOP;

    _completed_on := clock_timestamp() AT TIME ZONE 'UTC';
    _delta := extract(millisecond from _completed_on - _started_from)::integer;
    
    UPDATE unit_tests.tests
    SET total_tests = _total_tests, failed_tests = _failed_tests, completed_on = _completed_on
    WHERE test_id = _test_id;

    
    WITH failed_tests AS
    (
        SELECT row_number() over (order by id) AS id, 
        unit_tests.test_details.function_name,
        unit_tests.test_details.message
        FROM unit_tests.test_details 
        WHERE test_id = _test_id
        AND status= false
    )

    SELECT array_to_string(array_agg(f.id::text || '. ' || f.function_name || ' --> ' || f.message), E'\n') INTO _list_of_failed_tests 
    FROM failed_tests f;

    _ret_val := _ret_val ||  'Test completed on : ' || _completed_on::text || E' UTC. \nTotal test runtime: ' || _delta::text || E' ms.\n';
    _ret_val := _ret_val || E'\nTotal tests run : ' || COALESCE(_total_tests, '0')::text;
    _ret_val := _ret_val || E'.\nPassed tests    : ' || (COALESCE(_total_tests, '0') - COALESCE(_failed_tests, '0'))::text;
    _ret_val := _ret_val || E'.\nFailed tests    : ' || COALESCE(_failed_tests, '0')::text;
    _ret_val := _ret_val || E'.\n\nList of failed tests:\n' || '----------------------';
    _ret_val := _ret_val || E'\n' || COALESCE(_list_of_failed_tests, '<NULL>')::text;
    _ret_val := _ret_val || E'\n' || E'End of plpgunit test.\n\n';


    IF _failed_tests > 0 THEN
        _result := 'N';
        RAISE INFO '%', _ret_val;
    ELSE
        _result := 'Y';
        RAISE INFO '%', _ret_val;
    END IF;

    SET CLIENT_MIN_MESSAGES TO notice;

    RETURN QUERY SELECT _ret_val, _result;
END
$$
LANGUAGE plpgsql;




-->-->-- C:/Users/Mohan/Desktop/ExtEMS/db/1.x/1.0/src/00.db core/3.roles-and-priviledge.sql --<--<--

DROP SCHEMA IF EXISTS core      CASCADE;
DROP SCHEMA IF EXISTS auth      CASCADE;
DROP SCHEMA IF EXISTS student   CASCADE;

CREATE SCHEMA core;
COMMENT ON SCHEMA core IS 'Contains objects related to the core module. The core module is the default ExtERP schema.';

CREATE SCHEMA auth;
COMMENT ON SCHEMA auth IS 'Contains objects related to the authorization module.';

CREATE SCHEMA student;
COMMENT ON SCHEMA student IS 'Contains objects related to the student module.';


DO
$$
BEGIN
    IF NOT EXISTS (SELECT * FROM pg_catalog.pg_roles WHERE rolname = 'extems') THEN
        CREATE ROLE extems WITH LOGIN PASSWORD 'change-on-deployment';
    END IF;

    COMMENT ON ROLE extems IS 'The default user for ExtEMS databases.';

    EXECUTE 'ALTER DATABASE ' || current_database() || ' OWNER TO extems;';

    REVOKE ALL ON SCHEMA assert FROM public;
    REVOKE ALL ON SCHEMA auth FROM public;
    REVOKE ALL ON SCHEMA core FROM public;
    REVOKE ALL ON SCHEMA student FROM public;
    REVOKE ALL ON SCHEMA unit_tests FROM public;

        
    GRANT USAGE ON SCHEMA assert TO extems;
    GRANT USAGE ON SCHEMA auth TO extems;
    GRANT USAGE ON SCHEMA core TO extems;
    GRANT USAGE ON SCHEMA information_schema TO extems;
    GRANT USAGE ON SCHEMA public TO extems;
    GRANT USAGE ON SCHEMA student TO extems;
    GRANT USAGE ON SCHEMA unit_tests TO extems;

    ALTER DEFAULT PRIVILEGES IN SCHEMA assert GRANT SELECT, INSERT, UPDATE, DELETE ON TABLES TO extems;
    ALTER DEFAULT PRIVILEGES IN SCHEMA auth GRANT SELECT, INSERT, UPDATE, DELETE ON TABLES TO extems;
    ALTER DEFAULT PRIVILEGES IN SCHEMA core GRANT SELECT, INSERT, UPDATE, DELETE ON TABLES TO extems;
    ALTER DEFAULT PRIVILEGES IN SCHEMA information_schema GRANT SELECT, INSERT, UPDATE, DELETE ON TABLES TO extems;
    ALTER DEFAULT PRIVILEGES IN SCHEMA public GRANT SELECT, INSERT, UPDATE, DELETE ON TABLES TO extems;
    ALTER DEFAULT PRIVILEGES IN SCHEMA student GRANT SELECT, INSERT, UPDATE, DELETE ON TABLES TO extems;
    ALTER DEFAULT PRIVILEGES IN SCHEMA unit_tests GRANT SELECT, INSERT, UPDATE, DELETE ON TABLES TO extems;


    ALTER DEFAULT PRIVILEGES IN SCHEMA assert GRANT ALL ON SEQUENCES TO extems;
    ALTER DEFAULT PRIVILEGES IN SCHEMA auth GRANT ALL ON SEQUENCES TO extems;
    ALTER DEFAULT PRIVILEGES IN SCHEMA core GRANT ALL ON SEQUENCES TO extems;
    ALTER DEFAULT PRIVILEGES IN SCHEMA information_schema GRANT ALL ON SEQUENCES TO extems;
    ALTER DEFAULT PRIVILEGES IN SCHEMA public GRANT ALL ON SEQUENCES TO extems;
    ALTER DEFAULT PRIVILEGES IN SCHEMA student GRANT ALL ON SEQUENCES TO extems;
    ALTER DEFAULT PRIVILEGES IN SCHEMA unit_tests GRANT ALL ON SEQUENCES TO extems;


    ALTER DEFAULT PRIVILEGES IN SCHEMA assert GRANT EXECUTE ON FUNCTIONS TO extems;
    ALTER DEFAULT PRIVILEGES IN SCHEMA auth GRANT EXECUTE ON FUNCTIONS TO extems;
    ALTER DEFAULT PRIVILEGES IN SCHEMA core GRANT EXECUTE ON FUNCTIONS TO extems;
    ALTER DEFAULT PRIVILEGES IN SCHEMA information_schema GRANT EXECUTE ON FUNCTIONS TO extems;
    ALTER DEFAULT PRIVILEGES IN SCHEMA public GRANT EXECUTE ON FUNCTIONS TO extems;
    ALTER DEFAULT PRIVILEGES IN SCHEMA student GRANT EXECUTE ON FUNCTIONS TO extems;
    ALTER DEFAULT PRIVILEGES IN SCHEMA unit_tests GRANT EXECUTE ON FUNCTIONS TO extems;
    
    
    GRANT ALL PRIVILEGES ON SCHEMA unit_tests TO extems;
    GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA unit_tests TO extems;
    GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA unit_tests TO extems;
    GRANT EXECUTE ON ALL FUNCTIONS IN SCHEMA unit_tests TO extems;
END
$$
LANGUAGE plpgsql;




DO
$$
BEGIN
    IF NOT EXISTS (SELECT * FROM pg_catalog.pg_roles WHERE rolname= 'report_user') THEN
        CREATE ROLE report_user WITH LOGIN PASSWORD 'change-on-deployment';
    END IF;

    COMMENT ON ROLE report_user IS 'This user account should be used by the Reporting Engine to run ad-hoc queries.
    It is strictly advised for this user to only have a read-only access to the database.';

    GRANT USAGE ON SCHEMA public TO report_user;
    GRANT USAGE ON SCHEMA information_schema TO report_user;
    GRANT USAGE ON SCHEMA core TO report_user;

    ALTER DEFAULT PRIVILEGES IN SCHEMA public GRANT SELECT ON TABLES TO report_user;
    ALTER DEFAULT PRIVILEGES IN SCHEMA information_schema GRANT SELECT ON TABLES TO report_user;
    ALTER DEFAULT PRIVILEGES IN SCHEMA core GRANT SELECT ON TABLES TO report_user;
    ALTER DEFAULT PRIVILEGES IN SCHEMA student GRANT SELECT ON TABLES TO report_user;


    ALTER DEFAULT PRIVILEGES IN SCHEMA public GRANT EXECUTE ON FUNCTIONS TO report_user;
    ALTER DEFAULT PRIVILEGES IN SCHEMA information_schema GRANT EXECUTE ON FUNCTIONS TO report_user;
    ALTER DEFAULT PRIVILEGES IN SCHEMA core GRANT EXECUTE ON FUNCTIONS TO report_user;
    ALTER DEFAULT PRIVILEGES IN SCHEMA student GRANT EXECUTE ON FUNCTIONS TO report_user;
END
$$
LANGUAGE plpgsql;



-->-->-- C:/Users/Mohan/Desktop/ExtEMS/db/1.x/1.0/src/00.db core/4.casts.sql --<--<--
DROP FUNCTION IF EXISTS pg_catalog.text(unknown) CASCADE;
CREATE FUNCTION pg_catalog.text(unknown) 
RETURNS text 
AS
$$
BEGIN
    RETURN $1::text;
END
$$
LANGUAGE plpgsql; 

CREATE CAST (unknown AS text) WITH FUNCTION pg_catalog.text(unknown) AS IMPLICIT;

DROP FUNCTION IF EXISTS pg_catalog.text(integer) CASCADE;
CREATE FUNCTION pg_catalog.text(integer) RETURNS text STRICT IMMUTABLE LANGUAGE SQL AS 'SELECT textin(int4out($1));';
CREATE CAST (integer AS text) WITH FUNCTION pg_catalog.text(integer) AS IMPLICIT;

DROP FUNCTION IF EXISTS pg_catalog.text(smallint) CASCADE;
CREATE FUNCTION pg_catalog.text(smallint) RETURNS text STRICT IMMUTABLE LANGUAGE SQL AS 'SELECT textin(int2out($1));';
CREATE CAST (smallint AS text) WITH FUNCTION pg_catalog.text(smallint) AS IMPLICIT;

DROP FUNCTION IF EXISTS pg_catalog.text(oid) CASCADE;
CREATE FUNCTION pg_catalog.text(oid) RETURNS text STRICT IMMUTABLE LANGUAGE SQL AS 'SELECT textin(oidout($1));';
CREATE CAST (oid AS text) WITH FUNCTION pg_catalog.text(oid) AS IMPLICIT;

DROP FUNCTION IF EXISTS pg_catalog.text(date) CASCADE;
CREATE FUNCTION pg_catalog.text(date) RETURNS text STRICT IMMUTABLE LANGUAGE SQL AS 'SELECT textin(date_out($1));';
CREATE CAST (date AS text) WITH FUNCTION pg_catalog.text(date) AS IMPLICIT;

DROP FUNCTION IF EXISTS pg_catalog.text(double precision) CASCADE;
CREATE FUNCTION pg_catalog.text(double precision) RETURNS text STRICT IMMUTABLE LANGUAGE SQL AS 'SELECT textin(float8out($1));';
CREATE CAST (double precision AS text) WITH FUNCTION pg_catalog.text(double precision) AS IMPLICIT;

DROP FUNCTION IF EXISTS pg_catalog.text(real) CASCADE;
CREATE FUNCTION pg_catalog.text(real) RETURNS text STRICT IMMUTABLE LANGUAGE SQL AS 'SELECT textin(float4out($1));';
CREATE CAST (real AS text) WITH FUNCTION pg_catalog.text(real) AS IMPLICIT;

DROP FUNCTION IF EXISTS pg_catalog.text(time with time zone) CASCADE;
CREATE FUNCTION pg_catalog.text(time with time zone) RETURNS text STRICT IMMUTABLE LANGUAGE SQL AS 'SELECT textin(timetz_out($1));';
CREATE CAST (time with time zone AS text) WITH FUNCTION pg_catalog.text(time with time zone) AS IMPLICIT;

DROP FUNCTION IF EXISTS pg_catalog.text(time without time zone) CASCADE;
CREATE FUNCTION pg_catalog.text(time without time zone) RETURNS text STRICT IMMUTABLE LANGUAGE SQL AS 'SELECT textin(time_out($1));';
CREATE CAST (time without time zone AS text) WITH FUNCTION pg_catalog.text(time without time zone) AS IMPLICIT;

DROP FUNCTION IF EXISTS pg_catalog.text(timestamp with time zone) CASCADE;
CREATE FUNCTION pg_catalog.text(timestamp with time zone) RETURNS text STRICT IMMUTABLE LANGUAGE SQL AS 'SELECT textin(timestamptz_out($1));';
CREATE CAST (timestamp with time zone AS text) WITH FUNCTION pg_catalog.text(timestamp with time zone) AS IMPLICIT;

DROP FUNCTION IF EXISTS pg_catalog.text(timestamp without time zone) CASCADE;
CREATE FUNCTION pg_catalog.text(timestamp without time zone) RETURNS text STRICT IMMUTABLE LANGUAGE SQL AS 'SELECT textin(timestamp_out($1));';
CREATE CAST (timestamp without time zone AS text) WITH FUNCTION pg_catalog.text(timestamp without time zone) AS IMPLICIT;

DROP FUNCTION IF EXISTS pg_catalog.text(interval) CASCADE;
CREATE FUNCTION pg_catalog.text(interval) RETURNS text STRICT IMMUTABLE LANGUAGE SQL AS 'SELECT textin(interval_out($1));';
CREATE CAST (interval AS text) WITH FUNCTION pg_catalog.text(interval) AS IMPLICIT;

DROP FUNCTION IF EXISTS pg_catalog.text(bigint) CASCADE;
CREATE FUNCTION pg_catalog.text(bigint) RETURNS text STRICT IMMUTABLE LANGUAGE SQL AS 'SELECT textin(int8out($1));';
CREATE CAST (bigint AS text) WITH FUNCTION pg_catalog.text(bigint) AS IMPLICIT;

DROP FUNCTION IF EXISTS pg_catalog.text(numeric) CASCADE;
CREATE FUNCTION pg_catalog.text(numeric) RETURNS text STRICT IMMUTABLE LANGUAGE SQL AS 'SELECT textin(numeric_out($1));';
CREATE CAST (numeric AS text) WITH FUNCTION pg_catalog.text(numeric) AS IMPLICIT;


-->-->-- C:/Users/Mohan/Desktop/ExtEMS/db/1.x/1.0/src/01.types-domains-tables-and-constraints/domains.sql --<--<--
DROP DOMAIN IF EXISTS public.transaction_type CASCADE;
CREATE DOMAIN public.transaction_type
AS char(2)
CHECK
(
    VALUE IN
    (
        'Dr', --Debit
        'Cr' --Credit
    )
);

COMMENT ON DOMAIN public.transaction_type IS 'This domain should not be localized.';


/*******************************************************************
    MIXERP STRICT Data Types: NEGATIVES ARE NOT ALLOWED
*******************************************************************/

DROP DOMAIN IF EXISTS public.money_strict CASCADE;
CREATE DOMAIN public.money_strict
AS DECIMAL(24, 4)
CHECK
(
    VALUE > 0
);


DROP DOMAIN IF EXISTS public.money_strict2 CASCADE;
CREATE DOMAIN public.money_strict2
AS DECIMAL(24, 4)
CHECK
(
    VALUE >= 0
);

DROP DOMAIN IF EXISTS public.integer_strict CASCADE;
CREATE DOMAIN public.integer_strict
AS integer
CHECK
(
    VALUE > 0
);

DROP DOMAIN IF EXISTS public.integer_strict2 CASCADE;
CREATE DOMAIN public.integer_strict2
AS integer
CHECK
(
    VALUE >= 0
);

DROP DOMAIN IF EXISTS public.smallint_strict CASCADE;
CREATE DOMAIN public.smallint_strict
AS smallint
CHECK
(
    VALUE > 0
);

DROP DOMAIN IF EXISTS public.smallint_strict2 CASCADE;
CREATE DOMAIN public.smallint_strict2
AS smallint
CHECK
(
    VALUE >= 0
);

DROP DOMAIN IF EXISTS public.decimal_strict CASCADE;
CREATE DOMAIN public.decimal_strict
AS decimal
CHECK
(
    VALUE > 0
);

DROP DOMAIN IF EXISTS public.decimal_strict2 CASCADE;
CREATE DOMAIN public.decimal_strict2
AS decimal
CHECK
(
    VALUE >= 0
);

DROP DOMAIN IF EXISTS public.color CASCADE;
CREATE DOMAIN public.color
AS text;

DROP DOMAIN IF EXISTS public.image CASCADE;
CREATE DOMAIN public.image
AS text;



-->-->-- C:/Users/Mohan/Desktop/ExtEMS/db/1.x/1.0/src/01.types-domains-tables-and-constraints/tables-and-constraints.sql --<--<--

CREATE TABLE core.verification_statuses
(
    verification_status_id                  smallint PRIMARY KEY,
    verification_status_name                national character varying(128) NOT NULL
);

COMMENT ON TABLE core.verification_statuses IS 
'Verification statuses are integer values used to represent the state of a transaction.
For example, a verification status of value "0" would mean that the transaction has not yet been verified.
A negative value indicates that the transaction was rejected, whereas a positive value means approved.

Remember:
1. Only approved transactions appear on ledgers and final reports.
2. Cash repository balance is maintained on the basis of LIFO principle. 

   This means that cash balance is affected (reduced) on your repository as soon as a credit transaction is posted,
   without the transaction being approved on the first place. If you reject the transaction, the cash balance then increases.
   This also means that the cash balance is not affected (increased) on your repository as soon as a debit transaction is posted.
   You will need to approve the transaction.

   It should however be noted that the cash repository balance might be less than the total cash shown on your balance sheet,
   if you have pending transactions to verify. You cannot perform EOD operation if you have pending verifications.
';

CREATE TABLE auth.users
(
    user_id                                 SERIAL PRIMARY KEY,
    role_id                                 integer NOT NULL,
    department_id                           integer NOT NULL,
    office_id                               integer NOT NULL,
    user_name                               national character varying(50) NOT NULL,
    full_name                               national character varying(100) NOT NULL,
    can_change_password                     boolean NOT NULL DEFAULT(true),
    password                                text NOT NULL,
    elevated                                boolean NOT NULL 
                                            CONSTRAINT users_elevated_df DEFAULT(false),
    audit_user_id                           integer NULL REFERENCES auth.users(user_id),
    audit_ts                                TIMESTAMP WITH TIME ZONE NULL 
                                            DEFAULT(NOW())
);

COMMENT ON TABLE auth.users IS
'
The users table contains users accounts and their login information. It also contains a sys user account which does not have a password.
The sys user account is a special account used by the MixERP workflow to perform routine tasks. The sys user cannot have a valid password
or cannot be allowed to log in interactively.';


CREATE UNIQUE INDEX verification_statuses_verification_status_name_uix
ON core.verification_statuses(UPPER(verification_status_name));

CREATE TABLE core.flag_types
(
    flag_type_id                            SERIAL PRIMARY KEY,
    flag_type_name                          national character varying(24) NOT NULL,
    background_color                        color NOT NULL,
    foreground_color                        color NOT NULL,
    audit_user_id                           integer NULL REFERENCES auth.users(user_id),
    audit_ts                                TIMESTAMP WITH TIME ZONE NULL
                                            DEFAULT(NOW())
);

COMMENT ON TABLE core.flag_types IS 'Flags are used by users to mark transactions. The flags created by a user is not visible to others.';

CREATE TABLE core.flags
(
    flag_id                                 BIGSERIAL PRIMARY KEY,
    user_id                                 integer NOT NULL REFERENCES auth.users(user_id),
    flag_type_id                            integer NOT NULL REFERENCES core.flag_types(flag_type_id),
    resource                                text, --Fully qualified resource name. Example: transactions.non_gl_stock_master.
    resource_key                            text, --The unique identifier for lookup. Example: non_gl_stock_master_id,
    resource_id                             text, --The value of the unique identifier to lookup for,
    flagged_on                              TIMESTAMP WITH TIME ZONE NULL 
                                            DEFAULT(NOW())
);

CREATE TABLE core.attachment_lookup
(
        attachment_lookup_id                SERIAL PRIMARY KEY,
        book                                national character varying(50) NOT NULL,
        resource                            text NOT NULL,
        resource_key                        text NOT NULL        
);

CREATE UNIQUE INDEX attachment_lookup_book_uix
ON core.attachment_lookup(lower(book));

CREATE UNIQUE INDEX attachment_lookup_resource_resource_key_uix
ON core.attachment_lookup(lower(book), lower(resource_key));

CREATE TABLE core.attachments
(
    attachment_id                           BIGSERIAL PRIMARY KEY,
    user_id                                 integer NOT NULL 
                                            REFERENCES auth.users(user_id),
    resource                                text NOT NULL, --Fully qualified resource name. Example: transactions.non_gl_stock_master.
    resource_key                            text NOT NULL, --The unique identifier for lookup. Example: non_gl_stock_master_id,
    resource_id                             bigint NOT NULL, --The value of the unique identifier to lookup for,
    original_file_name                      text NOT NULL,
    file_extension                          national character varying(12) NOT NULL,
    file_path                               text NOT NULL,
    comment                                 national character varying(96) NOT NULL  
                                            CONSTRAINT attachments_comment_df 
                                            DEFAULT(''),
    added_on                                TIMESTAMP WITH TIME ZONE NOT NULL  
                                            CONSTRAINT attachments_added_on_df 
                                            DEFAULT(NOW())
);

CREATE UNIQUE INDEX attachments_file_path_uix
ON core.attachments(UPPER(file_path));

CREATE TABLE core.genders(
    gender_id       SERIAL NOT NULL PRIMARY KEY,
    gender_code     national character varying(24) NOT NULL UNIQUE,
    gender_name     national character varying(100) NOT NULL,   
    audit_user_id   integer NULL REFERENCES auth.users(user_id),
    audit_ts        TIMESTAMP WITH TIME ZONE NULL
                    DEFAULT(NOW())
);

CREATE TABLE core.faculties(
    faculty_id          SERIAL NOT NULL PRIMARY KEY,
    faculty_code        national character varying(24)  NOT NULL   UNIQUE,
    faculty_name        national character varying(100) NOT NULL,
    audit_user_id       integer NULL REFERENCES auth.users(user_id),
    audit_ts            TIMESTAMP WITH TIME ZONE NULL
                        DEFAULT(NOW())
);

CREATE TABLE core.academic_levels(
    academic_level_id   SERIAL NOT NULL PRIMARY KEY,
    academic_level_code national character varying(24) NOT NULL UNIQUE,
    academic_level_name national character varying(100) NOT NULL,
    audit_user_id       integer NULL REFERENCES auth.users(user_id),
    audit_ts            TIMESTAMP WITH TIME ZONE NULL
                        DEFAULT(NOW())
);

CREATE TABLE core.courses(
    course_id           SERIAL NOT NULL PRIMARY KEY,
    course_code         national character varying(24) NOT NULL UNIQUE,
    course_name         national character varying(100) NOT NULL,
    faculty_id          integer NOT NULL REFERENCES core.faculties,
    academic_level_id   integer NOT NULL REFERENCES core.academic_levels,
    duration            integer NOT NULL,
    is_active           boolean NOT NULL DEFAULT(true),
    audit_user_id       integer NULL REFERENCES auth.users(user_id),
    audit_ts            TIMESTAMP WITH TIME ZONE NULL
                        DEFAULT(NOW())
);

CREATE INDEX courses_is_active_ix 
    ON core.courses(is_active);

CREATE INDEX courses_faculty_id_ix 
    ON core.courses(faculty_id);

CREATE INDEX courses_academic_level_id_ix 
    ON core.courses(academic_level_id);

CREATE TABLE core.subjects(
    subject_id      SERIAL NOT NULL PRIMARY KEY,
    subject_code    national character varying(24) NOT NULL UNIQUE,
    subject_name    national character varying(100) NOT NULL,
    course_id       integer NOT NULL REFERENCES core.courses,
    is_optional     boolean NOT NULL,
    teaching_hour   integer NOT NULL,
    full_mark       numeric NOT NULL,
    pass_mark       numeric NOT NULL,
    audit_user_id   integer NULL REFERENCES auth.users(user_id),
    audit_ts        TIMESTAMP WITH TIME ZONE NULL
                    DEFAULT(NOW())
);

CREATE INDEX subjects_is_optional_ix 
    ON core.subjects(is_optional);

CREATE INDEX subjects_course_id_ix 
    ON core.subjects(course_id);

CREATE TABLE core.batches(
    batch_id        SERIAL NOT NULL PRIMARY KEY,
    batch_code      national character varying(24) NOT NULL UNIQUE,
    batch_name      national character varying(100) NOT NULL,
    starts_on       date NOT NULL,
    ends_on         date NOT NULL,
    course_id       integer NOT NULL REFERENCES core.courses,
    is_active       boolean NOT NULL DEFAULT(true),
    total_semester  integer NOT NULL,
    audit_user_id   integer NULL REFERENCES auth.users(user_id),
    audit_ts        TIMESTAMP WITH TIME ZONE NULL
                    DEFAULT(NOW())
);

CREATE INDEX batches_starts_on_ix 
ON core.batches(starts_on); 

CREATE INDEX batches_ends_on_ix 
ON core.batches(ends_on);

CREATE INDEX batches_course_id_ix 
ON core.batches(course_id);

CREATE INDEX batches_is_active_ix 
ON core.batches(is_active);

CREATE TABLE student.parents(
    parent_id           BIGSERIAL NOT NULL PRIMARY KEY,
    first_name          national character varying(50) NOT NULL,
    middle_name         national character varying(50) NULL,
    last_name           national character varying(50) NOT NULL,
    permanent_address   national character varying(250) NOT NULL,
    temp_address        national character varying(50) NULL,
    contact_number      national character varying(50) NOT NULL,
    email               national character varying(50) NULL,
    audit_user_id       integer NULL REFERENCES auth.users(user_id),
    audit_ts            TIMESTAMP WITH TIME ZONE NULL
                        DEFAULT(NOW())
);

CREATE TABLE student.students(
    student_id          BIGSERIAL NOT NULL PRIMARY KEY,
    student_code        national character varying(24) NOT NULL UNIQUE,
    student_name        national character varying(155) NOT NULL,
    first_name          national character varying(50) NOT NULL,
    middle_name         national character varying(50) NULL,
    last_name           national character varying(50) NOT NULL,
    photo               image,
    permanent_address   national character varying(100) NULL,
    temp_address        national character varying(100) NULL,
    contact_number      national character varying(50)  NULL,
    email               national character varying(50)  NULL,
    date_of_birth       date    NOT NULL,
    gender_id           integer NOT NULL REFERENCES core.genders,
    blood_group         national character varying(5) NULL,
    roll_number         integer NOT NULL,
    parent_id           bigint NOT NULL REFERENCES student.parents,
    parent_relation     national character varying(50) NOT NULL,
    is_active           boolean NOT NULL DEFAULT(true),
    other_details       national character varying(250) NULL,
    audit_user_id       integer NULL REFERENCES auth.users(user_id),
    audit_ts            TIMESTAMP WITH TIME ZONE NULL
                        DEFAULT(NOW())
);

CREATE INDEX students_date_of_birth_ix
    ON student.students(date_of_birth);

CREATE INDEX students_gender_id_ix
    ON student.students(gender_id);

CREATE INDEX students_parent_id_ix
    ON student.students(parent_id);

CREATE INDEX students_is_active_ix
    ON student.students(is_active);

CREATE TABLE student.admission(
    admission_id        BIGSERIAL NOT NULL PRIMARY KEY,
    admission_code      national character varying(24),
    admission_date      date NOT NULL,
    student_id          integer NOT NULL REFERENCES student.students,
    batch_id            integer NOT NULL REFERENCES core.batches,
    is_active           boolean NOT NULL DEFAULT(true),
    completed_on        date NULL,
    audit_user_id       integer NULL REFERENCES auth.users(user_id),
    audit_ts            TIMESTAMP WITH TIME ZONE NULL
                        DEFAULT(NOW()),
                        CHECK(is_active IS false AND completed_on IS NULL OR
                            is_active IS true AND completed_on IS NOT NULL)
);

CREATE INDEX admission_admission_date_ix 
    ON student.admission(admission_date);

CREATE INDEX admission_student_id_ix 
    ON student.admission(student_id);

CREATE INDEX admission_batch_id_ix 
    ON student.admission(batch_id);

CREATE INDEX admission_is_active_ix 
    ON student.admission(is_active);

CREATE INDEX admission_completed_on_ix 
    ON student.admission(completed_on);

CREATE TABLE student.student_subjects(
    student_subject_id  BIGSERIAL   NOT NULL PRIMARY KEY,
    student_id          bigint      NOT NULL REFERENCES student.students,
    batch_id            integer     NOT NULL REFERENCES core.batches,
    subject_id          integer     NOT NULL REFERENCES core.subjects,
    audit_user_id       integer NULL REFERENCES auth.users(user_id),
    audit_ts            TIMESTAMP WITH TIME ZONE NULL
                        DEFAULT(NOW())
);

CREATE UNIQUE INDEX student_subjects_student_id_subject_id_uix 
    ON student.student_subjects(student_id, subject_id);

CREATE INDEX student_subjects_student_id_ix 
    ON student.student_subjects(student_id);

CREATE INDEX student_subjects_subject_id_ix 
    ON student.student_subjects(subject_id);

CREATE TABLE student.attendance(
    attendance_id       BIGSERIAL NOT NULL PRIMARY KEY,
    attendance_date     date NOT NULL,
    student_id          integer NOT NULL REFERENCES student.students,
    audit_user_id       integer NULL REFERENCES auth.users(user_id),
    audit_ts            TIMESTAMP WITH TIME ZONE NULL
                        DEFAULT(NOW())
);

CREATE INDEX attendance_attendance_date_ix 
ON student.attendance(attendance_date);

CREATE INDEX attendance_student_id_ix 
ON student.attendance(student_id);


