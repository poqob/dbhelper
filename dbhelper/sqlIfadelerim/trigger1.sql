create trigger  insert_art
after insert
on arts.art
for each row
execute procedure  arts_artists.art_counter();