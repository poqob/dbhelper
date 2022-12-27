create trigger  insert_artist
after insert
on artists.artists
for each row
execute procedure  arts_artists.artist_counter();