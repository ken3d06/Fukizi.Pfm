USE FukiziPfm;
GO

IF OBJECT_ID('Accounting.PayMethod', 'U') IS NOT NULL
DROP TABLE Accounting.PayMethod; 

CREATE TABLE Accounting.PayMethod
(
	[Id] INTEGER NOT NULL IDENTITY,
	[Name] NVARCHAR(45) NOT NULL,

	CONSTRAINT PK_PayMethod PRIMARY KEY (Id)
);

IF OBJECT_ID('Accounting.ExpenditureCategory', 'U') IS NOT NULL
DROP TABLE Accounting.ExpenditureCategory; 

CREATE TABLE Accounting.ExpenditureCategory 
(
	[Id] INTEGER NOT NULL IDENTITY,
	[Name] NVARCHAR(45) NOT NULL,

	CONSTRAINT PK_ExpenditureCategory PRIMARY KEY (Id)
);


IF OBJECT_ID('Accounting.Expenditure', 'U') IS NOT NULL
DROP TABLE Accounting.Expenditure; 

CREATE TABLE Accounting.Expenditure (
	[Id] INTEGER NOT NULL IDENTITY,
	[Amount] DECIMAL(19,4) NOT NULL,
	[Date] DATE NULL,
	[CategoryId] INTEGER NOT NULL,
	[PayMethodId] INTEGER NOT NULL,
	[Description] NVARCHAR(200) NULL DEFAULT(''),

	CONSTRAINT PK_Expenditure PRIMARY KEY (Id),
	CONSTRAINT FK_Expenditure_Category FOREIGN KEY (CategoryId)
		REFERENCES Accounting.ExpenditureCategory(Id),
	CONSTRAINT FK_Expenditure_PayMethod FOREIGN KEY (PayMethodId)
		REFERENCES Accounting.PayMethod(Id)
);

IF OBJECT_ID('Accounting.RevenueCategory', 'U') IS NOT NULL
DROP TABLE Accounting.RevenueCategory; 

CREATE TABLE Accounting.RevenueCategory 
(
	[Id] INTEGER NOT NULL IDENTITY,
	[Name] NVARCHAR(45) NOT NULL,

	CONSTRAINT PK_RevenueCategory PRIMARY KEY (Id)
);

IF OBJECT_ID('Accounting.Revenue', 'U') IS NOT NULL
DROP TABLE Accounting.Revenue; 

CREATE TABLE Accounting.Revenue (
	[Id] INTEGER NOT NULL IDENTITY,
	[Amount] DECIMAL(19,4) NOT NULL,
	[Date] DATE NULL,
	[CategoryId] INTEGER NOT NULL,
	[PayMethodId] INTEGER NOT NULL,
	[Description] NVARCHAR(200) NULL DEFAULT(''),

	CONSTRAINT PK_Revenue PRIMARY KEY (Id),
	CONSTRAINT FK_Revenue_Category FOREIGN KEY (CategoryId)
		REFERENCES Accounting.RevenueCategory(Id),
	CONSTRAINT FK_Income_PayMethod FOREIGN KEY (PayMethodId)
		REFERENCES Accounting.PayMethod(Id)
);

