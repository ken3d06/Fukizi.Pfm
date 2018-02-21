USE [master]
GO
CREATE LOGIN [pfm_user] WITH PASSWORD=N'pfmuser', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [pfm_user]
GO

USE [FukiziPfm]
GO
CREATE USER [pfm_user] FOR LOGIN [pfm_user]
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Accounting')
BEGIN 
	EXEC ('CREATE SCHEMA [Accounting] AUTHORIZATION [dbo]')
END
GO

ALTER USER [pfm_user] WITH DEFAULT_SCHEMA=[Accounting]
GO
ALTER ROLE [db_owner] ADD MEMBER [pfm_user]
GO