CREATE TABLE User (
  id_user GUID NOT NULL,
  name VARCHAR,
  surname VARCHAR,
  github_login VARCHAR,
  password VARCHAR,
  disabled INT,
  PRIMARY KEY  (id_user)
);