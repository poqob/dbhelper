CREATE OR REPLACE FUNCTION users.signUpFromForm(username TEXT,passwordd TEXT,countryid integer,cityid integer)
RETURNS void
AS
$$ 
DECLARE
	result boolean;
BEGIN
insert into users.users (user_name,user_password,user_country_id,user_city_id) values (username,paswordd,countryid,cityid);
COMMIT;
END;
$$ 
LANGUAGE plpgsql;