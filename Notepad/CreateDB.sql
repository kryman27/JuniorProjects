﻿CREATE DATABASE Notes
Go
USE Notes
CREATE TABLE Notes
(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Note VARCHAR(1000),
CreatedOn DATE NOT NULL
)