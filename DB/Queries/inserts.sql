	SET IDENTITY_INSERT contacts ON
INSERT INTO [dbo].[contacts]
           (id,[user_id]
           ,[first_name]
           ,[last_name]
           ,[phone_mobile]
           ,[phone_home]
           ,[email_1]
           ,[email_2]
           ,[address])
     VALUES
           (1,'123456'
           ,'Lily'
           ,'Motola'
           ,'052-7502684'
           ,null
           ,'lily@englilush.com'
           ,null
           ,'Yitzah Rabin 5a'),
		    (2,null
           ,'principle'
           ,'principle lname'
           ,'052-7502684'
           ,'09-9545013'
           ,'principle@englilush.com'
           ,'principle2@englilush.com'
           ,'something'),
		   (3,null
           ,'secratery'
           ,'secratery lname'
           ,'052-7502684'
           ,'09-9545013'
           ,'secratery@englilush.com'
           ,'secratery@englilush.com'
           ,'something secratery')
		   ,
		   (4,null
           ,'secratery2'
           ,'secratery2 lname'
           ,'052-7502684'
           ,'09-9545013'
           ,'secratery2@englilush.com'
           ,'secratery2@englilush.com'
           ,'something secratery2'),
		  
		   (5,null
           ,'student'
           ,'student lname'
           ,'052-7502684'
           ,'09-9545013'
           ,null
           ,null
           ,'student address')
GO
	SET IDENTITY_INSERT contacts off


INSERT INTO [dbo].[branches]
           ([name]
           ,[address]
           ,[principle_contacts_id]
           ,[contact_a_contacts_id]
           ,[contact_b_contacts_id])
     VALUES
           ('Ramat Ha-Sharon B'
           ,'Somewhere in rmhash B'
           ,2
           ,3
           ,4)
GO


USE [pickmepleasedb]
GO

INSERT INTO [dbo].[students]
           ([student_concacts_id]
		   ,branch_id
           ,[grade]
           ,[class]
           ,[health_issues]
           ,[pick_up_options]
           ,[gender]
           ,[birthday],
		   parent_a_contacts_id,parent_b_contacts_id)
     VALUES
           (5
		   ,1
           ,'a'
           ,'2'
           ,'GLUTEN,SUGAR'
           ,'saba davia, safta esti'
           ,1
           ,CAST('2009-05-25' AS DATE),1,2),
		  
		   (4,2           ,'a'
           ,'2'
           ,'GLUTEN,SUGAR'
           ,'saba davia, safta esti'
           ,1
           ,CAST('2009-05-25' AS DATE),1,2
		   ),    
		   (5
		   ,2
           ,'a'
           ,'2'
           ,'GLUTEN,SUGAR'
           ,'saba davia, safta esti'
           ,1
           ,CAST('2009-05-25' AS DATE),1,2),
		  
		   (4,2           ,'a'
           ,'2'
           ,'GLUTEN,SUGAR'
           ,'saba davia, safta esti'
           ,1
           ,CAST('2009-05-25' AS DATE),1,2
		   ),

		       (1
		   ,1
           ,'a'
           ,'2'
           ,'GLUTEN,SUGAR'
           ,'saba davia, safta esti'
           ,1
           ,CAST('2009-05-25' AS DATE),1,2),
		  
		   (2,2           ,'a'
           ,'2'
           ,'GLUTEN,SUGAR'
           ,'saba davia, safta esti'
           ,1
           ,CAST('2009-05-25' AS DATE),1,2
		   ),    (5
		   ,2
           ,'a'
           ,'2'
           ,'GLUTEN,SUGAR'
           ,'saba davia, safta esti'
           ,1
           ,CAST('2009-05-25' AS DATE),1,2),
		  
		   (4,2           ,'a'
           ,'2'
           ,'GLUTEN,SUGAR'
           ,'saba davia, safta esti'
           ,1
           ,CAST('2009-05-25' AS DATE),1,2
		   )
		
		   
GO

USE [pickmepleasedb]
GO

INSERT INTO [dbo].[counslers]
           ([counsler_concacts_id]
           ,[gender]
           ,[birthday]
           ,[is_active]
           ,[allowed_branches],usernmae)
     VALUES
           (2
           ,1
           ,CAST('2009-05-25' AS DATE)
           ,1
           ,'1,2','liran1')
GO

