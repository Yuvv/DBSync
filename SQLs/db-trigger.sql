--trigger table for student
create table trigger4student(
    SysId int identity(1,1),
    pk int,
    primary key(SysId, pk)
);

--student table's insert trigger
create trigger student_insert on student
for	insert as
begin
	declare @pk int;
	select @pk = SysId from student;
	insert into trigger4student(pk) values (@pk);
	print('ok');
end

--insert current data into trigger table
insert into trigger4student(pk) select SysId from student;


--trigger table for book
create table trigger4book(
    SysId int identity(1,1),
    pk int,
    primary key(SysId, pk)
);

--book table's insert trigger
create trigger book_insert on book
for	insert as
begin
	declare @pk int;
	select @pk = SysId from book;
	insert into trigger4book(pk) values (@pk);
	print('ok');
end

--insert current data into trigger table
insert into trigger4book(pk) select SysId from book;
