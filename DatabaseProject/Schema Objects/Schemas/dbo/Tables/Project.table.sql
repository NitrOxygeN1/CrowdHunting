CREATE TABLE Project (
  id_project GUID NOT NULL,
  name VARCHAR,
  description VARCHAR,
  date_start DATETIME,
  date_end DATETIME,
  status VARCHAR,
  github_url VARCHAR,
  id_user GUID,
  PRIMARY KEY  (id_project)
);