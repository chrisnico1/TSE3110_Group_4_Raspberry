CREATE DATABASE SmartDatabase
go
USE SmartDatabase
go
CREATE TABLE [ALARM]
( 
	[AlarmId]            INT IDENTITY(1,1) NOT NULL,
	[AlarmCat]           INT NOT NULL,
	[AlarmCode]          Char(4) NOT NULL,
	[DateTime]           datetime NOT NULL,
	[AlarmMessage]       CHAR(250) NOT NULL,
    CONSTRAINT [PK_ALARM] PRIMARY KEY CLUSTERED ([AlarmId] ASC)
)
go

CREATE TABLE [LIGHTS]
( 
	[LightId]            INT IDENTITY(1,1) NOT NULL,
	[Status]             BINARY NOT NULL,
    CONSTRAINT [PK_LIGHTS] PRIMARY KEY CLUSTERED ([LightId] ASC)
)
go