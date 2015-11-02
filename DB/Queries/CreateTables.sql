-- =========================================
-- Create table template Windows Azure SQL Database 
-- =========================================

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
	id int NOT NULL IDENTITY (1,1) PRIMARY KEY, 
	[user_id] varchar(15) null, 
	grade varchar(10) not null,
	branch_id int NULL  , 
	[class] varchar(10) not null,
	health_issues nvarchar(2560) null,
	pick_up_options nvarchar(2560) null,
	gender bit not null,
	birthday date null,
	is_active bit default 1 not null,
	phone_mobile nvarchar(15) null, 
	phone_home nvarchar(15) null, 
	[address] nvarchar(100) null,
	parent_a_email nvarchar(100) null, 
	parent_a_phone_mobile nvarchar(100) null, 
	parent_a_first_name nvarchar(50) null, 
	parent_a_last_name nvarchar(50) null, 
	parent_b_email nvarchar(100) null, 
	parent_b_phone_mobile nvarchar(100) null, 
	parent_b_first_name nvarchar(50) null, 
	parent_b_last_name nvarchar(50) null, 

)


CREATE TABLE counslers
(
	id  int NOT NULL IDENTITY (1,1) PRIMARY KEY, 
	[user_id] varchar(15) not null, 
	gender bit not null,
	birthday date null,
	is_active bit default 1 not null,
	allowed_branches varchar(100),
	usernmae nvarchar(256) not null,
	first_name nvarchar(50) not null, 
	last_name nvarchar(50) not null, 
	phone_mobile nvarchar(15) not null, 
	phone_home nvarchar(15) null, 
	email_1 nvarchar(100) null, 
	email_2 nvarchar(100) null, 
	[address] nvarchar(100) null,
	image varchar(2560) null
)
