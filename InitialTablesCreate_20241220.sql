IF (NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'app')) 
BEGIN
    EXEC ('CREATE SCHEMA [app] AUTHORIZATION [dbo]')
END

CREATE TABLE [app].[User] (
    Id BigInt NOT NULL  PRIMARY KEY IDENTITY(1,1),	
	UserRoleId BigInt NOT NULL,
	FirstName varchar(100) NOT NULL,
    LastName varchar(100) NOT NULL,
	Email varchar(100),
	PasswordHash varchar(250),
	Phone varchar(50),
	FailedTryCount SmallInt,
	CreatedOn DateTime,
	UpdatedOn DateTime,
	IsDeleted Bit NOT NULL
);

CREATE TABLE [app].[UserRole] (
    Id BigInt NOT NULL PRIMARY KEY IDENTITY(1,1),
    RoleType varchar(20) NOT NULL ,
	CreatedOn DateTime,
	UpdatedOn DateTime,
	IsDeleted Bit NOT NULL
);

CREATE TABLE [app].[Client] (
    Id BigInt NOT NULL PRIMARY KEY IDENTITY(1,1),
    UserId BigInt NOT NULL,
	UserRoleId BigInt NOT NULL,
	Gender Char(1),
	Weight DECIMAL(5,2),
	Height SmallInt,
	Age SmallInt,
	CreatedOn DateTime,
	UpdatedOn DateTime,
	IsDeleted Bit NOT NULL
);

CREATE TABLE [app].[Diet] (
    Id BigInt NOT NULL PRIMARY KEY IDENTITY(1,1),
    ClientId BigInt NOT NULL,
	Description nvarchar(250),
	CreatedOn DateTime,
	UpdatedOn DateTime,
	IsDeleted Bit NOT NULL
);

CREATE TABLE [app].[Meal] (
    Id BigInt NOT NULL PRIMARY KEY IDENTITY(1,1),
	DietId BigInt NOT NULL,
	Description nvarchar(250),
	CreatedOn DateTime,
	UpdatedOn DateTime,
	IsDeleted Bit NOT NULL
);

CREATE TABLE [app].[ClientDiet] (
    Id BigInt NOT NULL PRIMARY KEY IDENTITY(1,1),
    ClientId BigInt NOT NULL,
	DietId BigInt NOT NULL,
	Description nvarchar(250),
	Progress SmallInt,
	StartWeight DECIMAL(5,2),
	EndWeight DECIMAL(5,2),
	StartDate DateTime,
	EndDate DateTime,
	CreatedOn DateTime,
	UpdatedOn DateTime,
	IsDeleted Bit NOT NULL
);