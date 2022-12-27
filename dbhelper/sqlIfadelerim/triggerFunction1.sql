create or replace function  arts_artists.art_counter()
returns trigger
language plpgsql
as
$$
begin
   update arts_artists.total_art_artist_count_table set art_count = art_count + 1;
  return new;
end;
$$