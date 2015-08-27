-- =========================================
-- Create table template Windows Azure SQL Database 
-- =========================================
drop table branches;
drop table students;
drop table contacts;
drop table counslers;


CREATE TABLE contacts
(
	id int NOT NULL IDENTITY (1,1) PRIMARY KEY, 
	[user_id] varchar(15) null, 
	first_name nvarchar(50) not null, 
	last_name nvarchar(50) not null, 
	phone_mobile nvarchar(15) null, 
	phone_home nvarchar(15) null, 
	email_1 nvarchar(100) null, 
	email_2 nvarchar(100) null, 
	[address] nvarchar(100) null,
	image varchar(2560) null
	)



CREATE TABLE branches
(
	id int NOT NULL IDENTITY (1,1) , 
	name nvarchar(50) not null, 
	[address] nvarchar(50) not null, 
	principle_contacts_id int null, 
	contact_a_contacts_id int null , 
	contact_b_contacts_id int null , 
    PRIMARY KEY (id)
)
GO



CREATE TABLE students
(
	student_concacts_id int not null default 0 PRIMARY KEY,
	grade varchar(10) not null,
	branch_id int NULL  , 
	[class] varchar(10) not null,
	health_issues nvarchar(2560) null,
	pick_up_options nvarchar(2560) null,
	gender bit not null,
	birthday date null,
	is_active bit default 1 not null,
	parent_a_contacts_id int null , 
	parent_b_contacts_id int null 
)


CREATE TABLE counslers
(
	counsler_concacts_id int not null default 0 PRIMARY KEY,
	gender bit not null,
	birthday date null,
	is_active bit default 1 not null,
	allowed_branches varchar(100),
	usernmae nvarchar(256) null
)
