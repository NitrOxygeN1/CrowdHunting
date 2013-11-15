CREATE TABLE Project_Skill (
  id_project_skill GUID NOT NULL,
  id_skill GUID,
  id_project GUID,
  level INT,
  PRIMARY KEY  (id_project_skill)
);