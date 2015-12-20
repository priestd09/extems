
SELECT * FROM config.create_app('Extems.Academic', 'Academic', '1.0', 'MixERP Inc.', 'December 1, 2015', 'student', '/dashboard/academic/academic-levels', '{Frapid.WebsiteBuilder}'::text[]);

SELECT * FROM config.create_menu('Extems.Academic', 'Academic Levels', '/dashboard/academic/academic-levels', 'student', '');
SELECT * FROM config.create_menu('Extems.Academic', 'Batches', '/dashboard/academic/batches', 'users', '');
SELECT * FROM config.create_menu('Extems.Academic', 'Blood Groups', '/dashboard/academic/blood-groups', 'h', '');
SELECT * FROM config.create_menu('Extems.Academic', 'Class Shifts', '/dashboard/academic/class-shifts', 'university', '');
SELECT * FROM config.create_menu('Extems.Academic', 'Courses', '/dashboard/academic/courses', 'announcement', '');
SELECT * FROM config.create_menu('Extems.Academic', 'Faculties', '/dashboard/academic/faculties', 'suitcase', '');
SELECT * FROM config.create_menu('Extems.Academic', 'Genders', '/dashboard/academic/genders', 'user', '');
SELECT * FROM config.create_menu('Extems.Academic', 'Houses', '/dashboard/academic/houses', 'building outline', '');
SELECT * FROM config.create_menu('Extems.Academic', 'Sections', '/dashboard/academic/sections', 'columns', '');
SELECT * FROM config.create_menu('Extems.Academic', 'Subject', '/dashboard/academic/subjects', 'book', '');
