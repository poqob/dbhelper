--
-- PostgreSQL database dump
--

-- Dumped from database version 15.0
-- Dumped by pg_dump version 15.0

-- Started on 2022-12-27 07:50:13

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 9 (class 2615 OID 16788)
-- Name: about; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA about;


ALTER SCHEMA about OWNER TO postgres;

--
-- TOC entry 6 (class 2615 OID 16661)
-- Name: adresses; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA adresses;


ALTER SCHEMA adresses OWNER TO postgres;

--
-- TOC entry 10 (class 2615 OID 16812)
-- Name: artists; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA artists;


ALTER SCHEMA artists OWNER TO postgres;

--
-- TOC entry 7 (class 2615 OID 16695)
-- Name: arts; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA arts;


ALTER SCHEMA arts OWNER TO postgres;

--
-- TOC entry 22 (class 2615 OID 18080)
-- Name: arts_artists; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA arts_artists;


ALTER SCHEMA arts_artists OWNER TO postgres;

--
-- TOC entry 21 (class 2615 OID 17123)
-- Name: daily_art; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA daily_art;


ALTER SCHEMA daily_art OWNER TO postgres;

--
-- TOC entry 12 (class 2615 OID 16882)
-- Name: material; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA material;


ALTER SCHEMA material OWNER TO postgres;

--
-- TOC entry 13 (class 2615 OID 16890)
-- Name: movements; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA movements;


ALTER SCHEMA movements OWNER TO postgres;

--
-- TOC entry 8 (class 2615 OID 16757)
-- Name: museums; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA museums;


ALTER SCHEMA museums OWNER TO postgres;

--
-- TOC entry 20 (class 2615 OID 17667)
-- Name: tempp; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA tempp;


ALTER SCHEMA tempp OWNER TO postgres;

--
-- TOC entry 11 (class 2615 OID 16850)
-- Name: users; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA users;


ALTER SCHEMA users OWNER TO postgres;

--
-- TOC entry 2 (class 3079 OID 16384)
-- Name: adminpack; Type: EXTENSION; Schema: -; Owner: -
--

CREATE EXTENSION IF NOT EXISTS adminpack WITH SCHEMA pg_catalog;


--
-- TOC entry 3608 (class 0 OID 0)
-- Dependencies: 2
-- Name: EXTENSION adminpack; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION adminpack IS 'administrative functions for PostgreSQL';


--
-- TOC entry 271 (class 1255 OID 18085)
-- Name: art_counter(); Type: FUNCTION; Schema: arts_artists; Owner: postgres
--

CREATE FUNCTION arts_artists.art_counter() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
begin
   update arts_artists.total_art_artist_count_table set art_count = art_count + 1;
  return new;
end;
$$;


ALTER FUNCTION arts_artists.art_counter() OWNER TO postgres;

--
-- TOC entry 274 (class 1255 OID 18091)
-- Name: art_decreament(); Type: FUNCTION; Schema: arts_artists; Owner: postgres
--

CREATE FUNCTION arts_artists.art_decreament() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
begin
   update arts_artists.total_art_artist_count_table set art_count = art_count - 1;
  return new;
end;
$$;


ALTER FUNCTION arts_artists.art_decreament() OWNER TO postgres;

--
-- TOC entry 272 (class 1255 OID 18087)
-- Name: artist_counter(); Type: FUNCTION; Schema: arts_artists; Owner: postgres
--

CREATE FUNCTION arts_artists.artist_counter() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
begin
   update arts_artists.total_art_artist_count_table set artist_count = artist_count + 1;
  return new;
end;
$$;


ALTER FUNCTION arts_artists.artist_counter() OWNER TO postgres;

--
-- TOC entry 273 (class 1255 OID 18089)
-- Name: artist_decreament(); Type: FUNCTION; Schema: arts_artists; Owner: postgres
--

CREATE FUNCTION arts_artists.artist_decreament() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
begin
   update arts_artists.total_art_artist_count_table set artist_count = artist_count - 1;
  return new;
end;
$$;


ALTER FUNCTION arts_artists.artist_decreament() OWNER TO postgres;

--
-- TOC entry 270 (class 1255 OID 18036)
-- Name: random_int_array(integer, integer, integer); Type: FUNCTION; Schema: daily_art; Owner: postgres
--

CREATE FUNCTION daily_art.random_int_array(dim integer, min integer, max integer) RETURNS integer[]
    LANGUAGE plpgsql
    AS $$
Declare
	arr integer[];
begin
	arr= (select array_agg(round(random() * (max - min)) + min) from generate_series (0, dim));
	update daily_art.daily_art set (daily_art_ids)=ROW(arr) where daily_id=1;
	return arr;
end
$$;


ALTER FUNCTION daily_art.random_int_array(dim integer, min integer, max integer) OWNER TO postgres;

--
-- TOC entry 287 (class 1255 OID 18104)
-- Name: createfreshadresstable(); Type: FUNCTION; Schema: tempp; Owner: postgres
--

CREATE FUNCTION tempp.createfreshadresstable() RETURNS void
    LANGUAGE plpgsql
    AS $$ 
BEGIN
create schema if not exists tempp;
drop table if exists tempp.newtable;
create table  tempp.newtable(country_id, country, city_id, city, district, district_id) 
as (select adresses.countries.country_id, country, adresses.cities.city_id, city,district,district_id from adresses.countries 
	inner join adresses.cities on adresses.cities.country_id = adresses.countries.country_id inner join 
	adresses.districts on adresses.districts.city_id = adresses.cities.city_id order by country_id);
	alter table tempp.newtable add column adress_id serial; 
END;
$$;


ALTER FUNCTION tempp.createfreshadresstable() OWNER TO postgres;

--
-- TOC entry 269 (class 1255 OID 18016)
-- Name: auth(text, text); Type: FUNCTION; Schema: users; Owner: postgres
--

CREATE FUNCTION users.auth(username text, passwordd text) RETURNS boolean
    LANGUAGE plpgsql
    AS $$ -- Fonksiyon govdesinin (tanımının) başlangıcı
DECLARE
	result boolean;
BEGIN

result=(SELECT CAST(COUNT(1) AS BIT) AS Expr1 FROM users.users
    where user_name= username and user_password=passwordd);
	return result;
END;
$$;


ALTER FUNCTION users.auth(username text, passwordd text) OWNER TO postgres;

--
-- TOC entry 275 (class 1255 OID 18094)
-- Name: signupfromform(text, text, integer, integer); Type: FUNCTION; Schema: users; Owner: postgres
--

