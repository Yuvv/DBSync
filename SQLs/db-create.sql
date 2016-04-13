--Student
create table Student (
    SysId int identity(1, 1) primary key,
    name varchar(32),
    class varchar(32)
);

--Book
create table Book (
    SysId int identity(1, 1) primary key,
    name varchar(64),
    author varchar(32),
    pub_date datetime
);