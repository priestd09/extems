
DROP SCHEMA IF EXISTS academic CASCADE;
CREATE SCHEMA academic;

CREATE TABLE academic.genders(
    gender_id               SERIAL NOT NULL PRIMARY KEY,
    gender_code             national character varying(24) NOT NULL UNIQUE,
    gender_name             national character varying(100) NOT NULL,   
    is_deleted              boolean NOT NULL DEFAULT(false),
    audit_user_id           integer NULL REFERENCES account.users,
    audit_ts                TIMESTAMP WITH TIME ZONE NULL
                            DEFAULT(NOW())
);


CREATE TABLE academic.blood_groups(
    blood_group_id          SERIAL NOT NULL PRIMARY KEY,
    blood_group_code        national character varying(5) NOT NULL UNIQUE,
    blood_group_name        national character varying(100) NOT NULL,
    is_deleted              boolean NOT NULL DEFAULT(false),
    audit_user_id           integer NULL REFERENCES account.users,
    audit_ts                TIMESTAMP WITH TIME ZONE NOT NULL
                            DEFAULT(NOW())
);


CREATE TABLE academic.faculties(
    faculty_id              SERIAL NOT NULL PRIMARY KEY,
    faculty_code            national character varying(24)  NOT NULL   UNIQUE,
    faculty_name            national character varying(100) NOT NULL,
    is_deleted              boolean NOT NULL DEFAULT(false),
    audit_user_id           integer NULL REFERENCES account.users,
    audit_ts                TIMESTAMP WITH TIME ZONE NULL
                            DEFAULT(NOW())
);

CREATE TABLE academic.academic_levels(
    academic_level_id       SERIAL NOT NULL PRIMARY KEY,
    academic_level_code     national character varying(24) NOT NULL UNIQUE,
    academic_level_name     national character varying(100) NOT NULL,
    is_deleted              boolean NOT NULL DEFAULT(false),
    audit_user_id           integer NULL REFERENCES account.users,
    audit_ts                TIMESTAMP WITH TIME ZONE NULL
                            DEFAULT(NOW())
);

CREATE TABLE academic.courses(
    course_id                   SERIAL NOT NULL PRIMARY KEY,
    course_code                 national character varying(24) NOT NULL UNIQUE,
    course_name                 national character varying(100) NOT NULL,
    faculty_id                  integer NOT NULL REFERENCES academic.faculties,
    academic_level_id           integer NOT NULL REFERENCES academic.academic_levels,
    duration                    integer NOT NULL,
    is_active                   boolean NOT NULL DEFAULT(true),
    is_deleted                  boolean NOT NULL DEFAULT(false),
    allow_multiple_admission    boolean NOT NULL DEFAULT(true),
    audit_user_id               integer NULL REFERENCES account.users,
    audit_ts                    TIMESTAMP WITH TIME ZONE NULL
                                DEFAULT(NOW())
);

CREATE INDEX courses_is_active_ix 
    ON academic.courses(is_active);

CREATE INDEX courses_faculty_id_ix 
    ON academic.courses(faculty_id);

CREATE INDEX courses_academic_level_id_ix 
    ON academic.courses(academic_level_id);

CREATE TABLE academic.subjects(
    subject_id              SERIAL NOT NULL PRIMARY KEY,
    subject_code            national character varying(24) NOT NULL UNIQUE,
    subject_name            national character varying(100) NOT NULL,
    course_id               integer NOT NULL REFERENCES academic.courses,
    semester                integer NULL,
    total_weekly_classes    integer NOT NULL,
    credit_hours            integer NOT NULL,
    full_mark               numeric NOT NULL,
    pass_mark               numeric NOT NULL,
    is_deleted              boolean NOT NULL DEFAULT(false),
    audit_user_id           integer NULL REFERENCES account.users,
    audit_ts                TIMESTAMP WITH TIME ZONE NULL
                            DEFAULT(NOW())
);


CREATE INDEX subjects_course_id_ix 
    ON academic.subjects(course_id);

CREATE TABLE academic.batches(
    batch_id                SERIAL NOT NULL PRIMARY KEY,
    batch_code              national character varying(24) NOT NULL UNIQUE,
    batch_name              national character varying(100) NOT NULL,
    starts_on               date NOT NULL,
    ends_on                 date NOT NULL,
    course_id               integer NOT NULL REFERENCES academic.courses,
    is_active               boolean NOT NULL DEFAULT(true),
    total_semester          integer NOT NULL,
    is_deleted              boolean NOT NULL DEFAULT(false),
    audit_user_id           integer NULL REFERENCES account.users,
    audit_ts                TIMESTAMP WITH TIME ZONE NULL
                            DEFAULT(NOW())
);

CREATE INDEX batches_starts_on_ix 
ON academic.batches(starts_on); 

CREATE INDEX batches_ends_on_ix 
ON academic.batches(ends_on);

CREATE INDEX batches_course_id_ix 
ON academic.batches(course_id);

CREATE INDEX batches_is_active_ix 
ON academic.batches(is_active);

CREATE TABLE academic.class_shifts(
    class_shift_id          SERIAL NOT NULL PRIMARY KEY,
    class_shift_code        national character varying(24) NOT NULL UNIQUE,
    class_shift_name        national character varying(100) NOT NULL,
    is_deleted              boolean NOT NULL DEFAULT(false)
);

CREATE TABLE academic.sections(
    section_id              SERIAL NOT NULL PRIMARY KEY,
    section_code            national character varying(24) NOT NULL UNIQUE,
    section_name            national character varying(100) NOT NULL,
    office_id               integer NOT NULL,
    batch_id                integer NOT NULL REFERENCES academic.batches,
    is_deleted              boolean NOT NULL DEFAULT(false),
    audit_user_id           integer NOT NULL REFERENCES account.users,
    audit_ts                TIMESTAMP WITH TIME ZONE NOT NULL
                            DEFAULT(NOW())
);

CREATE TABLE academic.classes(
    class_id                SERIAL NOT NULL PRIMARY KEY,
    class_code              national character varying(24) NOT NULL UNIQUE,
    class_name              national character varying(100) NOT NULL,
    office_id               integer NOT NULL,
    batch_id                integer NOT NULL REFERENCES academic.batches,
    class_shift_id          integer NOT NULL REFERENCES academic.class_shifts,
    semester                integer NULL,
    section_id              integer NOT NULL REFERENCES academic.sections,
    is_deleted              boolean NOT NULL DEFAULT(false),
    audit_user_id           integer NOT NULL REFERENCES account.users,
    audit_ts                TIMESTAMP WITH TIME ZONE NOT NULL
                            DEFAULT(NOW())
);

CREATE TABLE academic.houses(
    house_id                SERIAL NOT NULL PRIMARY KEY,
    house_code              national character varying(24) NOT NULL UNIQUE,
    house_name              national character varying(100) NOT NULL,
    class_id                integer NOT NULL REFERENCES academic.classes,
    audit_user_id           integer NULL REFERENCES account.users,
    audit_ts                TIMESTAMP WITH TIME ZONE NOT NULL
                            DEFAULT(NOW())
);
