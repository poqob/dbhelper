CREATE OR REPLACE FUNCTION users.auth(username TEXT,passwordd TEXT)
RETURNS BOOLEAN
AS
$$ -- Fonksiyon govdesinin (tanımının) başlangıcı
DECLARE
	result boolean;
BEGIN

result=(SELECT CAST(COUNT(1) AS BIT) AS Expr1 FROM users.users
    where user_name= username and user_password=passwordd);
	return result;
END;
$$ -- Fonksiyon govdesinin (tanımının) sonu
LANGUAGE plpgsql;