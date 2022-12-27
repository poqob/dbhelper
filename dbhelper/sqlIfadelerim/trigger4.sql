create trigger  delete_art
after delete
on arts.art
for each row
execute procedure  arts_artists.art_decreament();