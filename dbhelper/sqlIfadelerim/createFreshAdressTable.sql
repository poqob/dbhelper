CREATE OR REPLACE FUNCTION tempp.createFreshAdressTable()
RETURNS void
AS
$$ 
BEGIN
create schema if not exists tempp;
drop table if exists tempp.newtable;
create table  tempp.newtable(country_id, country, city_id, city, district, district_id) 
as (select adresses.countries.country_id, country, adresses.cities.city_id, city,district,district_id from adresses.countries 
	inner join adresses.cities on adresses.cities.country_id = adresses.countries.country_id inner join 
	adresses.districts on adresses.districts.city_id = adresses.cities.city_id order by country_id);
	alter table tempp.newtable add column adress_id serial; 
END;
$$ 
LANGUAGE plpgsql;