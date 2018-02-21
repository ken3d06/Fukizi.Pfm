USE master;
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name = '')
DROP DATABASE FukiziPfm;

CREATE DATABASE FukiziPfm;