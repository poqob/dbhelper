create or replace function  arts_artists.artist_counter()
returns trigger
language plpgsql
as
$$
begin
   update arts_artists.total_art_artist_count_table set artist_count = artist_count + 1;
  return new;
end;
$$