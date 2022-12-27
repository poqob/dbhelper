create trigger  delete_artist
after delete
on artists.artists
for each row
execute procedure  arts_artists.artist_decreament();