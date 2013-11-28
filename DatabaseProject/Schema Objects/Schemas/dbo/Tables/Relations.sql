ALTER TABLE User_Skill ADD CONSTRAINT User_Skill_fk1 FOREIGN KEY (id_skill) REFERENCES Skills(id_skill);
ALTER TABLE User_Skill ADD CONSTRAINT User_Skill_fk2 FOREIGN KEY (id_user) REFERENCES Users(id_user);

ALTER TABLE Task_Skill ADD CONSTRAINT Task_Skill_fk1 FOREIGN KEY (id_skill) REFERENCES Skills(id_skill);
ALTER TABLE Task_Skill ADD CONSTRAINT Task_Skill_fk2 FOREIGN KEY (id_task) REFERENCES Task(id_task);
ALTER TABLE Project ADD CONSTRAINT Project_fk1 FOREIGN KEY (id_project) REFERENCES Project(id_project);
ALTER TABLE Project ADD CONSTRAINT Project_fk2 FOREIGN KEY (id_user) REFERENCES Usesr(id_user);
ALTER TABLE Project_Skill ADD CONSTRAINT Project_Skill_fk1 FOREIGN KEY (id_skill) REFERENCES Skills(id_skill);
ALTER TABLE Project_Skill ADD CONSTRAINT Project_Skill_fk2 FOREIGN KEY (id_project) REFERENCES Project(id_project);

ALTER TABLE Membership ADD CONSTRAINT Membership_fk1 FOREIGN KEY (id_user) REFERENCES Users(id_user);
ALTER TABLE Membership ADD CONSTRAINT Membership_fk2 FOREIGN KEY (id_project) REFERENCES Project(id_project);
ALTER TABLE Membership ADD CONSTRAINT Membership_fk3 FOREIGN KEY (id_role) REFERENCES Role(id_role);

ALTER TABLE Task ADD CONSTRAINT Task_fk1 FOREIGN KEY (id_project) REFERENCES Project(id_project);