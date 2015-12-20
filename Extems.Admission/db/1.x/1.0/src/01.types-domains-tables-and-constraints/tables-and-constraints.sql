/**
    DEPENDANCIES : auth, academic
**/

DROP SCHEMA IF EXISTS admission CASCADE;
CREATE SCHEMA admission;

CREATE TABLE admission.verification_statuses(
    verification_status_id      smallint NOT NULL PRIMARY KEY
);

CREATE TABLE admission.admission_applications(
    admission_application_id    BIGSERIAL NOT NULL PRIMARY KEY,
    office_id                   integer NOT NULL, --> REFERENCE??
    date_of_application         date NOT NULL,
    first_name                  national character varying(50) NOT NULL,
    middle_name                 national character varying(50) NULL,
    last_name                   national character varying(50) NOT NULL,
    photo                       public.image,
    zip_code                    national character varying(128) NOT NULL,
    address_line_1              national character varying(128) NOT NULL,
    address_line_2              national character varying(128) NULL,
    street                      national character varying(128) NULL,
    city                        national character varying(128) NULL,
    state                       national character varying(128) NULL,
    country_id                  integer NOT NULL,
    phone_home                  national character varying(128) NULL,
    phone_cell                  national character varying(128) NOT NULL,
    email_address               national character varying(128) NULL,
    date_of_birth               date    NOT NULL,
    gender_id                   integer NOT NULL REFERENCES academic.genders,
    blood_group_id              integer NULL REFERENCES academic.blood_groups,
    other_details               national character varying(250) NULL,
    course_id                   integer NOT NULL REFERENCES academic.courses,
    batch_id                    integer NOT NULL REFERENCES academic.batches,
    last_institution_name       text NULL,
    passed_year                 integer NULL,
    grade_obtained              national character varying(20),
    percentage_obtained         public.decimal_strict,
    apply_for_scholorship       boolean NOT NULL DEFAULT false,
    last_verified_on            TIMESTAMP WITH TIME ZONE NULL, 
    verified_by_user_id         integer NULL REFERENCES account.users,
    verification_status_id      smallint NOT NULL REFERENCES admission.verification_statuses
                                DEFAULT(0/*Awaiting verification*/),
    verification_reason         national character varying(128) NOT NULL   
                                DEFAULT(''),
    is_addmitted                boolean NOT NULL DEFAULT false,
    audit_user_id               integer NULL REFERENCES account.users,
    audit_ts                    TIMESTAMP WITH TIME ZONE NULL
                                DEFAULT(NOW())
);

CREATE INDEX admission_applications_office_id_ix 
    ON admission.admission_applications(office_id); 

CREATE INDEX admission_applications_date_of_birth_ix 
    ON admission.admission_applications(date_of_birth);

CREATE INDEX admission_applications_gender_id_ix 
    ON admission.admission_applications(gender_id);

CREATE INDEX admission_applications_course_id_ix 
    ON admission.admission_applications(course_id);

CREATE INDEX admission_applications_batch_id_ix 
    ON admission.admission_applications(batch_id);

CREATE INDEX admission_applications_apply_for_scholorship_ix 
    ON admission.admission_applications(apply_for_scholorship);

CREATE INDEX admission_applications_is_addmitted_ix 
    ON admission.admission_applications(is_addmitted);

CREATE TABLE admission.admissions(
    admission_id                BIGSERIAL NOT NULL PRIMARY KEY,
    admission_application_id    bigint NOT NULL REFERENCES admission.admission_applications,
    admission_date              date NOT NULL,
    office_id                   integer NOT NULL, --> REFERENCES ??
    batch_id                    integer NOT NULL REFERENCES academic.batches,
    class_id                    integer NOT NULL REFERENCES academic.classes,
    house_id                    integer NULL REFERENCES academic.houses,
    is_active                   boolean NOT NULL DEFAULT(true),
    audit_user_id               integer NULL REFERENCES account.users,
    audit_ts                    TIMESTAMP WITH TIME ZONE NULL
                                DEFAULT(NOW())
);

CREATE INDEX admission_admission_date_ix 
    ON admission.admissions(admission_date);

CREATE INDEX admission_batch_id_ix 
    ON admission.admissions(batch_id);

CREATE INDEX admission_is_active_ix 
    ON admission.admissions(is_active);


CREATE TABLE admission.fee_types(
    fee_type_id                 SERIAL NOT NULL PRIMARY KEY,
    fee_type_code               national character varying(24) NOT NULL UNIQUE,
    fee_type_name               national character varying(100) NOT NULL,
    transaction_gl_account_id   bigint NULL, --> REFERENCE ??
    audit_user_id               integer NULL REFERENCES account.users,
    audit_ts                    TIMESTAMP WITH TIME ZONE NULL
                                DEFAULT(NOW())
);

CREATE TABLE admission.scholorship_types(
    scholorship_type_id     SERIAL NOT NULL PRIMARY KEY,
    scholorship_type_code   national character varying(24) NOT NULL UNIQUE,
    scholorship_type_name   national character varying(100) NOT NULL,
    description             text,
    is_active               boolean NOT NULL DEFAULT(true),
    valid_till              date NOT NULL,
    audit_user_id           integer NULL REFERENCES account.users,
    audit_ts                TIMESTAMP WITH TIME ZONE NULL
                            DEFAULT(NOW())
);

CREATE INDEX scholorship_types_is_active_ix 
    ON admission.scholorship_types(is_active);

CREATE INDEX scholorship_types_valid_till_ix 
    ON admission.scholorship_types(valid_till);

CREATE TABLE admission.scholorship_type_details(
    scholorship_type_detail_id  SERIAL NOT NULL PRIMARY KEY,
    scholorship_type_id         integer NOT NULL REFERENCES admission.scholorship_types,
    fee_type_id                 integer NOT NULL REFERENCES admission.fee_types,
    discount_percentage         decimal_strict NOT NULL,
    audit_user_id               integer NULL REFERENCES account.users,
    audit_ts                    TIMESTAMP WITH TIME ZONE NULL
                                DEFAULT(NOW())
);

CREATE INDEX scholorship_type_details_fee_type_id_ix
    ON admission.scholorship_type_details(fee_type_id);

CREATE TABLE admission.scholorships(
    scholorship_id              BIGSERIAL NOT NULL PRIMARY KEY,
    admission_application_id    bigint NOT NULL REFERENCES admission.admission_applications,
    scholorship_type_id         integer NOT NULL REFERENCES admission.scholorship_types,     
    last_verified_on            TIMESTAMP WITH TIME ZONE NULL, 
    verified_by_user_id         integer NULL REFERENCES account.users,
    verification_status_id      smallint NOT NULL REFERENCES admission.verification_statuses
                                DEFAULT(0/*Awaiting verification*/),
    verification_reason         national character varying(128) NOT NULL   
                                DEFAULT(''),
    audit_user_id               integer NULL REFERENCES account.users,
    audit_ts                    TIMESTAMP WITH TIME ZONE NULL
                                DEFAULT(NOW())
);

