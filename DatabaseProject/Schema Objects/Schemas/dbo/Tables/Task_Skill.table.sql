CREATE TABLE Task_Skill (
  id_task_skill GUID NOT NULL,
  id_skill GUID,
  id_task GUID,
  level INT,
  PRIMARY KEY  (id_task_skill)
);