CREATE TABLE User (
  id_user GUID NOT NULL,
  name VARCHAR,
  surname VARCHAR,
  github_login VARCHAR,
  password VARCHAR,
  disabled INT,
  PRIMARY KEY  (id_user)
);

CREATE TABLE Skills (
  id_skill GUID NOT NULL,
  skill_name VARCHAR,
  PRIMARY KEY  (id_skill)
);

CREATE TABLE User_Skill (
  id_user_skill GUID NOT NULL,
  id_skill GUID,
  id_user GUID,
  level INT,
  PRIMARY KEY  (id_user_skill)
);

CREATE TABLE Task (
  id_task GUID NOT NULL,
  task_title VARCHAR,
  task_description VARCHAR,
  github_id INT,
  karma INT,
  PRIMARY KEY  (id_task)
);

CREATE TABLE Task_Skill (
  id_task_skill GUID NOT NULL,
  id_skill GUID,
  id_task GUID,
  level INT,
  PRIMARY KEY  (id_task_skill)
);

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

CREATE TABLE Project_Skill (
  id_project_skill GUID NOT NULL,
  id_skill GUID,
  id_project GUID,
  level INT,
  PRIMARY KEY  (id_project_skill)
);

CREATE TABLE Role (
  id_role GUID NOT NULL,
  title VARCHAR,
  PRIMARY KEY  (id_role)
);

CREATE TABLE Membership (
  id_member GUID NOT NULL,
  id_user GUID,
  id_project GUID,
  id_role GUID,
  active INT,
  PRIMARY KEY  (id_member)
);



ALTER TABLE User_Skill ADD CONSTRAINT User_Skill_fk1 FOREIGN KEY (id_skill) REFERENCES Skills(id_skill);
ALTER TABLE User_Skill ADD CONSTRAINT User_Skill_fk2 FOREIGN KEY (id_user) REFERENCES User(id_user);

ALTER TABLE Task_Skill ADD CONSTRAINT Task_Skill_fk1 FOREIGN KEY (id_skill) REFERENCES Skills(id_skill);
ALTER TABLE Task_Skill ADD CONSTRAINT Task_Skill_fk2 FOREIGN KEY (id_task) REFERENCES Task(id_task);
ALTER TABLE Project ADD CONSTRAINT Project_fk1 FOREIGN KEY (id_project) REFERENCES Project(id_project);
ALTER TABLE Project ADD CONSTRAINT Project_fk2 FOREIGN KEY (id_user) REFERENCES User(id_user);
ALTER TABLE Project_Skill ADD CONSTRAINT Project_Skill_fk1 FOREIGN KEY (id_skill) REFERENCES Skills(id_skill);
ALTER TABLE Project_Skill ADD CONSTRAINT Project_Skill_fk2 FOREIGN KEY (id_project) REFERENCES Project(id_project);

ALTER TABLE Membership ADD CONSTRAINT Membership_fk1 FOREIGN KEY (id_user) REFERENCES User(id_user);
ALTER TABLE Membership ADD CONSTRAINT Membership_fk2 FOREIGN KEY (id_project) REFERENCES Project(id_project);
ALTER TABLE Membership ADD CONSTRAINT Membership_fk3 FOREIGN KEY (id_role) REFERENCES Role(id_role);