CREATE TABLE Membership (
  id_member GUID NOT NULL,
  id_user GUID,
  id_project GUID,
  id_role GUID,
  active INT,
  PRIMARY KEY  (id_member)
);