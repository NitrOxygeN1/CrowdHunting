CREATE TABLE Task (
  id_task GUID NOT NULL,
  task_title VARCHAR,
  task_description VARCHAR,
  github_id INT,
  karma INT,
  id_project GUID,
  PRIMARY KEY  (id_task)
);