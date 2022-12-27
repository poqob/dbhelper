CREATE OR REPLACE FUNCTION daily_art.random_int_array(dim integer, min integer, max integer)
RETURNS integer[]
AS 
$BODY$
Declare
	arr integer[];
begin
	arr= (select array_agg(round(random() * (max - min)) + min) from generate_series (0, dim));
	update daily_art.daily_art set (daily_art_ids)=ROW(arr) where daily_id=1;
	return arr;
end
$BODY$ LANGUAGE plpgsql;
-- usage example
select daily_art.random_int_array(3, 6, 40);

-- return example
--    | random_int_array
--    | integer[]
-- -----------------------------------------------------
--  1 | {26,20,13,37,21,25,38,39,36,21,31,6,32,16,22,10}