CREATE FUNCTION users.signupfromform(username text, passwordd text, countryid integer, cityid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$ 
BEGIN
 insert into users.users (user_name,user_password,user_country_id,user_city_id) values (username,passwordd,countryid,cityid);
END;
$$;


ALTER FUNCTION users.signupfromform(username text, passwordd text, countryid integer, cityid integer) OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 240 (class 1259 OID 16814)
-- Name: about; Type: TABLE; Schema: about; Owner: postgres
--

CREATE TABLE about.about (
    about_id integer NOT NULL,
    about_name character varying(30) NOT NULL,
    about_who "char" NOT NULL
);


ALTER TABLE about.about OWNER TO postgres;

--
-- TOC entry 239 (class 1259 OID 16813)
-- Name: about_about_id_seq; Type: SEQUENCE; Schema: about; Owner: postgres
--

CREATE SEQUENCE about.about_about_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE about.about_about_id_seq OWNER TO postgres;

--
-- TOC entry 3609 (class 0 OID 0)
-- Dependencies: 239
-- Name: about_about_id_seq; Type: SEQUENCE OWNED BY; Schema: about; Owner: postgres
--

ALTER SEQUENCE about.about_about_id_seq OWNED BY about.about.about_id;


--
-- TOC entry 242 (class 1259 OID 16826)
-- Name: about_art; Type: TABLE; Schema: about; Owner: postgres
--

CREATE TABLE about.about_art (
    about_id integer DEFAULT nextval('about.about_about_id_seq'::regclass) NOT NULL,
    about_text text,
    about_img text
);


ALTER TABLE about.about_art OWNER TO postgres;

--
-- TOC entry 245 (class 1259 OID 16844)
-- Name: about_art_type; Type: TABLE; Schema: about; Owner: postgres
--

CREATE TABLE about.about_art_type (
    about_id integer DEFAULT nextval('about.about_about_id_seq'::regclass) NOT NULL,
    about_text text,
    about_img text
);


ALTER TABLE about.about_art_type OWNER TO postgres;

--
-- TOC entry 241 (class 1259 OID 16820)
-- Name: about_artist; Type: TABLE; Schema: about; Owner: postgres
--

CREATE TABLE about.about_artist (
    about_id integer DEFAULT nextval('about.about_about_id_seq'::regclass) NOT NULL,
    about_text text,
    about_img text
);


ALTER TABLE about.about_artist OWNER TO postgres;

--
-- TOC entry 244 (class 1259 OID 16838)
-- Name: about_movement; Type: TABLE; Schema: about; Owner: postgres
--

CREATE TABLE about.about_movement (
    about_id integer DEFAULT nextval('about.about_about_id_seq'::regclass) NOT NULL,
    about_text text,
    about_img text
);


ALTER TABLE about.about_movement OWNER TO postgres;

--
-- TOC entry 243 (class 1259 OID 16832)
-- Name: about_museum; Type: TABLE; Schema: about; Owner: postgres
--

CREATE TABLE about.about_museum (
    about_id integer DEFAULT nextval('about.about_about_id_seq'::regclass) NOT NULL,
    about_text text,
    about_img text
);


ALTER TABLE about.about_museum OWNER TO postgres;

--
-- TOC entry 234 (class 1259 OID 16672)
-- Name: cities; Type: TABLE; Schema: adresses; Owner: postgres
--

CREATE TABLE adresses.cities (
    city_id integer NOT NULL,
    country_id integer NOT NULL,
    city character varying(30) NOT NULL
);


ALTER TABLE adresses.cities OWNER TO postgres;

--
-- TOC entry 233 (class 1259 OID 16671)
-- Name: cities_city_id_seq; Type: SEQUENCE; Schema: adresses; Owner: postgres
--

CREATE SEQUENCE adresses.cities_city_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE adresses.cities_city_id_seq OWNER TO postgres;

--
-- TOC entry 3610 (class 0 OID 0)
-- Dependencies: 233
-- Name: cities_city_id_seq; Type: SEQUENCE OWNED BY; Schema: adresses; Owner: postgres
--

ALTER SEQUENCE adresses.cities_city_id_seq OWNED BY adresses.cities.city_id;


--
-- TOC entry 232 (class 1259 OID 16663)
-- Name: countries; Type: TABLE; Schema: adresses; Owner: postgres
--

CREATE TABLE adresses.countries (
    country_id integer NOT NULL,
    country character varying(30) NOT NULL
);


ALTER TABLE adresses.countries OWNER TO postgres;

--
-- TOC entry 231 (class 1259 OID 16662)
-- Name: countries_country_id_seq; Type: SEQUENCE; Schema: adresses; Owner: postgres
--

CREATE SEQUENCE adresses.countries_country_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE adresses.countries_country_id_seq OWNER TO postgres;

--
-- TOC entry 3611 (class 0 OID 0)
-- Dependencies: 231
-- Name: countries_country_id_seq; Type: SEQUENCE OWNED BY; Schema: adresses; Owner: postgres
--

ALTER SEQUENCE adresses.countries_country_id_seq OWNED BY adresses.countries.country_id;


--
-- TOC entry 236 (class 1259 OID 16679)
-- Name: districts; Type: TABLE; Schema: adresses; Owner: postgres
--

CREATE TABLE adresses.districts (
    district_id integer NOT NULL,
    city_id integer NOT NULL,
    district character varying(30) NOT NULL
);


ALTER TABLE adresses.districts OWNER TO postgres;

--
-- TOC entry 235 (class 1259 OID 16678)
-- Name: districts_district_id_seq; Type: SEQUENCE; Schema: adresses; Owner: postgres
--

CREATE SEQUENCE adresses.districts_district_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE adresses.districts_district_id_seq OWNER TO postgres;

--
-- TOC entry 3612 (class 0 OID 0)
-- Dependencies: 235
-- Name: districts_district_id_seq; Type: SEQUENCE OWNED BY; Schema: adresses; Owner: postgres
--

ALTER SEQUENCE adresses.districts_district_id_seq OWNED BY adresses.districts.district_id;


--
-- TOC entry 255 (class 1259 OID 16931)
-- Name: artists; Type: TABLE; Schema: artists; Owner: postgres
--

CREATE TABLE artists.artists (
    artist_id integer NOT NULL,
    artist_name character varying(30) NOT NULL,
    artist_movement_id integer NOT NULL,
    artist_about_id integer NOT NULL,
    artist_country_id integer NOT NULL,
    artist_city_id integer NOT NULL
);


ALTER TABLE artists.artists OWNER TO postgres;

--
-- TOC entry 254 (class 1259 OID 16930)
-- Name: artists_artist_id_seq; Type: SEQUENCE; Schema: artists; Owner: postgres
--

CREATE SEQUENCE artists.artists_artist_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE artists.artists_artist_id_seq OWNER TO postgres;

--
-- TOC entry 3613 (class 0 OID 0)
-- Dependencies: 254
-- Name: artists_artist_id_seq; Type: SEQUENCE OWNED BY; Schema: artists; Owner: postgres
--

ALTER SEQUENCE artists.artists_artist_id_seq OWNED BY artists.artists.artist_id;


--
-- TOC entry 257 (class 1259 OID 16959)
-- Name: art; Type: TABLE; Schema: arts; Owner: postgres
--

CREATE TABLE arts.art (
    art_id integer NOT NULL,
    art_name character varying NOT NULL,
    art_type "char" NOT NULL
);


ALTER TABLE arts.art OWNER TO postgres;

--
-- TOC entry 261 (class 1259 OID 17045)
-- Name: art_architecture; Type: TABLE; Schema: arts; Owner: postgres
--

CREATE TABLE arts.art_architecture (
    art_id integer NOT NULL,
    art_artist_id integer NOT NULL,
    art_material_id integer NOT NULL,
    art_movement_id integer NOT NULL,
    art_about_id integer NOT NULL,
    art_date date
);


ALTER TABLE arts.art_architecture OWNER TO postgres;

--
-- TOC entry 256 (class 1259 OID 16958)
-- Name: art_art_id_seq; Type: SEQUENCE; Schema: arts; Owner: postgres
--

CREATE SEQUENCE arts.art_art_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE arts.art_art_id_seq OWNER TO postgres;

--
-- TOC entry 3614 (class 0 OID 0)
-- Dependencies: 256
-- Name: art_art_id_seq; Type: SEQUENCE OWNED BY; Schema: arts; Owner: postgres
--

ALTER SEQUENCE arts.art_art_id_seq OWNED BY arts.art.art_id;


--
-- TOC entry 258 (class 1259 OID 16967)
-- Name: art_decorative; Type: TABLE; Schema: arts; Owner: postgres
--

CREATE TABLE arts.art_decorative (
    art_id integer DEFAULT nextval('arts.art_art_id_seq'::regclass) NOT NULL,
    art_artist_id integer NOT NULL,
    art_material_id integer NOT NULL,
    art_movement_id integer NOT NULL,
    art_year date,
    art_about_id integer NOT NULL
);


ALTER TABLE arts.art_decorative OWNER TO postgres;

--
-- TOC entry 260 (class 1259 OID 17019)
-- Name: art_paints; Type: TABLE; Schema: arts; Owner: postgres
--

CREATE TABLE arts.art_paints (
    art_id integer DEFAULT nextval('arts.art_art_id_seq'::regclass) NOT NULL,
    art_artist_id integer NOT NULL,
    art_material_id integer NOT NULL,
    art_movement_id integer NOT NULL,
    art_about_id integer NOT NULL,
    art_date date
);


ALTER TABLE arts.art_paints OWNER TO postgres;

--
-- TOC entry 259 (class 1259 OID 16993)
-- Name: art_statues; Type: TABLE; Schema: arts; Owner: postgres
--

CREATE TABLE arts.art_statues (
    art_id integer DEFAULT nextval('arts.art_art_id_seq'::regclass) NOT NULL,
    art_artist_id integer NOT NULL,
    art_material_id integer NOT NULL,
    art_movement_id integer NOT NULL,
    art_about_id integer NOT NULL,
    art_year date
);


ALTER TABLE arts.art_statues OWNER TO postgres;

--
-- TOC entry 266 (class 1259 OID 18081)
-- Name: total_art_artist_count_table; Type: TABLE; Schema: arts_artists; Owner: postgres
--

CREATE TABLE arts_artists.total_art_artist_count_table (
    art_count integer,
    artist_count integer
);


ALTER TABLE arts_artists.total_art_artist_count_table OWNER TO postgres;

--
-- TOC entry 262 (class 1259 OID 17124)
-- Name: daily_art; Type: TABLE; Schema: daily_art; Owner: postgres
--

CREATE TABLE daily_art.daily_art (
    daily_id integer NOT NULL,
    daily_art_ids integer[]
);


ALTER TABLE daily_art.daily_art OWNER TO postgres;

--
-- TOC entry 251 (class 1259 OID 16884)
-- Name: material; Type: TABLE; Schema: material; Owner: postgres
--

CREATE TABLE material.material (
    material_id integer NOT NULL,
    material_name character varying(20) NOT NULL
);


ALTER TABLE material.material OWNER TO postgres;

--
-- TOC entry 250 (class 1259 OID 16883)
-- Name: material_material_id_seq; Type: SEQUENCE; Schema: material; Owner: postgres
--

CREATE SEQUENCE material.material_material_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE material.material_material_id_seq OWNER TO postgres;

--
-- TOC entry 3615 (class 0 OID 0)
-- Dependencies: 250
-- Name: material_material_id_seq; Type: SEQUENCE OWNED BY; Schema: material; Owner: postgres
--

ALTER SEQUENCE material.material_material_id_seq OWNED BY material.material.material_id;


--
-- TOC entry 253 (class 1259 OID 16910)
-- Name: movement; Type: TABLE; Schema: movements; Owner: postgres
--

CREATE TABLE movements.movement (
    movement_id integer NOT NULL,
    movement_name character varying NOT NULL,
    movement_about_id integer NOT NULL
);


ALTER TABLE movements.movement OWNER TO postgres;

--
-- TOC entry 252 (class 1259 OID 16909)
-- Name: movement_movement_id_seq; Type: SEQUENCE; Schema: movements; Owner: postgres
--

CREATE SEQUENCE movements.movement_movement_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE movements.movement_movement_id_seq OWNER TO postgres;

--
-- TOC entry 3616 (class 0 OID 0)
-- Dependencies: 252
-- Name: movement_movement_id_seq; Type: SEQUENCE OWNED BY; Schema: movements; Owner: postgres
--

ALTER SEQUENCE movements.movement_movement_id_seq OWNED BY movements.movement.movement_id;


--
-- TOC entry 238 (class 1259 OID 16759)
-- Name: museums; Type: TABLE; Schema: museums; Owner: postgres
--

CREATE TABLE museums.museums (
    museum_id integer NOT NULL,
    museum character varying(30) NOT NULL,
    country_id integer NOT NULL,
    city_id integer NOT NULL,
    district_id integer NOT NULL,
    about_id integer DEFAULT 0 NOT NULL
);


ALTER TABLE museums.museums OWNER TO postgres;

--
-- TOC entry 237 (class 1259 OID 16758)
-- Name: museums_museum_id_seq; Type: SEQUENCE; Schema: museums; Owner: postgres
--

CREATE SEQUENCE museums.museums_museum_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE museums.museums_museum_id_seq OWNER TO postgres;

--
-- TOC entry 3617 (class 0 OID 0)
-- Dependencies: 237
-- Name: museums_museum_id_seq; Type: SEQUENCE OWNED BY; Schema: museums; Owner: postgres
--

ALTER SEQUENCE museums.museums_museum_id_seq OWNED BY museums.museums.museum_id;


--
-- TOC entry 267 (class 1259 OID 18137)
-- Name: newtable; Type: TABLE; Schema: tempp; Owner: dbhelper
--

CREATE TABLE tempp.newtable (
    country_id integer,
    country character varying(30),
    city_id integer,
    city character varying(30),
    district character varying(30),
    district_id integer,
    adress_id integer NOT NULL
);


ALTER TABLE tempp.newtable OWNER TO dbhelper;

--
-- TOC entry 268 (class 1259 OID 18140)
-- Name: newtable_adress_id_seq; Type: SEQUENCE; Schema: tempp; Owner: dbhelper
--

CREATE SEQUENCE tempp.newtable_adress_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE tempp.newtable_adress_id_seq OWNER TO dbhelper;

--
-- TOC entry 3618 (class 0 OID 0)
-- Dependencies: 268
-- Name: newtable_adress_id_seq; Type: SEQUENCE OWNED BY; Schema: tempp; Owner: dbhelper
--

ALTER SEQUENCE tempp.newtable_adress_id_seq OWNED BY tempp.newtable.adress_id;


--
-- TOC entry 247 (class 1259 OID 16852)
-- Name: avatars; Type: TABLE; Schema: users; Owner: postgres
--

CREATE TABLE users.avatars (
    avatar_id integer NOT NULL,
    avatar_img text NOT NULL
);


ALTER TABLE users.avatars OWNER TO postgres;

--
-- TOC entry 246 (class 1259 OID 16851)
-- Name: avatars_avatar_id_seq; Type: SEQUENCE; Schema: users; Owner: postgres
--

CREATE SEQUENCE users.avatars_avatar_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE users.avatars_avatar_id_seq OWNER TO postgres;

--
-- TOC entry 3619 (class 0 OID 0)
-- Dependencies: 246
-- Name: avatars_avatar_id_seq; Type: SEQUENCE OWNED BY; Schema: users; Owner: postgres
--

ALTER SEQUENCE users.avatars_avatar_id_seq OWNED BY users.avatars.avatar_id;


--
-- TOC entry 264 (class 1259 OID 17992)
-- Name: self_art; Type: TABLE; Schema: users; Owner: postgres
--

CREATE TABLE users.self_art (
    self_art_id integer NOT NULL,
    art_name character varying(30) NOT NULL,
    user_id integer NOT NULL,
    post text NOT NULL
);


ALTER TABLE users.self_art OWNER TO postgres;

--
-- TOC entry 263 (class 1259 OID 17991)
-- Name: self_art_self_art_id_seq; Type: SEQUENCE; Schema: users; Owner: postgres
--

CREATE SEQUENCE users.self_art_self_art_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE users.self_art_self_art_id_seq OWNER TO postgres;

--
-- TOC entry 3620 (class 0 OID 0)
-- Dependencies: 263
-- Name: self_art_self_art_id_seq; Type: SEQUENCE OWNED BY; Schema: users; Owner: postgres
--

ALTER SEQUENCE users.self_art_self_art_id_seq OWNED BY users.self_art.self_art_id;


--
-- TOC entry 265 (class 1259 OID 18002)
-- Name: user_data; Type: TABLE; Schema: users; Owner: postgres
--

CREATE TABLE users.user_data (
    user_id integer NOT NULL,
    online_status boolean DEFAULT false,
    last_logout date,
    total_minute_consuming bigint DEFAULT 0
);


ALTER TABLE users.user_data OWNER TO postgres;

--
-- TOC entry 249 (class 1259 OID 16861)
-- Name: users; Type: TABLE; Schema: users; Owner: postgres
--

CREATE TABLE users.users (
    user_id integer NOT NULL,
    user_name character varying(15) NOT NULL,
    user_password character varying(15) NOT NULL,
    user_country_id integer NOT NULL,
    user_city_id integer NOT NULL,
    user_avatar_id integer DEFAULT 1 NOT NULL
);


ALTER TABLE users.users OWNER TO postgres;

--
-- TOC entry 248 (class 1259 OID 16860)
-- Name: users_user_id_seq; Type: SEQUENCE; Schema: users; Owner: postgres
--

CREATE SEQUENCE users.users_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE users.users_user_id_seq OWNER TO postgres;

--
-- TOC entry 3621 (class 0 OID 0)
-- Dependencies: 248
-- Name: users_user_id_seq; Type: SEQUENCE OWNED BY; Schema: users; Owner: postgres
--

ALTER SEQUENCE users.users_user_id_seq OWNED BY users.users.user_id;


--
-- TOC entry 3311 (class 2604 OID 16817)
-- Name: about about_id; Type: DEFAULT; Schema: about; Owner: postgres
--

ALTER TABLE ONLY about.about ALTER COLUMN about_id SET DEFAULT nextval('about.about_about_id_seq'::regclass);


--
-- TOC entry 3307 (class 2604 OID 16675)
-- Name: cities city_id; Type: DEFAULT; Schema: adresses; Owner: postgres
--

ALTER TABLE ONLY adresses.cities ALTER COLUMN city_id SET DEFAULT nextval('adresses.cities_city_id_seq'::regclass);


--
-- TOC entry 3306 (class 2604 OID 16666)
-- Name: countries country_id; Type: DEFAULT; Schema: adresses; Owner: postgres
--

ALTER TABLE ONLY adresses.countries ALTER COLUMN country_id SET DEFAULT nextval('adresses.countries_country_id_seq'::regclass);


--
-- TOC entry 3308 (class 2604 OID 16682)
-- Name: districts district_id; Type: DEFAULT; Schema: adresses; Owner: postgres
--

ALTER TABLE ONLY adresses.districts ALTER COLUMN district_id SET DEFAULT nextval('adresses.districts_district_id_seq'::regclass);


--
-- TOC entry 3322 (class 2604 OID 16934)
-- Name: artists artist_id; Type: DEFAULT; Schema: artists; Owner: postgres
--

ALTER TABLE ONLY artists.artists ALTER COLUMN artist_id SET DEFAULT nextval('artists.artists_artist_id_seq'::regclass);


--
-- TOC entry 3323 (class 2604 OID 16962)
-- Name: art art_id; Type: DEFAULT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art ALTER COLUMN art_id SET DEFAULT nextval('arts.art_art_id_seq'::regclass);


--
-- TOC entry 3320 (class 2604 OID 16887)
-- Name: material material_id; Type: DEFAULT; Schema: material; Owner: postgres
--

ALTER TABLE ONLY material.material ALTER COLUMN material_id SET DEFAULT nextval('material.material_material_id_seq'::regclass);


--
-- TOC entry 3321 (class 2604 OID 16913)
-- Name: movement movement_id; Type: DEFAULT; Schema: movements; Owner: postgres
--

ALTER TABLE ONLY movements.movement ALTER COLUMN movement_id SET DEFAULT nextval('movements.movement_movement_id_seq'::regclass);


--
-- TOC entry 3309 (class 2604 OID 16762)
-- Name: museums museum_id; Type: DEFAULT; Schema: museums; Owner: postgres
--

ALTER TABLE ONLY museums.museums ALTER COLUMN museum_id SET DEFAULT nextval('museums.museums_museum_id_seq'::regclass);


--
-- TOC entry 3330 (class 2604 OID 18141)
-- Name: newtable adress_id; Type: DEFAULT; Schema: tempp; Owner: dbhelper
--

ALTER TABLE ONLY tempp.newtable ALTER COLUMN adress_id SET DEFAULT nextval('tempp.newtable_adress_id_seq'::regclass);


--
-- TOC entry 3317 (class 2604 OID 16855)
-- Name: avatars avatar_id; Type: DEFAULT; Schema: users; Owner: postgres
--

ALTER TABLE ONLY users.avatars ALTER COLUMN avatar_id SET DEFAULT nextval('users.avatars_avatar_id_seq'::regclass);


--
-- TOC entry 3327 (class 2604 OID 17995)
-- Name: self_art self_art_id; Type: DEFAULT; Schema: users; Owner: postgres
--

ALTER TABLE ONLY users.self_art ALTER COLUMN self_art_id SET DEFAULT nextval('users.self_art_self_art_id_seq'::regclass);


--
-- TOC entry 3318 (class 2604 OID 16864)
-- Name: users user_id; Type: DEFAULT; Schema: users; Owner: postgres
--

ALTER TABLE ONLY users.users ALTER COLUMN user_id SET DEFAULT nextval('users.users_user_id_seq'::regclass);


--
-- TOC entry 3574 (class 0 OID 16814)
-- Dependencies: 240
-- Data for Name: about; Type: TABLE DATA; Schema: about; Owner: postgres
--

COPY about.about (about_id, about_name, about_who) FROM stdin;
2	Feyenoord Museum	m
3	Illusion Art Museum Prague	m
4	Ca' d'Oro	m
5	Mocenigo Palace-Museum	m
6	Museo Poldi Pezzoli	m
7	Museo Mudec	m
8	Scuderie del Quirinale	m
9	Palazzo Massimo alle Terme	m
10	Leonardo da Vinci museum	m
11	National Museum of Bargello	m
12	Galleria dell'Accademia	m
13	Abstract Expressionism	o
14	Art Deco	o
15	Art Nouveau	o
16	Baroque	o
17	Bauhaus	o
18	Classicism	o
19	Color Field Painting	o
20	Conceptual art	o
21	Cubism	o
22	Digital Art	o
23	Expressionism	o
24	Futurism	o
25	Impressionism	o
26	Minimalism	o
27	Neoclassicism	o
28	Pop Art	o
29	Rococo	o
30	Surrealism	o
31	Symbolism	o
111	Kinetic art	o
119	Architecture	t
120	Statue	t
121	Painting	t
122	Decorative arts	t
55	Michelangelo	i
56	High Renaissance	o
57	Leonardo da Vinci	i
58	Edebiyat-ı Cedide 	o
59	Halil Pasha	i
60	Mária Bartuszová	i
61	Per Abramsen	i
65	Mona Lisa	a
66	Vitruvian Man	a
67	La Belle Ferronnière	a
85	Metaphysical painting	o
\.


--
-- TOC entry 3576 (class 0 OID 16826)
-- Dependencies: 242
-- Data for Name: about_art; Type: TABLE DATA; Schema: about; Owner: postgres
--

COPY about.about_art (about_id, about_text, about_img) FROM stdin;
65	Mona Lisa	https://upload.wikimedia.org/wikipedia/commons/thumb/e/ec/Mona_Lisa%2C_by_Leonardo_da_Vinci%2C_from_C2RMF_retouched.jpg/405px-Mona_Lisa%2C_by_Leonardo_da_Vinci%2C_from_C2RMF_retouched.jpg
65	Vitruvian Man	https://en.wikipedia.org/wiki/File:Da_Vinci_Vitruve_Luc_Viatour.jpg
65	La Belle Ferronnière (French pronunciation: [la bɛl fɛʁɔnjɛʁ]) is a portrait of a lady, usually attributed to Leonardo da Vinci, in the Louvre. It is also known as Portrait of an Unknown Woman. The painting's title, applied as early as the seventeenth century, identifying the sitter as the wife or daughter of an ironmonger (a ferronnier), was said to be discreetly alluding to a reputed mistress of Francis I of France, married to a certain Le Ferron. Later she was identified as Lucretia Crivelli, a married lady-in-waiting to Duchess Beatrice of Milan, who became another of the Duke's mistresses.\n\nLeonardo's Lady with an Ermine has also been known by this name. This was once believed to be a portrait of Cecilia Gallerani, one of the mistresses of Ludovico Sforza, Duke of Milan.[2] The narrative and the title were applied to Lady with an Ermine when it was in Princess Czartoryski's collection, and became confused with La Belle Ferronnière by the presence in this image also of a jewel worn on a delicate chain across the forehead, called a ferronnière.\n\nThis painting was on loan in Louvre Abu Dhabi	https://upload.wikimedia.org/wikipedia/commons/thumb/4/4d/La_Belle_Ferroni%C3%A8re_-_Google_Arts.jpg/405px-La_Belle_Ferroni%C3%A8re_-_Google_Arts.jpg
\.


--
-- TOC entry 3579 (class 0 OID 16844)
-- Dependencies: 245
-- Data for Name: about_art_type; Type: TABLE DATA; Schema: about; Owner: postgres
--

COPY about.about_art_type (about_id, about_text, about_img) FROM stdin;
119	Architecture is the art and technique of designing and building, as distinguished from the skills associated with construction.[3] It is both the process and the product of sketching, conceiving,[4] planning, designing, and constructing buildings or other structures.[5] The term comes from Latin architectura; from Ancient Greek ἀρχιτέκτων (arkhitéktōn) 'architect'; from ἀρχι- (arkhi-) 'chief', and τέκτων (téktōn) 'creator'. Architectural works, in the material form of buildings, are often perceived as cultural symbols and as works of art. Historical civilizations are often identified with their surviving architectural achievements.[6]\n\nThe practice, which began in the prehistoric era, has been used as a way of expressing culture for civilizations on all seven continents.[7] For this reason, architecture is considered to be a form of art. Texts on architecture have been written since ancient times. The earliest surviving text on architectural theories is the 1st century AD treatise De architectura by the Roman architect Vitruvius, according to whom a good building embodies firmitas, utilitas, and venustas (durability, utility, and beauty). Centuries later, Leon Battista Alberti developed his ideas further, seeing beauty as an objective quality of buildings to be found in their proportions. Giorgio Vasari wrote Lives of the Most Excellent Painters, Sculptors, and Architects and put forward the idea of style in the Western arts in the 16th century. In the 19th century, Louis Sullivan declared that "form follows function". "Function" began to replace the classical "utility" and was understood to include not only practical but also aesthetic, psychological and cultural dimensions. The idea of sustainable architecture was introduced in the late 20th century.	https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/View_of_Santa_Maria_del_Fiore_in_Florence.jpg/480px-View_of_Santa_Maria_del_Fiore_in_Florence.jpg
120	A statue is a free-standing sculpture in which the realistic, full-length figures of persons or animals are carved or cast in a durable material such as wood, metal or stone. Typical statues are life-sized or close to life-size; a sculpture that represents persons or animals in full figure but that is small enough to lift and carry is a statuette or figurine, whilst one more than twice life-size is a colossal statue.[2]\n\nStatues have been produced in many cultures from prehistory to the present; the oldest-known statue dating to about 30,000 years ago. Statues represent many different people and animals, real and mythical. Many statues are placed in public places as public art. The world's tallest statue, Statue of Unity, is 182 metres (597 ft) tall and is located near the Narmada dam in Gujarat, India.	https://upload.wikimedia.org/wikipedia/commons/thumb/0/07/Statue_of_Unity.jpg/300px-Statue_of_Unity.jpg
121	Painting is the practice of applying paint, pigment, color or other medium to a solid surface (called the "matrix" or "support").[1] The medium is commonly applied to the base with a brush, but other implements, such as knives, sponges, and airbrushes, can be used.\n\nIn art, the term painting describes both the act and the result of the action (the final work is called "a painting"). The support for paintings includes such surfaces as walls, paper, canvas, wood, glass, lacquer, pottery, leaf, copper and concrete, and the painting may incorporate multiple other materials, including sand, clay, paper, plaster, gold leaf, and even whole objects.\n\nPainting is an important form in the visual arts, bringing in elements such as drawing, composition, gesture (as in gestural painting), narration (as in narrative art), and abstraction (as in abstract art).[2] Paintings can be naturalistic and representational (as in still life and landscape painting), photographic, abstract, narrative, symbolistic (as in Symbolist art), emotive (as in Expressionism) or political in nature (as in Artivism).\n\nA portion of the history of painting in both Eastern and Western art is dominated by religious art. Examples of this kind of painting range from artwork depicting mythological figures on pottery, to Biblical scenes on the Sistine Chapel ceiling, to scenes from the life of Buddha (or other images of Eastern religious origin).	https://upload.wikimedia.org/wikipedia/commons/thumb/1/17/Rhinos_Chauvet_Cave.jpg/600px-Rhinos_Chauvet_Cave.jpg
122	The decorative arts are arts or crafts whose object is the design and manufacture of objects that are both beautiful and functional. It includes most of the arts making objects for the interiors of buildings, and interior design, but not usually architecture. Ceramic art, metalwork, furniture, jewellery, fashion, various forms of the textile arts and glassware are major groupings.\n\nApplied arts largely overlaps with decorative arts, and the modern making of applied art is usually called design. The decorative arts are often categorized in distinction to the "fine arts", namely painting, drawing, photography, and large-scale sculpture, which generally produce objects solely for their aesthetic quality and capacity to stimulate the intellect.	https://upload.wikimedia.org/wikipedia/commons/thumb/9/9a/Chinese_-_Wine_Pot_-_Walters_44569_-_Side_%28cropped%29.jpg/330px-Chinese_-_Wine_Pot_-_Walters_44569_-_Side_%28cropped%29.jpg
\.


--
-- TOC entry 3575 (class 0 OID 16820)
-- Dependencies: 241
-- Data for Name: about_artist; Type: TABLE DATA; Schema: about; Owner: postgres
--

COPY about.about_artist (about_id, about_text, about_img) FROM stdin;
55	Michelangelo , was an Italian sculptor, painter, architect, and poet of the High Renaissance. Born in the Republic of Florence, his work was inspired by models from classical antiquity and had a lasting influence on Western art. Michelangelo's creative abilities and mastery in a range of artistic arenas define him as an archetypal Renaissance man, along with his rival and elder contemporary, Leonardo da Vinci.[2] Given the sheer volume of surviving correspondence, sketches, and reminiscences, Michelangelo is one of the best-documented artists of the 16th century. He was lauded by contemporary biographers as the most accomplished artist of his era.[3][4]\n\nMichelangelo achieved fame early; two of his best-known works, the Pietà and David, were sculpted before the age of thirty. Although he did not consider himself a painter, Michelangelo created two of the most influential frescoes in the history of Western art: the scenes from Genesis on the ceiling of the Sistine Chapel in Rome, and The Last Judgment on its altar wall. His design of the Laurentian Library pioneered Mannerist architecture.[5] At the age of 71, he succeeded Antonio da Sangallo the Younger as the architect of St. Peter's Basilica. Michelangelo transformed the plan so that the western end was finished to his design, as was the dome, with some modification, after his death.\n\nMichelangelo was the first Western artist whose biography was published while he was alive.[2] In fact, two biographies were published during his lifetime. One of them, by Giorgio Vasari, proposed that Michelangelo's work transcended that of any artist living or dead, and was "supreme in not one art alone but in all three."[6]\n\nIn his lifetime, Michelangelo was often called Il Divino ('the divine one').[7] His contemporaries often admired his terribilità—his ability to instill a sense of awe in viewers of his art. Attempts by subsequent artists to imitate[8] The expressive physicality of Michelangelo's style contributed to the rise of Mannerism, a short-lived movement in Western art following the High Renaissance.	https://upload.wikimedia.org/wikipedia/commons/thumb/0/02/Michelangelo_Daniele_da_Volterra_%28dettaglio%29.jpg/330px-Michelangelo_Daniele_da_Volterra_%28dettaglio%29.jpg
57	Leonardo di ser Piero da Vinci[b] (15 April 1452 – 2 May 1519) was an Italian polymath of the High Renaissance who was active as a painter, draughtsman, engineer, scientist, theorist, sculptor, and architect.[3] While his fame initially rested on his achievements as a painter, he also became known for his notebooks, in which he made drawings and notes on a variety of subjects, including anatomy, astronomy, botany, cartography, painting, and paleontology. Leonardo is widely regarded to have been a genius who epitomized the Renaissance humanist ideal,[4] and his collective works comprise a contribution to later generations of artists matched only by that of his younger contemporary, Michelangelo.	https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Francesco_Melzi_-_Portrait_of_Leonardo.png/330px-Francesco_Melzi_-_Portrait_of_Leonardo.png
59	His family was originally from Rhodes and his father, Selim, was one of the founders of the Turkish Military Academy.\n\nLike many early Western-style Turkish artists, he received his training in technical drawing and painting at the "Mühendishane-i Berrî-i Hümâyûn" (Military School of Engineering), now known as the Istanbul Technical University.[1] Upon graduating, students were normally commissioned to become teachers at military schools, but he insisted on being allowed to continue his studies in Paris. In 1880, his father finally agreed, and he spent eight years working in the studios of Jean-Léon Gérôme.[1] He had his first showing at the Exposition Universelle in 1889 and won a medal. As it turned out, when he went back to Turkey, he still became a teacher at a military school.\n\nIn 1906, he was granted the title "Pasha". Two years later, however, at the beginning of the Second Constitutional Era, he chose to retire with the rank of Colonel and become a private art teacher. Later, he taught at the "Sanayi-i Nefise Mekteb-i Alisi" (School of Fine Arts and Crafts), now the Mimar Sinan Fine Arts University[1] and served as its Director from 1917 to 1918.[2] His students included Müfide Kadri, who became Turkey's first female art teacher.\n\nDuring the Turkish War of Independence, he went to Egypt at the invitation of Abbās Ḥilmī Pasha, the former (and last) Khedive.[2] Later, he was a long-term guest at the Khedive's largely unused mansion in Istanbul and had a studio there.	https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/Halil_Pa%C5%9Fa_Ansicht_von_Istanbul_1.jpg/330px-Halil_Pa%C5%9Fa_Ansicht_von_Istanbul_1.jpg
60	Mária Bartuszová (1936–1996) was a Slovakian sculptor known for her abstract white plaster sculptures.[1] Her work is included in the Centre Pompidou in Paris, the Slovak National Gallery in Bratislava and the Tate in London. Her artwork is part of curated selection of Venice Biennale titled "Milk of Dreams", Arsenale Area (April - November 2022)	https://upload.wikimedia.org/wikipedia/en/6/69/Photo_of_M%C3%A1ria_Bartuszov%C3%A1.jpg
61	Pieter (Per or Perry) Abramsen (Rotterdam, 27 March 1941 – Rotterdam, 13 March 2018) was a Dutch sculptor, and visiting professor at the Delft University of Technology, known for his work in which abstraction and realism are joined. Abramsen lived the first years of his life in Rotterdam-Overschie .[2] From 1957 to 1961 he studied at the Rotterdam Academy of Fine Arts and Applied Sciences, where he graduated as a sculptor.[3] Abramsen started off as an abstract sculptor immediately after graduation. He lived and worked in Rotterdam and France.\n\nFrom the beginning of his career Abramsen explored the possibilities of alternative materials working in wax, bronze, clay, (stainless) steel, sand, plaster, perspex, wood, polyester, rubber, stone, concrete and polystyrene (EPS and XPS). He explored the boundaries of the versatility of materials, learning many new techniques and researching new spatial applications. His work was exhibited in many galleries and museums at home and abroad and became a part of many museum, private and corporate collections.	https://upload.wikimedia.org/wikipedia/commons/thumb/3/3e/Perry_Abramsen%2C_1971.jpg/330px-Perry_Abramsen%2C_1971.jpg
\.


--
-- TOC entry 3578 (class 0 OID 16838)
-- Dependencies: 244
-- Data for Name: about_movement; Type: TABLE DATA; Schema: about; Owner: postgres
--

COPY about.about_movement (about_id, about_text, about_img) FROM stdin;
13	The designation ‘Abstract Expressionism’ encompasses a wide variety of American 20th-century art movements in abstract art. Also known as The New York School, this movement includes large painted canvases, sculptures and other media as well. The term ‘action painting’ is associated with Abstract Expressionism, describing a highly dynamic and spontaneous application of vigorous brushstrokes and the effects of dripping and spilling paint onto the canvas.\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2017/07/Expressionism-300x300.jpg?media=1670318709\n
14	Emerging in France before the First World War, Art Deco exploded in 1925 on the occasion of the Exposition des Arts Décoratifs (Exhibition of Decorative Arts). Blurring the line between different mediums and fields, from architecture and furniture to clothing and jewelry, Art Deco merged modern aesthetic with skillful craftsmanship, advanced technology, and elegant materials.\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2021/03/Paul_Iribe_birds_from_Les_Ateliers_de_Martine-300x300.jpg?media=1670318709\n
15	A decorative style that flourished between 1890 and 1910 throughout Europe and the U.S. Art Nouveau, also called Jugendstil (Germany) and Sezessionstil (Austria), is characterized by sinuous, asymmetrical lines based on organic forms. Although it influenced painting and sculpture, its chief manifestations were in architecture and the decorative and graphic arts, aiming to create a new style, free of the imitative historicism that dominated much of 19th-century art movements and design.\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2017/07/1-1-300x300.jpg?media=1670318709\n
16	The term Baroque, derived from the Portuguese ‘barocco’ meaning ‘irregular pearl or stone’,  is a movement in art and architecture developed in Europe from the early seventeenth to mid-eighteenth century. Baroque emphasizes dramatic, exaggerated motion and clear, easily interpreted, detail, which is a far cry from Surrealism, to produce drama, tension, exuberance, and grandeur.\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2017/07/1-3.jpg?media=1670318709\n
17	The school of art and design was founded in Germany by Walter Gropius in 1919 and shut down by the Nazis in 1933. The faculty brought together artists, architects, and designers, and developed an experimental pedagogy that focused on materials and functions rather than traditional art school methodologies. In its successive incarnations in Weimar, Dessau, and Berlin, it became the site of influential conversations about the role of modern art and design in society.\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2021/03/1024px-Bauhaus-Signet.svg.png?media=1670318709\n
18	The school of art and design was founded in Germany by Walter Gropius in 1919 and shut down by the Nazis in 1933. The faculty brought together artists, architects, and designers, and developed an experimental pedagogy that focused on materials and functions rather than traditional art school methodologies. In its successive incarnations in Weimar, Dessau, and Berlin, it became the site of influential conversations about the role of modern art and design in society.\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2021/03/1024px-Bauhaus-Signet.svg.png?media=1670318709\n
19	Often associated with Abstract Expressionism, the Colour Field painters were concerned with the use of pure abstraction but rejected the active gestures typical of Action Painting in favor of expressing the sublime through large and flat surfaces of contemplative colour and open compositions.\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2019/11/Winter-Sun-1962-by-Kenneth-Noland.-As-reproduced-in-Art-in-Time-1-300x300.jpg?media=1670318709\n
20	Conceptual art, sometimes simply called conceptualism, was one of several 20th-century art movements that arose during the 1960s, emphasizing ideas and theoretical practices rather than the creation of visual forms. The term was coined in 1967 by the artist Sol LeWitt, who gave the new genre its name in his essay “Paragraphs on Conceptual Art,” in which he wrote, “The idea itself, even if not made visual, is as much a work of art as any finished product.”\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2017/07/1-5.jpg?media=1670318709\n
21	An artistic movement began in 1907 by artists Pablo Picasso and Georges Braque who developed a visual language whose geometric planes challenged the conventions of representation in different types of art, by reinventing traditional subjects such as nudes, landscapes, and still lifes as increasingly fragmented compositions.\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2021/03/Les_Demoiselles_dAvignon.jpg?media=1670318709\n
22	Digital Art broadly covers a variety of creative practices that employ different electronic technologies and result in a final product that is also digital. From computer graphics to virtual reality, from artificial Intelligence to NFT technology, the Digital Art spectrum is wide, innovative, and under the spotlight of the contemporary art market.\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2022/01/Digital_Art_300x300.jpg?media=1670318709\n
23	Expressionism is an international artistic movement in art, architecture, literature, and performance that flourished between 1905 and 1920, especially in Germany and Austria, that sought to express the meaning of emotional experience rather than physical reality. Conventions of the expressionist style include distortion, exaggeration, fantasy, and vivid, jarring, violent, or dynamic application of color in order to express the artist’s inner feelings or ideas.\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2017/07/1-9.jpg?media=1670318709\n
24	Fairly unique among different types of art movements, it is an Italian development in abstract art and literature, founded in 1909 by Filippo Tommaso Marinetti, aiming to capture the dynamism, speed and energy of the modern mechanical world.\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2017/07/1-11.jpg?media=1670318709\n
25	Impressionism is a 19th-century art movement, associated especially with French artists such as Claude Monet, Pierre Auguste Renoir, Camille Pissarro and Alfred Sisley, who attempted to accurately and objectively record visual ‘impressions’ by using small, thin, visible brushstrokes that coalesce to form a single scene and emphasize movement and the changing qualities of light.\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2021/03/impression-sunrise-courtesy-of-musee-marmottan-uai-600x337-1.jpg?media=1670318709\n
26	Another one of the art movements from the 1960s, and typified by works composed of simple art, such as geometric shapes devoid of representational content. The minimal vocabulary of forms made from humble industrial materials challenged traditional notions of craftsmanship, the illusion of spatial depth in painting, and the idea that a work of abstract art must be one of a kind.\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2017/07/Untitled-1.jpg?media=1670318709\n
27	Almost the opposite of pop art in terms of inspiration, this style is one that arose in the second half of the eighteenth century in Europe, drawing inspiration from the classical art and culture of Ancient Greece and Ancient Rome, which is not uncommon for art movements.\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2021/03/1-18.jpg?media=1670318709\n
28	Pop Art emerged in the 1950s and was composed of British and American artists who draw inspiration from ‘popular’ imagery and products from commercial culture as opposed to ‘elitist’ fine art. Pop art reached its peak of activity in the 1960s, emphasizing the banal or kitschy elements of everyday life in such forms as mechanically reproduced silkscreens, large-scale facsimiles, and soft pop art sculptures.\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2018/02/1-21-uai-258x258.jpg?media=1670318709\n
29	Rococo is a movement in art, particularly in architecture and decorative art, that originated in France in the early 1700s.  Rococo art characteristics consist of elaborate ornamentation and a light, sensuous style, including scrollwork, foliage, and animal forms.\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2021/03/1-23.jpg?media=1670318709\n
30	Founded by the poet André Breton in Paris in 1924, Surrealism was an artistic and literary movement that was active through World War II. The main goal of Surrealism painting and Surrealism artworks was to liberate thought, language, and human experience from the oppressive boundaries of rationalism by championing the irrational, the poetic and the revolutionary.\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2021/03/1-24.jpg?media=1670318709\n
31	Symbolism emerged in the second half of the 19th century, mainly in Catholic European countries where industrialisation had developed to a great degree. Starting as a literary movement, Symbolism was soon identified with a young generation of painters who wanted art to reflect emotions and ideas rather than to represent the natural world in an objective way, united by a shared pessimism and weariness of the decadence in modern society.\n	https://usercontent.one/wp/magazine.artland.com/wp-content/uploads/2021/03/The_last_king.jpg?media=1670318709\n
56	In art history, the High Renaissance was a short period of the most exceptional artistic production in the Italian states, particularly Rome, capital of the Papal States, and in Florence, during the Italian Renaissance. Most art historians state that the High Renaissance started around 1495 or 1500 and ended in 1520 with the death of Raphael, although some say the High Renaissance ended about 1525, or in 1527 with the Sack of Rome by the army of Charles V, Holy Roman Emperor, or about 1530 (see next section for specific art historians' positions). The best-known exponents of painting, sculpture and architecture of the High Renaissance include Leonardo da Vinci, Michelangelo, Raphael, and Bramante. In recent years, the use of the term has been frequently criticized by some academic art historians for oversimplifying artistic developments, ignoring historical context, and focusing only on a few iconic works.	https://upload.wikimedia.org/wikipedia/commons/thumb/a/a8/Raffael_Stanza_della_Segnatura.jpg/330px-Raffael_Stanza_della_Segnatura.jpg
58	Edebiyat-ı Cedide (Edebiyyāt-ı Cedīde, “New Literature”) is one of two names given to a movement in Turkish literature that flourished briefly but intensely in Istanbul in the years 1313–9/1896–1901. The name that became more widely used is that of the journal which, during the years in question, became the organ of the movement, Servet-i Fünun (Thervet-i Fünūn, “Wealth of Sciences”). The term edebiyat-ı cedide had already been in more general use since the 1870s to designate European-inspired Ottoman literature as opposed to works written within the traditional parameters.	https://edebiyatakademi.com/wp-content/uploads/2020/03/servet-i-funun-1-276x300.jpg
85	Metaphysical painting (Italian: pittura metafisica) or metaphysical art was a style of painting developed by the Italian artists Giorgio de Chirico and Carlo Carrà. The movement began in 1910 with de Chirico, whose dreamlike works with sharp contrasts of light and shadow often had a vaguely threatening, mysterious quality, "painting that which cannot be seen".[1] De Chirico, his younger brother Alberto Savinio, and Carrà formally established the school and its principles in 1917.	https://upload.wikimedia.org/wikipedia/en/thumb/1/1b/De_Chirico%27s_Love_Song.jpg/330px-De_Chirico%27s_Love_Song.jpg
111	Kinetic art is art from any medium that contains movement perceivable by the viewer or that depends on motion for its effect. Canvas paintings that extend the viewer's perspective of the artwork and incorporate multidimensional movement are the earliest examples of kinetic art.[1] More pertinently speaking, kinetic art is a term that today most often refers to three-dimensional sculptures and figures such as mobiles that move naturally or are machine operated (see e. g. videos on this page of works of George Rickey, Uli Aschenborn and Sarnikoff). The moving parts are generally powered by wind, a motor[2] or the observer. Kinetic art encompasses a wide variety of overlapping techniques and styles.\n	https://upload.wikimedia.org/wikipedia/commons/thumb/b/b0/Brixel_Mirror_by_BREAKFAST_Studio.jpg/330px-Brixel_Mirror_by_BREAKFAST_Studio.jpg
\.


--
-- TOC entry 3577 (class 0 OID 16832)
-- Dependencies: 243
-- Data for Name: about_museum; Type: TABLE DATA; Schema: about; Owner: postgres
--

COPY about.about_museum (about_id, about_text, about_img) FROM stdin;
2	Feyenoord Rotterdam was founded in 1908 and is playing in Rotterdam-Zuid ever since. From 1937 onwards, the club played in the most beautiful stadium in the Netherlands; De Kuip. Feyenoord won the first Dutch championship in 1924 and the first national title in De Kuip in 1938. Players such as Willem van Hanegem, Rinus Israel, Wim Jansen and Ove Kindvall were very important in 1970 when Feyenoord won the Europacup I. In the same year, the World Cup for club teams were also won, which made Feyenoord the first Dutch club to win both prizes. \nThe football club Feyenoord have won the UEFA Cup twice, the European Cup I once, the World Cup for Club Teams 13 times, and the KNVB Cup 15 times. To this day, Feyenoord is the last club in the Netherlands to achieve European success.	https://hwva.nl/wp-content/uploads/2020/01/feyenoord_05jpg.jpg
3	Illusion Art Museum Prague is the Czech Republics first museum dedicated to illusion and trick art. Spread out over three full floors in a historically-protected building, you will encounter illusion art in many different styles, some rooted deep in history, others contemporary and cutting-edge, from anamorphic installations which render renowned historical figures in unexpected ways to metallurgical painting, trick art, spatial illusions, and more! See Czech history come alive. Play with interactive exhibits, make unforgettable memories, discover how perspective can open up new worlds, and capture photos that your friends and family will love.	https://lh3.googleusercontent.com/p/AF1QipMs86Bs8STazl-65WBJp97byL9rHDRSHuXHH9jZ=s1360-w1360-h1020
4	The Ca' d'Oro or Palazzo Santa Sofia is a palace on the Grand Canal in Venice, northern Italy. One of the older palaces in the city, its name means "golden house" due to the gilt and polychrome external decorations which once adorned its walls. Since 1927, it has been used as a museum, as the Galleria Giorgio Franchetti.\n\nIt has long been regarded as the best surviving palazzo in Venetian Gothic architecture, retaining all the most characteristic features, despite some losses. On the facade, the loggia-like window group of closely spaced small columns, with heavy tracery with quatrefoil openings above, uses the formula from the Doge's Palace that had become iconic. There are also the byzantine-inspired decoration along the roofline, and patterning in fancy coloured stone to the flat wall surfaces. The smaller windows show a variety of forms with an ogee arch, capped with a relief ornament, and the edges and zone boundaries are marked with ropework reliefs.	https://upload.wikimedia.org/wikipedia/commons/d/dd/The_Ca_D%27oro_Building_-_geograph.org.uk_-_548181.jpg
5	The Palazzo Mocenigo was bequeathed to the city of Venice by Alvise Nicolò Mocenigo in 1945.[4] He was the last descendant of the family and intended the palazzo to be used "as a Gallery of Art, to supplement Museo Correr". In 1985, the palazzo was designated as the Museum and Study Centre of the History of Fabrics and Costumes. The museum contains collections of textiles and costumes, mainly from the Correr, Guggenheim, and Cini collections, as well as the Palazzo Grassi. Palazzo Mocenigo also has a library on the first floor covering the history of costumes, fabrics, and fashion, especially from the 18th century.\n\nThe palace was frescoed by 18th-century artists including Giambattista Canal, Giovanni Scajaro, and Jacopo Guarana.	https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Venezia_-_Palazzo_Mocenigo_presso_San_Stae_._Foto_di_Paolo_Steffan.jpg/375px-Venezia_-_Palazzo_Mocenigo_presso_San_Stae_._Foto_di_Paolo_Steffan.jpg
6	The Museo Poldi Pezzoli is an art museum in Milan, Italy. It is located near the Teatro alla Scala, on Via Manzoni 12.\n\nThe museum was originated in the 19th century as a private collection of Gian Giacomo Poldi Pezzoli (1822–1879)[1] and his mother, Rosa Trivulzio, of the family of the condottiero Gian Giacomo Trivulzio. Many of the rooms in the palace were redecorated starting in 1846, a commissions entrusted to Luigi Scrosati and Giuseppe Bertini. Individual rooms were often decorated and furnished to match the paintings hung on the walls. The architect Simone Cantoni (1736–1818) rebuilt the palazzo in its present Neoclassical style with an English-style interior garden. In 1850–1853, Poldi Pezzoli commissioned the architect Giuseppe Balzaretto to refurbish his apartment.[2]\n\nPezzoli in his testament left the house and contents to the Brera Academy. Giuseppe Bertini, director of the Academy, opened the museum on 25 April 1881. During World War II, the palazzo suffered severe damage, but the artworks had been placed in safe storage. The museum was reopened in 1951 after reconstruction.\n\nThe museum is notable for its broad collection of Northern Italian and Netherlandish/Flemish artists. The exhibition includes weaponry, glassworks, ceramics, jewelry, and furnishings.	https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Il_palazzo_che_ospita_il_Museo_Poldi-Pezzoli_in_via_Manzoni%2C_Milano.jpg/390px-Il_palazzo_che_ospita_il_Museo_Poldi-Pezzoli_in_via_Manzoni%2C_Milano.jpg
7	In line with constant efforts on the part of the municipal authorities to preserve the memory of the economic and social processes that have shaped the city’s identity, the Milan City Council took steps in 1990 to buy the old Ansaldo industrial plant at Porta Genova and use it for cultural services. The disused factories, authentic monuments of industrial archaeology, have been converted into studios, workshops and new creative spaces.\nIn continuity with its original vocation but also in response to the need for recognition and revaluation manifested by the foreign communities that have found opportunities to develop and put down roots in the city, the Milan Council decided to create the Mudec Museum of Cultures in the old Ansaldo area to house and display the municipal collections of ethnographic material.	https://upload.wikimedia.org/wikipedia/commons/thumb/3/30/Mudec%2C_Agor%C3%A0%2C_Ingresso_alla_Collezione_Permanente.jpg/390px-Mudec%2C_Agor%C3%A0%2C_Ingresso_alla_Collezione_Permanente.jpg
8	The Scuderie del Quirinale (meaning The Stables of Quirinale in Italian) is an exhibition gallery in Rome close to The Quirinale Palace, the official residence of the President of the Italian Republic.\n\nThe venue was opened in 1999 after its building was renovated after a design by architect Gae Aulenti, and since then it hosts prominent art exhibitions.\n\nAbove: the entrance of the Scuderie del Quirinale exhibition gallery in Rome; photo Boldray (CC BY 2.0).\n\nBuilding and site\nThe Scuderie Palace, overlooking an extraordinary urban area, was built in the 18th century on the remains of the Roman Temple of Serapis, still partially visible.\nThe palace presents many floor levels: the reception area and all shared services for the public, including a café, a shop, and a library, are housed in the basement and on the ground floor while the temporary exhibition galleries are located on the first and second floors.\n\nWhat to see at the Scuderie del Quirinale\nThe collaboration with prominent international cultural institutions produced exhibitions of the highest quality, such as “Masterpieces from the Guggenheim”, “Sandro Botticelli, painter of the Divine Comedy”, Renaissance. Masterpieces from Italian museums”, “Rembrand. Paintings, engravings, and influences on Italian art of the 17th and 18th century”, “Metaphysics” and “From Giotto to Malevich”. The intense exhibition activity is devoted to the dissemination of the various forms of art: from the Italian classic and modern art masters to the relationships between Italian and international arts and the work of the contemporary art protagonists.	https://www.inexhibit.com/wp-content/webp-express/webp-images/uploads/2014/04/Scuderie-del-Quirinale-Roma-2-870x580.jpg.webp
9	The National Roman Museum is located in four different buildings; the Baths of Diocletain, the Palazzo Altemps, the Crypta Balbi and lastly, the Palazzo Massimo. This last palace features one of the best archaeological and classical art collections in the world.\n\nThe Palazzo Massimo is also called Palazzo Massimo alle Terme due to its close proximity to the Baths of Diocletain. The villa is a superb Neo-Renaissance style palace, erected between 1883 and 1887. It was used as a Jesuit college until 1960 and in 1981 it was transformed into part of the National Roman Museum.\n\nExhibitions\nThe various exhibitions of the Palazzo Massimo alle Terme are divided into different themes and organized chronologically throughout the four floors of the museum. The basement houses a collection of jewels, grave ornaments and Roman coins from different periods. This might be considered to be the least interesting floor of the museum.\n\nThe ground and first floor feature famous Greek and Roman sculptures and statues, as well as impressive sarcophagi and high reliefs.\n\nThe second floor showcases the best preserved Roman frescoes in the world, which are considered the highlight of the museum. Originally located in Villa of Livia and Villa Farnesina, these colourful frescoes,sometimes covering an entire room, represent different paradisiacal landscapes and domestic life.\n\nOn the same floor, visitors will also see an impressive collection of mosaics from the second and fourth century AD.	https://lh3.googleusercontent.com/p/AF1QipOmmdBDvhP4JQt7yIZdMwGWXA8Mh2aPjQcxpbb9=s1360-w1360-h1020
10	The idea of opening a museum dedicated to Leonardo da Vinci was born in 1919, on the occasion of the celebrations for the fourth centenary of his death, but it opened to the public only in 1953 thanks to the gesture of IBM, which donated a series of models reconstructed on the basis of Leonardo's drawings. Time has passed since then and today the museum itinerary is arranged over several locations: the first rooms are set up in the Palazzina Uzielli while the remaining exhibition sections are housed in the medieval Castello dei Conti Guidi, the historic seat of the museum. The itinerary also includes the "Leonardo and Painting" section at Villa del Ferrale and Leonardo's birthplace in Anchiano.[1][2]\n\n\nLeonardo's self-propelled cart\nThe museum is accessed from the Piazza dei Guidi. The Palazzina Uzielli hosts the sections "Construction machinery", "Textile manufacturing machines", "Mechanical clocks" and "Leonardo and Anatomy". At the Palazzina there are also spaces dedicated to temporary exhibitions and a large room for educational paths.[1]\n\n\nModern models of Leonardo's aerial screw\nThe Castello dei Conti Guidi houses the sections: "War machines", "Bridges", "Studies on flight", "Mechanisms and tools", "The bicycle and the self-propelled chariot", "The waters", "The optics and perspective" and "The geometric solids".[1]\n\nThe Villa del Ferrale hosts a section on Leonardo's life as a painter, with reproductions of his paintings and drawings, made in high definition and life-size. The reproductions alternate with didactic installations and explanatory videos.[1]\n\nThe visit ends with Leonardo's birthplace, where a life-size hologram tells his personal life. The idea of opening a museum dedicated to Leonardo da Vinci was born in 1919, on the occasion of the celebrations for the fourth centenary of his death, but it opened to the public only in 1953 thanks to the gesture of IBM, which donated a series of models reconstructed on the basis of Leonardo's drawings. Time has passed since then and today the museum itinerary is arranged over several locations: the first rooms are set up in the Palazzina Uzielli while the remaining exhibition sections are housed in the medieval Castello dei Conti Guidi, the historic seat of the museum. The itinerary also includes the "Leonardo and Painting" section at Villa del Ferrale and Leonardo's birthplace in Anchiano.[1][2]\n\n\nLeonardo's self-propelled cart\nThe museum is accessed from the Piazza dei Guidi. The Palazzina Uzielli hosts the sections "Construction machinery", "Textile manufacturing machines", "Mechanical clocks" and "Leonardo and Anatomy". At the Palazzina there are also spaces dedicated to temporary exhibitions and a large room for educational paths.[1]\n\n\nModern models of Leonardo's aerial screw\nThe Castello dei Conti Guidi houses the sections: "War machines", "Bridges", "Studies on flight", "Mechanisms and tools", "The bicycle and the self-propelled chariot", "The waters", "The optics and perspective" and "The geometric solids".[1]\n\nThe Villa del Ferrale hosts a section on Leonardo's life as a painter, with reproductions of his paintings and drawings, made in high definition and life-size. The reproductions alternate with didactic installations and explanatory videos.[1]\n\nThe visit ends with Leonardo's birthplace, where a life-size hologram tells his personal life.[1]	https://upload.wikimedia.org/wikipedia/commons/thumb/f/f4/Vinci%2C_castello_dei_conti_guidi_01.JPG/375px-Vinci%2C_castello_dei_conti_guidi_01.JPG
11	The National Museum has its setting in one of the oldest buildings in Florence that dates back to 1255. Initially the headquarters of the Capitano del Popolo (Captain of the People) and later of the Podestà, the palace became, in the sixteenth century, the residence of the Bargello that is of the head of the police (from which the palace takes its name) and was used as prison during the whole 18th century. Its walls witnessed important episodes of civic history. It was the meeting place of the Council of the Hundred in which Dante took part. It wituessed sieges, fires, executions, the most famous perhaps being that of Baroncelli, involved in the Pazzi plot against the Medici, which Leonardo also witnessed. During the 14th and 15th century, the palace was subjected to a series of alterations and additions, still preserving its harmonious severity, best seen in the beautiful courtyard, the balcony and the large hall on the first floor.\n\nThe building's use as National Museum began in the mid-19th century. Today it is the setting for works of sculpture, mainly from the grand ducal colleotions, and for many examples of "minor" Gothic decorative arts.\n\nThe large 14th century hall on the first floor displays some works by Donatello (1386-1466) including the early marble David, the St. George moved to this location from the niche in Orsammichele, the more mature and ambiguous bronze David, the Atys. and the Marzocco, originally installed on the battlements of Palazzo Vecchio. The works of the master are surrounded by the most delicate works of his pupils Desiderio da Settignano (c. 1430-1464) and Antonio Rossellino (c. 1427-1479). The collection also includes the two panels entered by Lorenzo Ghiberti and Filippo Brunelleschi for the Baptistery door competition of 1401. The Renaissance repertoire comprises the glazed terracottas by Luca della Robbia (c. 1400 - 1482) that include a very extraordinary group of Madonna with Child.\n\nThe rooms on the ground floor exhibit Tuscan 16th century works, focusing in particular on four masterpieces by Michelangelo (1475-1564): Bacchus, the relief representing a Madonna with Child, Brutus and David-Apollo.\nThe assortment is then followed by works of Andrea Sansovino (14601529), Jacopo Sansovino (1486-1570), Baccio Bandinelli (1488- 1560), Bartolomeo Ammannati (1511-1592), Benvenuto Cellini (the model of Perseus and the small bronze sculptures were moved to this location from the Loggia dell'Orcagna), down to Giambologna (1529-1608) with his admirable Mercury.\nThe bronze animals that were originally placed in the grotto of the Medici villa of Castello are now displayed on the staircases.\n\nThe museum stores however many other treasures: fine works of art enriched by the Carrand, Ressman and Franchetti collections comprising decorative or "minor" arts are distributed among the several rooms of the Palace, both on the first and second floor. From ivories that include several Roman and Byzantine examples, down to medieval glazes and Limoges porcelain from German and French gold works, Renaissance jewels down to Islamic examples of damascened bronze; from grand ducal collections down to Venetian glass.\nThe museum displays several treasures including very unique panel pieces and wooden sculptures. Of note are also the majolicas, arms and small bronze statues.\n\nTwo rooms on the second floor are dedicated to the glazed terracottas created by Andrea and Giovanni Della Robbia, besides displaying the bronze David and the Lady with Posy by Verrocchio in the room named after the artist, which displays also an extraordinary collection of busts of Florentine personalities made by some of the most important 15th century artists. One of the most important sculptures is the portrait of Costanza Buonarelli by Gian Lorenzo Bernini. It is also worth visiting the very lavish collection of medals belonging to the Medici family.	http://www.museumsinflorence.com/foto/bargello/thumbnails/brut.jpg
12	The Galleria dell'Accademia di Firenze, or "Gallery of the Academy of Florence", is an art museum in Florence, Italy. It is best known as the home of Michelangelo's sculpture David. It also has other sculptures by Michelangelo and a large collection of paintings by Florentine artists, mostly from the period 1300–1600 (the Trecento to the Late Renaissance). It is smaller and more specialized than the Uffizi, the main art museum in Florence. It adjoins the Accademia di Belle Arti or academy of fine arts of Florence, but despite the name has no other connection with it.\n\nIn 2016, it had 1.46 million visitors, making it the second-most-visited art museum in Italy, after the Uffizi (2.02 million). The Galleria dell'Accademia was founded in 1784 by Pietro Leopoldo, Grand Duke of Tuscany.\n\nIn 2001 the "Museo degli strumenti musicali" collection opened. It includes musical instruments made by Stradivarius, Niccolò Amati and Bartolomeo Cristofori which were acquired by the Florence Conservatory.The Galleria dell'Accademia has housed the original David by Michelangelo since 1873.[2] The sculpture was allegedly brought to the Accademia for reasons of conservation, although other factors were involved in its move from its previous outdoor location on Piazza della Signoria. The original intention was to create a "Michelangelo museum", with original sculptures and drawings, to celebrate the fourth centenary of the artist's birth. Today, the gallery's small collection of Michelangelo's work includes his four unfinished Prisoners, intended for the tomb of Pope Julius II, and a statue of Saint Matthew, also unfinished. In 1939, these were joined by the Palestrina Pietà, discovered in the Barberini chapel in Palestrina, though experts now consider its attribution to Michelangelo to be dubious.\n\nOther works on display are Florentine paintings from the 13th and 16th centuries, including works by Paolo Uccello, Domenico Ghirlandaio, Sandro Botticelli and Andrea del Sarto; and, from the High Renaissance, Giambologna's original full-size plaster modello for the Rape of the Sabine Women. As well as a number of Florentine Gothic paintings, the gallery houses the collection of Russian icons assembled by the Grand Dukes of the House of Lorraine, of which Leopoldo was one.	https://upload.wikimedia.org/wikipedia/commons/thumb/8/81/Galleria_dell%27Accademia_Florenz_David_Michelangelo.jpg/330px-Galleria_dell%27Accademia_Florenz_David_Michelangelo.jpg
\.


--
-- TOC entry 3568 (class 0 OID 16672)
-- Dependencies: 234
-- Data for Name: cities; Type: TABLE DATA; Schema: adresses; Owner: postgres
--

COPY adresses.cities (city_id, country_id, city) FROM stdin;
1	1	istanbul
10	4	florance
11	4	rome
12	4	milan
13	4	venice
14	5	prague
17	7	rotterdam
18	1	bursa
19	1	eskişehir
21	1	konya
22	6	paris
23	10	thespiae
\.


--
-- TOC entry 3566 (class 0 OID 16663)
-- Dependencies: 232
-- Data for Name: countries; Type: TABLE DATA; Schema: adresses; Owner: postgres
--

COPY adresses.countries (country_id, country) FROM stdin;
1	turkiye
2	germany
4	italy
5	czechia
6	france
7	netherlands
8	spain
10	greece
\.


--
-- TOC entry 3570 (class 0 OID 16679)
-- Dependencies: 236
-- Data for Name: districts; Type: TABLE DATA; Schema: adresses; Owner: postgres
--

COPY adresses.districts (district_id, city_id, district) FROM stdin;
1	1	beyoglu
3	1	besiktas
4	10	Proconsolo
5	10	Ricasoli
6	10	Vinci
7	11	Ventiquattro Maggio
8	11	Largo di Villa Peretti
9	12	Alessandro Manzoni
10	12	Tortona
11	13	Santa Croce
12	13	Calle Ca' d'Oro
13	14	Staré Město
14	17	Van Zandvlietplein
15	18	osmangazi
16	19	odunpazarı
18	21	karatay
\.


--
-- TOC entry 3589 (class 0 OID 16931)
-- Dependencies: 255
-- Data for Name: artists; Type: TABLE DATA; Schema: artists; Owner: postgres
--

COPY artists.artists (artist_id, artist_name, artist_movement_id, artist_about_id, artist_country_id, artist_city_id) FROM stdin;
1	Michelangelo	56	55	4	10
2	Leonardo da Vinci	56	57	4	10
3	Halil Pasha	58	59	1	1
4	Mária Bartuszová	13	60	5	14
5	Per Abramsen	13	61	7	17
\.


--
-- TOC entry 3591 (class 0 OID 16959)
-- Dependencies: 257
-- Data for Name: art; Type: TABLE DATA; Schema: arts; Owner: postgres
--

COPY arts.art (art_id, art_name, art_type) FROM stdin;
\.


--
-- TOC entry 3595 (class 0 OID 17045)
-- Dependencies: 261
-- Data for Name: art_architecture; Type: TABLE DATA; Schema: arts; Owner: postgres
--

COPY arts.art_architecture (art_id, art_artist_id, art_material_id, art_movement_id, art_about_id, art_date) FROM stdin;
\.


--
-- TOC entry 3592 (class 0 OID 16967)
-- Dependencies: 258
-- Data for Name: art_decorative; Type: TABLE DATA; Schema: arts; Owner: postgres
--

COPY arts.art_decorative (art_id, art_artist_id, art_material_id, art_movement_id, art_year, art_about_id) FROM stdin;
\.


--
-- TOC entry 3594 (class 0 OID 17019)
-- Dependencies: 260
-- Data for Name: art_paints; Type: TABLE DATA; Schema: arts; Owner: postgres
--

COPY arts.art_paints (art_id, art_artist_id, art_material_id, art_movement_id, art_about_id, art_date) FROM stdin;
\.


--
-- TOC entry 3593 (class 0 OID 16993)
-- Dependencies: 259
-- Data for Name: art_statues; Type: TABLE DATA; Schema: arts; Owner: postgres
--

COPY arts.art_statues (art_id, art_artist_id, art_material_id, art_movement_id, art_about_id, art_year) FROM stdin;
\.


--
-- TOC entry 3600 (class 0 OID 18081)
-- Dependencies: 266
-- Data for Name: total_art_artist_count_table; Type: TABLE DATA; Schema: arts_artists; Owner: postgres
--

COPY arts_artists.total_art_artist_count_table (art_count, artist_count) FROM stdin;
0	5
\.


--
-- TOC entry 3596 (class 0 OID 17124)
-- Dependencies: 262
-- Data for Name: daily_art; Type: TABLE DATA; Schema: daily_art; Owner: postgres
--

COPY daily_art.daily_art (daily_id, daily_art_ids) FROM stdin;
1	{20,40,23,24}
\.


--
-- TOC entry 3585 (class 0 OID 16884)
-- Dependencies: 251
-- Data for Name: material; Type: TABLE DATA; Schema: material; Owner: postgres
--

COPY material.material (material_id, material_name) FROM stdin;
5	clay
7	glass
8	plastic
9	wood
10	paper
11	marble
\.


--
-- TOC entry 3587 (class 0 OID 16910)
-- Dependencies: 253
-- Data for Name: movement; Type: TABLE DATA; Schema: movements; Owner: postgres
--

COPY movements.movement (movement_id, movement_name, movement_about_id) FROM stdin;
3	Metaphysical painting	85
11	Abstract Expressionism	13
12	Art Deco	14
13	Art Nouveau	15
14	Baroque	16
15	Bauhaus	17
16	Classicism	18
17	Color Field Painting	19
18	Conceptual art	20
19	Cubism	21
20	Digital Art	22
21	Expressionism	23
22	Futurism	24
23	Impressionism	25
24	Minimalism	26
25	Neoclassicism	27
26	Pop Art	28
27	Rococo	29
28	Surrealism	30
29	Symbolism	31
30	High Renaissance	56
31	Edebiyat-ı Cedide 	58
42	Kinetic art	111
\.


--
-- TOC entry 3572 (class 0 OID 16759)
-- Dependencies: 238
-- Data for Name: museums; Type: TABLE DATA; Schema: museums; Owner: postgres
--

COPY museums.museums (museum_id, museum, country_id, city_id, district_id, about_id) FROM stdin;
1	Feyenoord Museum	7	17	14	2
2	Illusion Art Museum Prague	5	14	13	3
3	Ca' d'Oro	4	13	12	4
4	Mocenigo Palace-Museum	4	13	11	5
5	Museo Poldi Pezzoli	4	12	9	6
6	Museo Mudec	4	12	10	7
7	Scuderie del Quirinale	4	11	7	8
8	Palazzo Massimo alle Terme	4	11	8	9
9	Leonardo da Vinci museum	4	10	6	10
10	National Museum of Bargello	4	10	4	11
11	Galleria dell'Accademia	4	10	5	12
\.


--
-- TOC entry 3601 (class 0 OID 18137)
-- Dependencies: 267
-- Data for Name: newtable; Type: TABLE DATA; Schema: tempp; Owner: dbhelper
--

COPY tempp.newtable (country_id, country, city_id, city, district, district_id, adress_id) FROM stdin;
1	turkiye	1	istanbul	beyoglu	1	1
1	turkiye	1	istanbul	besiktas	3	2
1	turkiye	18	bursa	osmangazi	15	3
1	turkiye	19	eskişehir	odunpazarı	16	4
1	turkiye	21	konya	karatay	18	5
4	italy	10	florance	Vinci	6	6
4	italy	11	rome	Largo di Villa Peretti	8	7
4	italy	12	milan	Alessandro Manzoni	9	8
4	italy	12	milan	Tortona	10	9
4	italy	13	venice	Santa Croce	11	10
4	italy	13	venice	Calle Ca' d'Oro	12	11
4	italy	10	florance	Ricasoli	5	12
4	italy	11	rome	Ventiquattro Maggio	7	13
4	italy	10	florance	Proconsolo	4	14
5	czechia	14	prague	Staré Město	13	15
7	netherlands	17	rotterdam	Van Zandvlietplein	14	16
\.


--
-- TOC entry 3581 (class 0 OID 16852)
-- Dependencies: 247
-- Data for Name: avatars; Type: TABLE DATA; Schema: users; Owner: postgres
--

COPY users.avatars (avatar_id, avatar_img) FROM stdin;
1	data:image/jpeg;base64,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
2	data:image/jpeg;base64,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
3	data:image/jpeg;base64,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
4	https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTlymLbDbJ74HhDV4NiAeRoJQosUmNc8aXWqg&usqp=CAU
5	https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTlqrDlqPwLD8UimMwm4dauux4LVd4xN9SZ1A&usqp=CAU
6	https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRKx7QOce-5gKiJ9j1JZs_GlZ9_0CWWNQzwkA&usqp=CAU
\.


--
-- TOC entry 3598 (class 0 OID 17992)
-- Dependencies: 264
-- Data for Name: self_art; Type: TABLE DATA; Schema: users; Owner: postgres
--

COPY users.self_art (self_art_id, art_name, user_id, post) FROM stdin;
\.


--
-- TOC entry 3599 (class 0 OID 18002)
-- Dependencies: 265
-- Data for Name: user_data; Type: TABLE DATA; Schema: users; Owner: postgres
--

COPY users.user_data (user_id, online_status, last_logout, total_minute_consuming) FROM stdin;
2	f	\N	0
1	t	2022-12-26	65
\.


--
-- TOC entry 3583 (class 0 OID 16861)
-- Dependencies: 249
-- Data for Name: users; Type: TABLE DATA; Schema: users; Owner: postgres
--

COPY users.users (user_id, user_name, user_password, user_country_id, user_city_id, user_avatar_id) FROM stdin;
2	pattis12	abc1234	1	21	2
1	poqob	abcd1234	1	19	1
\.


--
-- TOC entry 3622 (class 0 OID 0)
-- Dependencies: 239
-- Name: about_about_id_seq; Type: SEQUENCE SET; Schema: about; Owner: postgres
--

SELECT pg_catalog.setval('about.about_about_id_seq', 128, true);


--
-- TOC entry 3623 (class 0 OID 0)
-- Dependencies: 233
-- Name: cities_city_id_seq; Type: SEQUENCE SET; Schema: adresses; Owner: postgres
--

SELECT pg_catalog.setval('adresses.cities_city_id_seq', 23, true);


--
-- TOC entry 3624 (class 0 OID 0)
-- Dependencies: 231
-- Name: countries_country_id_seq; Type: SEQUENCE SET; Schema: adresses; Owner: postgres
--

SELECT pg_catalog.setval('adresses.countries_country_id_seq', 10, true);


--
-- TOC entry 3625 (class 0 OID 0)
-- Dependencies: 235
-- Name: districts_district_id_seq; Type: SEQUENCE SET; Schema: adresses; Owner: postgres
--

SELECT pg_catalog.setval('adresses.districts_district_id_seq', 18, true);


--
-- TOC entry 3626 (class 0 OID 0)
-- Dependencies: 254
-- Name: artists_artist_id_seq; Type: SEQUENCE SET; Schema: artists; Owner: postgres
--

SELECT pg_catalog.setval('artists.artists_artist_id_seq', 12, true);


--
-- TOC entry 3627 (class 0 OID 0)
-- Dependencies: 256
-- Name: art_art_id_seq; Type: SEQUENCE SET; Schema: arts; Owner: postgres
--

SELECT pg_catalog.setval('arts.art_art_id_seq', 11, true);


--
-- TOC entry 3628 (class 0 OID 0)
-- Dependencies: 250
-- Name: material_material_id_seq; Type: SEQUENCE SET; Schema: material; Owner: postgres
--

SELECT pg_catalog.setval('material.material_material_id_seq', 11, true);


--
-- TOC entry 3629 (class 0 OID 0)
-- Dependencies: 252
-- Name: movement_movement_id_seq; Type: SEQUENCE SET; Schema: movements; Owner: postgres
--

SELECT pg_catalog.setval('movements.movement_movement_id_seq', 42, true);


--
-- TOC entry 3630 (class 0 OID 0)
-- Dependencies: 237
-- Name: museums_museum_id_seq; Type: SEQUENCE SET; Schema: museums; Owner: postgres
--

SELECT pg_catalog.setval('museums.museums_museum_id_seq', 12, true);


--
-- TOC entry 3631 (class 0 OID 0)
-- Dependencies: 268
-- Name: newtable_adress_id_seq; Type: SEQUENCE SET; Schema: tempp; Owner: dbhelper
--

SELECT pg_catalog.setval('tempp.newtable_adress_id_seq', 16, true);


--
-- TOC entry 3632 (class 0 OID 0)
-- Dependencies: 246
-- Name: avatars_avatar_id_seq; Type: SEQUENCE SET; Schema: users; Owner: postgres
--

SELECT pg_catalog.setval('users.avatars_avatar_id_seq', 6, true);


--
-- TOC entry 3633 (class 0 OID 0)
-- Dependencies: 263
-- Name: self_art_self_art_id_seq; Type: SEQUENCE SET; Schema: users; Owner: postgres
--

SELECT pg_catalog.setval('users.self_art_self_art_id_seq', 1, false);


--
-- TOC entry 3634 (class 0 OID 0)
-- Dependencies: 248
-- Name: users_user_id_seq; Type: SEQUENCE SET; Schema: users; Owner: postgres
--

SELECT pg_catalog.setval('users.users_user_id_seq', 6, true);


--
-- TOC entry 3344 (class 2606 OID 16899)
-- Name: about about_about_id_key; Type: CONSTRAINT; Schema: about; Owner: postgres
--

ALTER TABLE ONLY about.about
    ADD CONSTRAINT about_about_id_key UNIQUE (about_id);


--
-- TOC entry 3350 (class 2606 OID 17183)
-- Name: about_movement about_movement_pkey; Type: CONSTRAINT; Schema: about; Owner: postgres
--

ALTER TABLE ONLY about.about_movement
    ADD CONSTRAINT about_movement_pkey PRIMARY KEY (about_id);


--
-- TOC entry 3348 (class 2606 OID 17180)
-- Name: about_museum about_museum_pkey; Type: CONSTRAINT; Schema: about; Owner: postgres
--

ALTER TABLE ONLY about.about_museum
    ADD CONSTRAINT about_museum_pkey PRIMARY KEY (about_id);


--
-- TOC entry 3346 (class 2606 OID 16819)
-- Name: about about_pkey; Type: CONSTRAINT; Schema: about; Owner: postgres
--

ALTER TABLE ONLY about.about
    ADD CONSTRAINT about_pkey PRIMARY KEY (about_id);


--
-- TOC entry 3336 (class 2606 OID 16677)
-- Name: cities cities_pkey; Type: CONSTRAINT; Schema: adresses; Owner: postgres
--

ALTER TABLE ONLY adresses.cities
    ADD CONSTRAINT cities_pkey PRIMARY KEY (city_id);


--
-- TOC entry 3332 (class 2606 OID 16670)
-- Name: countries countries_country_key; Type: CONSTRAINT; Schema: adresses; Owner: postgres
--

ALTER TABLE ONLY adresses.countries
    ADD CONSTRAINT countries_country_key UNIQUE (country);


--
-- TOC entry 3334 (class 2606 OID 16668)
-- Name: countries countries_pkey; Type: CONSTRAINT; Schema: adresses; Owner: postgres
--

ALTER TABLE ONLY adresses.countries
    ADD CONSTRAINT countries_pkey PRIMARY KEY (country_id);


--
-- TOC entry 3338 (class 2606 OID 16684)
-- Name: districts districts_pkey; Type: CONSTRAINT; Schema: adresses; Owner: postgres
--

ALTER TABLE ONLY adresses.districts
    ADD CONSTRAINT districts_pkey PRIMARY KEY (district_id);


--
-- TOC entry 3362 (class 2606 OID 16936)
-- Name: artists artists_pkey; Type: CONSTRAINT; Schema: artists; Owner: postgres
--

ALTER TABLE ONLY artists.artists
    ADD CONSTRAINT artists_pkey PRIMARY KEY (artist_id);


--
-- TOC entry 3364 (class 2606 OID 18043)
-- Name: art art_art_id_art_id1_key; Type: CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art
    ADD CONSTRAINT art_art_id_art_id1_key UNIQUE (art_id) INCLUDE (art_id);


--
-- TOC entry 3368 (class 2606 OID 17196)
-- Name: art_decorative art_decorative_pkey; Type: CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_decorative
    ADD CONSTRAINT art_decorative_pkey PRIMARY KEY (art_id);


--
-- TOC entry 3372 (class 2606 OID 17194)
-- Name: art_paints art_paints_pkey; Type: CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_paints
    ADD CONSTRAINT art_paints_pkey PRIMARY KEY (art_id);


--
-- TOC entry 3366 (class 2606 OID 16966)
-- Name: art art_pkey; Type: CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art
    ADD CONSTRAINT art_pkey PRIMARY KEY (art_id);


--
-- TOC entry 3370 (class 2606 OID 17190)
-- Name: art_statues art_statues_pkey; Type: CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_statues
    ADD CONSTRAINT art_statues_pkey PRIMARY KEY (art_id);


--
-- TOC entry 3374 (class 2606 OID 17128)
-- Name: daily_art weekly_art_pkey; Type: CONSTRAINT; Schema: daily_art; Owner: postgres
--

ALTER TABLE ONLY daily_art.daily_art
    ADD CONSTRAINT weekly_art_pkey PRIMARY KEY (daily_id);


--
-- TOC entry 3358 (class 2606 OID 16889)
-- Name: material material_pkey; Type: CONSTRAINT; Schema: material; Owner: postgres
--

ALTER TABLE ONLY material.material
    ADD CONSTRAINT material_pkey PRIMARY KEY (material_id);


--
-- TOC entry 3360 (class 2606 OID 16917)
-- Name: movement movement_pkey; Type: CONSTRAINT; Schema: movements; Owner: postgres
--

ALTER TABLE ONLY movements.movement
    ADD CONSTRAINT movement_pkey PRIMARY KEY (movement_id);


--
-- TOC entry 3340 (class 2606 OID 16766)
-- Name: museums museums_museum_key; Type: CONSTRAINT; Schema: museums; Owner: postgres
--

ALTER TABLE ONLY museums.museums
    ADD CONSTRAINT museums_museum_key UNIQUE (museum);


--
-- TOC entry 3342 (class 2606 OID 16764)
-- Name: museums museums_pkey; Type: CONSTRAINT; Schema: museums; Owner: postgres
--

ALTER TABLE ONLY museums.museums
    ADD CONSTRAINT museums_pkey PRIMARY KEY (museum_id);


--
-- TOC entry 3352 (class 2606 OID 16859)
-- Name: avatars avatars_pkey; Type: CONSTRAINT; Schema: users; Owner: postgres
--

ALTER TABLE ONLY users.avatars
    ADD CONSTRAINT avatars_pkey PRIMARY KEY (avatar_id);


--
-- TOC entry 3376 (class 2606 OID 17997)
-- Name: self_art self_art_pkey; Type: CONSTRAINT; Schema: users; Owner: postgres
--

ALTER TABLE ONLY users.self_art
    ADD CONSTRAINT self_art_pkey PRIMARY KEY (self_art_id);


--
-- TOC entry 3378 (class 2606 OID 18008)
-- Name: user_data user_data_pkey; Type: CONSTRAINT; Schema: users; Owner: postgres
--

ALTER TABLE ONLY users.user_data
    ADD CONSTRAINT user_data_pkey PRIMARY KEY (user_id);


--
-- TOC entry 3354 (class 2606 OID 17990)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: users; Owner: postgres
--

ALTER TABLE ONLY users.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (user_id);


--
-- TOC entry 3356 (class 2606 OID 18001)
-- Name: users users_user_name_key; Type: CONSTRAINT; Schema: users; Owner: postgres
--

ALTER TABLE ONLY users.users
    ADD CONSTRAINT users_user_name_key UNIQUE (user_name);


--
-- TOC entry 3419 (class 2620 OID 18090)
-- Name: artists delete_artist; Type: TRIGGER; Schema: artists; Owner: postgres
--

CREATE TRIGGER delete_artist AFTER DELETE ON artists.artists FOR EACH ROW EXECUTE FUNCTION arts_artists.artist_decreament();


--
-- TOC entry 3420 (class 2620 OID 18088)
-- Name: artists insert_artist; Type: TRIGGER; Schema: artists; Owner: postgres
--

CREATE TRIGGER insert_artist AFTER INSERT ON artists.artists FOR EACH ROW EXECUTE FUNCTION arts_artists.artist_counter();


--
-- TOC entry 3421 (class 2620 OID 18092)
-- Name: art delete_art; Type: TRIGGER; Schema: arts; Owner: postgres
--

CREATE TRIGGER delete_art AFTER DELETE ON arts.art FOR EACH ROW EXECUTE FUNCTION arts_artists.art_decreament();


--
-- TOC entry 3422 (class 2620 OID 18086)
-- Name: art insert_art; Type: TRIGGER; Schema: arts; Owner: postgres
--

CREATE TRIGGER insert_art AFTER INSERT ON arts.art FOR EACH ROW EXECUTE FUNCTION arts_artists.art_counter();


--
-- TOC entry 3385 (class 2606 OID 17961)
-- Name: about_art about_art_about_id_fkey; Type: FK CONSTRAINT; Schema: about; Owner: postgres
--

ALTER TABLE ONLY about.about_art
    ADD CONSTRAINT about_art_about_id_fkey FOREIGN KEY (about_id) REFERENCES about.about(about_id) ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 3388 (class 2606 OID 17158)
-- Name: about_art_type about_art_type_about_id_fkey; Type: FK CONSTRAINT; Schema: about; Owner: postgres
--

ALTER TABLE ONLY about.about_art_type
    ADD CONSTRAINT about_art_type_about_id_fkey FOREIGN KEY (about_id) REFERENCES about.about(about_id) ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 3384 (class 2606 OID 17163)
-- Name: about_artist about_artist_about_id_fkey; Type: FK CONSTRAINT; Schema: about; Owner: postgres
--

ALTER TABLE ONLY about.about_artist
    ADD CONSTRAINT about_artist_about_id_fkey FOREIGN KEY (about_id) REFERENCES about.about(about_id) ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 3387 (class 2606 OID 17184)
-- Name: about_movement about_movement_about_id_fkey; Type: FK CONSTRAINT; Schema: about; Owner: postgres
--

ALTER TABLE ONLY about.about_movement
    ADD CONSTRAINT about_movement_about_id_fkey FOREIGN KEY (about_id) REFERENCES about.about(about_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3386 (class 2606 OID 17173)
-- Name: about_museum about_museum_about_id_fkey; Type: FK CONSTRAINT; Schema: about; Owner: postgres
--

ALTER TABLE ONLY about.about_museum
    ADD CONSTRAINT about_museum_about_id_fkey FOREIGN KEY (about_id) REFERENCES about.about(about_id) ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 3379 (class 2606 OID 16685)
-- Name: cities cityofcountry; Type: FK CONSTRAINT; Schema: adresses; Owner: postgres
--

ALTER TABLE ONLY adresses.cities
    ADD CONSTRAINT cityofcountry FOREIGN KEY (country_id) REFERENCES adresses.countries(country_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3380 (class 2606 OID 16690)
-- Name: districts districtofcity; Type: FK CONSTRAINT; Schema: adresses; Owner: postgres
--

ALTER TABLE ONLY adresses.districts
    ADD CONSTRAINT districtofcity FOREIGN KEY (city_id) REFERENCES adresses.cities(city_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3393 (class 2606 OID 16943)
-- Name: artists artist_about_id; Type: FK CONSTRAINT; Schema: artists; Owner: postgres
--

ALTER TABLE ONLY artists.artists
    ADD CONSTRAINT artist_about_id FOREIGN KEY (artist_about_id) REFERENCES about.about(about_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3394 (class 2606 OID 16948)
-- Name: artists artist_country_id; Type: FK CONSTRAINT; Schema: artists; Owner: postgres
--

ALTER TABLE ONLY artists.artists
    ADD CONSTRAINT artist_country_id FOREIGN KEY (artist_country_id) REFERENCES adresses.countries(country_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3395 (class 2606 OID 16937)
-- Name: artists artist_movement_id; Type: FK CONSTRAINT; Schema: artists; Owner: postgres
--

ALTER TABLE ONLY artists.artists
    ADD CONSTRAINT artist_movement_id FOREIGN KEY (artist_movement_id) REFERENCES about.about(about_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3396 (class 2606 OID 16953)
-- Name: artists artists_city_id; Type: FK CONSTRAINT; Schema: artists; Owner: postgres
--

ALTER TABLE ONLY artists.artists
    ADD CONSTRAINT artists_city_id FOREIGN KEY (artist_city_id) REFERENCES adresses.cities(city_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3412 (class 2606 OID 17066)
-- Name: art_architecture art_architecture_art_about_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_architecture
    ADD CONSTRAINT art_architecture_art_about_id_fkey FOREIGN KEY (art_about_id) REFERENCES about.about(about_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3413 (class 2606 OID 17051)
-- Name: art_architecture art_architecture_art_artist_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_architecture
    ADD CONSTRAINT art_architecture_art_artist_id_fkey FOREIGN KEY (art_artist_id) REFERENCES artists.artists(artist_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3414 (class 2606 OID 18074)
-- Name: art_architecture art_architecture_art_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_architecture
    ADD CONSTRAINT art_architecture_art_id_fkey FOREIGN KEY (art_id) REFERENCES arts.art(art_id) ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 3415 (class 2606 OID 17056)
-- Name: art_architecture art_architecture_art_material_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_architecture
    ADD CONSTRAINT art_architecture_art_material_id_fkey FOREIGN KEY (art_material_id) REFERENCES material.material(material_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3416 (class 2606 OID 17061)
-- Name: art_architecture art_architecture_art_movement_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_architecture
    ADD CONSTRAINT art_architecture_art_movement_id_fkey FOREIGN KEY (art_movement_id) REFERENCES movements.movement(movement_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3397 (class 2606 OID 16988)
-- Name: art_decorative art_decorative_art_about_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_decorative
    ADD CONSTRAINT art_decorative_art_about_id_fkey FOREIGN KEY (art_about_id) REFERENCES about.about(about_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3398 (class 2606 OID 16973)
-- Name: art_decorative art_decorative_art_artist_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_decorative
    ADD CONSTRAINT art_decorative_art_artist_id_fkey FOREIGN KEY (art_artist_id) REFERENCES artists.artists(artist_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3399 (class 2606 OID 18069)
-- Name: art_decorative art_decorative_art_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_decorative
    ADD CONSTRAINT art_decorative_art_id_fkey FOREIGN KEY (art_id) REFERENCES arts.art(art_id) ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 3400 (class 2606 OID 16978)
-- Name: art_decorative art_decorative_art_material_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_decorative
    ADD CONSTRAINT art_decorative_art_material_id_fkey FOREIGN KEY (art_material_id) REFERENCES material.material(material_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3401 (class 2606 OID 16983)
-- Name: art_decorative art_decorative_art_movement_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_decorative
    ADD CONSTRAINT art_decorative_art_movement_id_fkey FOREIGN KEY (art_movement_id) REFERENCES movements.movement(movement_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3407 (class 2606 OID 17040)
-- Name: art_paints art_paints_art_about_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_paints
    ADD CONSTRAINT art_paints_art_about_id_fkey FOREIGN KEY (art_about_id) REFERENCES about.about(about_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3408 (class 2606 OID 17025)
-- Name: art_paints art_paints_art_artist_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_paints
    ADD CONSTRAINT art_paints_art_artist_id_fkey FOREIGN KEY (art_artist_id) REFERENCES artists.artists(artist_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3409 (class 2606 OID 18064)
-- Name: art_paints art_paints_art_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_paints
    ADD CONSTRAINT art_paints_art_id_fkey FOREIGN KEY (art_id) REFERENCES arts.art(art_id) ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 3410 (class 2606 OID 17030)
-- Name: art_paints art_paints_art_material_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_paints
    ADD CONSTRAINT art_paints_art_material_id_fkey FOREIGN KEY (art_material_id) REFERENCES material.material(material_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3411 (class 2606 OID 17035)
-- Name: art_paints art_paints_art_movement_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_paints
    ADD CONSTRAINT art_paints_art_movement_id_fkey FOREIGN KEY (art_movement_id) REFERENCES movements.movement(movement_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3402 (class 2606 OID 17014)
-- Name: art_statues art_statues_art_about_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_statues
    ADD CONSTRAINT art_statues_art_about_id_fkey FOREIGN KEY (art_about_id) REFERENCES about.about(about_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3403 (class 2606 OID 16999)
-- Name: art_statues art_statues_art_artist_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_statues
    ADD CONSTRAINT art_statues_art_artist_id_fkey FOREIGN KEY (art_artist_id) REFERENCES artists.artists(artist_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3404 (class 2606 OID 18059)
-- Name: art_statues art_statues_art_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_statues
    ADD CONSTRAINT art_statues_art_id_fkey FOREIGN KEY (art_id) REFERENCES arts.art(art_id) ON UPDATE CASCADE NOT VALID;


--
-- TOC entry 3405 (class 2606 OID 17004)
-- Name: art_statues art_statues_art_material_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_statues
    ADD CONSTRAINT art_statues_art_material_id_fkey FOREIGN KEY (art_material_id) REFERENCES material.material(material_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3406 (class 2606 OID 17009)
-- Name: art_statues art_statues_art_movement_id_fkey; Type: FK CONSTRAINT; Schema: arts; Owner: postgres
--

ALTER TABLE ONLY arts.art_statues
    ADD CONSTRAINT art_statues_art_movement_id_fkey FOREIGN KEY (art_movement_id) REFERENCES movements.movement(movement_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3392 (class 2606 OID 17982)
-- Name: movement movement_movement_about_id_fkey; Type: FK CONSTRAINT; Schema: movements; Owner: postgres
--

ALTER TABLE ONLY movements.movement
    ADD CONSTRAINT movement_movement_about_id_fkey FOREIGN KEY (movement_about_id) REFERENCES about.about(about_id) ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 3381 (class 2606 OID 16772)
-- Name: museums museumofcity; Type: FK CONSTRAINT; Schema: museums; Owner: postgres
--

ALTER TABLE ONLY museums.museums
    ADD CONSTRAINT museumofcity FOREIGN KEY (city_id) REFERENCES adresses.cities(city_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3382 (class 2606 OID 16767)
-- Name: museums museumofcountry; Type: FK CONSTRAINT; Schema: museums; Owner: postgres
--

ALTER TABLE ONLY museums.museums
    ADD CONSTRAINT museumofcountry FOREIGN KEY (country_id) REFERENCES adresses.countries(country_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3383 (class 2606 OID 16777)
-- Name: museums museumofdistricts; Type: FK CONSTRAINT; Schema: museums; Owner: postgres
--

ALTER TABLE ONLY museums.museums
    ADD CONSTRAINT museumofdistricts FOREIGN KEY (district_id) REFERENCES adresses.districts(district_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3389 (class 2606 OID 16877)
-- Name: users avatar_id; Type: FK CONSTRAINT; Schema: users; Owner: postgres
--

ALTER TABLE ONLY users.users
    ADD CONSTRAINT avatar_id FOREIGN KEY (user_avatar_id) REFERENCES users.avatars(avatar_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3390 (class 2606 OID 16872)
-- Name: users city_id; Type: FK CONSTRAINT; Schema: users; Owner: postgres
--

ALTER TABLE ONLY users.users
    ADD CONSTRAINT city_id FOREIGN KEY (user_city_id) REFERENCES adresses.cities(city_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3391 (class 2606 OID 16867)
-- Name: users country_id; Type: FK CONSTRAINT; Schema: users; Owner: postgres
--

ALTER TABLE ONLY users.users
    ADD CONSTRAINT country_id FOREIGN KEY (user_country_id) REFERENCES adresses.countries(country_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3417 (class 2606 OID 18044)
-- Name: self_art self_art_user_id_fkey; Type: FK CONSTRAINT; Schema: users; Owner: postgres
--

ALTER TABLE ONLY users.self_art
    ADD CONSTRAINT self_art_user_id_fkey FOREIGN KEY (user_id) REFERENCES users.users(user_id) ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 3418 (class 2606 OID 18010)
-- Name: user_data user_data_user_id_fkey; Type: FK CONSTRAINT; Schema: users; Owner: postgres
--

ALTER TABLE ONLY users.user_data
    ADD CONSTRAINT user_data_user_id_fkey FOREIGN KEY (user_id) REFERENCES users.users(user_id) ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


-- Completed on 2022-12-27 07:50:13

--
-- PostgreSQL database dump complete
--

