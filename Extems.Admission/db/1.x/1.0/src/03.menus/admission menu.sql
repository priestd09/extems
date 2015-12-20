
SELECT * FROM config.create_app('Extems.Admission', 'Admission', '1.0', 'MixERP Inc.', 'December 1, 2015', 'green list', '/dashboard/admission/applications', '{Frapid.WebsiteBuilder}'::text[]);

SELECT * FROM config.create_menu('Extems.Admission', 'Admissions & Applications', '', '', '');
SELECT * FROM config.create_menu('Extems.Admission', 'Applications', '/dashboard/admission/applications', '', 'Admissions & Applications');
SELECT * FROM config.create_menu('Extems.Admission', 'Admissions', '/dashboard/admission/admissions', '', 'Admissions & Applications');

SELECT * FROM config.create_menu('Extems.Admission', 'Scholarships', '', '', '');
SELECT * FROM config.create_menu('Extems.Admission', 'Scholarship Types', '/dashboard/admission/scholarship-types', '', 'Scholarships');
SELECT * FROM config.create_menu('Extems.Admission', 'Scholarship Applications', '/dashboard/admission/scholarships', '', 'Scholarships');

SELECT * FROM config.create_menu('Extems.Admission', 'Fee Types', '/dashboard/admission/fee-types', '', '');


