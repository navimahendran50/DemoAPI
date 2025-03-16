-- SQLite
INSERT into ASPNETROLES VALUES ('f2d4b5a8-7c3e-4e1b-9f6d-abc123def456', 'Admin', 'Admin','ADMIN');
INSERT into ASPNETROLES VALUES ('3e8f9a2b-5c7d-4f1e-8a9c-df123abc4567', 'User', 'User','USER');

DELETE FROM ASPNETROLES;

SELECT * FROM AspNetRoles WHERE Name = 'User';

