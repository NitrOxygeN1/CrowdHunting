CREATE TABLE User_Skill (
  id_user_skill GUID NOT NULL,
  id_skill GUID,
  id_user GUID,
  level INT,
  PRIMARY KEY  (id_user_skill)
);