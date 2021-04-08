CREATE DATABASE dbsample
GO

CREATE TABLE [dbo].[tbl_sample] (
    [ID]    INT          IDENTITY (1, 1) NOT NULL,
    [fname] VARCHAR (50) NULL,
    [mn]    VARCHAR (50) NULL,
    [lname] VARCHAR (50) NULL
)
GO