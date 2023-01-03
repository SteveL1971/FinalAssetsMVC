insert into dbo.AspNetRoles (Id, Name) values (1,'ADMIN');
insert into dbo.AspNetRoles (NormalizedName) values ('ADMIN');

UPDATE dbo.AspNetRoles
SET NormalizedName='ADMIN'
WHERE Id=1;

UPDATE dbo.AspNetRoles
SET Name='Admin'
WHERE Id=1;

user id: 9f0aef9e-fa93-4e4b-8bff-85e271dd8096
role id: 1

insert into dbo.AspNetUserRoles values ('9f0aef9e-fa93-4e4b-8bff-85e271dd8096', 1);
