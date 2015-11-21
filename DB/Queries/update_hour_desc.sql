

CREATE TABLE [dbo].[counslers_schedule](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[counsler_id] [int] NOT NULL,
	[day] [int] not null,
	[hour_num] int not null,
	[activity] nvarchar(500) null,
	[location] nvarchar(500) null,
	[group] nvarchar(500) null,
	[comment] nvarchar(500) null,
	PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
);

select top 10 * from [counslers_schedule];

ALTER TABLE [counslers_schedule]
add [hour_desc ] nvarchar(500) null


select id,first_name from counslers order by first_name;

update [counslers_schedule]
set [hour_desc ]=
(
	case 
		when [hour_num]=1
		then '12:15-12:45'

		when [hour_num]=2
		then '12:45-01:30'

		when [hour_num]=3
		then '01:30-02:15'

		when [hour_num]=4
		then '02:15-03:00'

		when [hour_num]=5
		then '03:00-03:45'

		when [hour_num]=6
		then '03:45-04:30'
		
		end
)