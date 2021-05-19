use master
create database DIARY;
use DIARY

create table EVENT_TYPE
(
	EVENT_TYPE nvarchar(50) constraint EVENT_TYPE_PK primary key
)

create table [STATUS]
(	
	[STATUS] nvarchar(30) constraint STATUS_PK primary key
)

create table CONTACT
(
	CONTACT_ID nvarchar(5) constraint CONTACT_ID_PK primary key,
	FIO nvarchar(50) unique,
	TEL_NUM nvarchar(10) unique,
	NOTES nvarchar(max)
)


create table [REPEAT]
(
	[REPEAT] date constraint REPEAT_PK primary key
)

create table [EVENT]
(
	EVRNT_ID int constraint EVENT_ID_PK primary key,
	EVENT_NAME nvarchar(50),
	EVENT_TYPE nvarchar(50) constraint EVENT_TYPE_FK foreign key
	references EVENT_TYPE(EVENT_TYPE),
	[START] datetime,
	[END] datetime,
	[REPEAT] date constraint REPEAT_FK foreign key
	references [REPEAT]([REPEAT]),
	CONTACT_ID nvarchar(5) constraint CONTACT_ID_FK foreign key
	references CONTACT(CONTACT_ID),
	[STATUS] nvarchar(30) constraint STATUS_FK foreign key
	references [STATUS]([STATUS])
)

create table TASK
(
	TASK_ID int constraint TASK_ID_PK primary key,
	[END] datetime,
	[STATUS] nvarchar(30) constraint TASK_STATUS_FK foreign key
	references [STATUS]([STATUS]),
	NOTES nvarchar(max)
)

create table [USER]
(
	[USER_NAME] nvarchar(50) constraint USER_NAME_PK primary key,
	[PASSWORD] nvarchar(15),
	[NAME] nvarchar(50),
	img varbinary(max)
)

drop table [USER]