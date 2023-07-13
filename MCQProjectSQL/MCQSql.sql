create table MCQProject110723 (Id int primary key identity(1,1), Question varchar(max) not null, Answer varchar(max),
Option1 varchar(150) not null,Option2 varchar(150) not null,Option3 varchar(150) not null,Option4 varchar(150) not null, IsActive bit)

drop table MCQProject110723

alter table MCQProject110723 ADD CONSTRAINT def  Default 0 for IsActive;

create table MCQProjectUser110723 (Id int primary key identity(1,1), UserName varchar(30),
QAttempted int, TotalQ int, CorrectQ int, SubmissionDate datetime)

drop table MCQProjectUser110723

--sp to add question/user

alter proc AddUserorQue

@command varchar(30)='null',
@Id int=0, @Question varchar(max)='null',@Answer varchar(max)='null',@UserName varchar(30)='null',
@QAttempted int=0, @TotalQ int=0,@CorrectQ int=0,@Option1 varchar(150)='null',
@Option2 varchar(150)='null',@Option3 varchar(150)='null',@Option4 varchar(150)='null'

as
begin
	if(@command='user')
		insert into MCQProjectUser110723 (UserName,QAttempted,TotalQ,SubmissionDate,CorrectQ) values(@UserName,@QAttempted,@TotalQ,getdate(),@CorrectQ);
	else if(@command='question')
		insert into MCQProject110723 (Question,Answer,Option1,Option2,Option3,Option4) values(@Question,@Answer,@Option1,@Option2,@Option3,@Option4)
	else
		print 'command should be provided'
end

select * from MCQProject110723



select * from MCQProjectUser110723

update MCQProject110723 set Answer='5' where Id =2