--sillytable0备份表
create table trigger4sillytable0 (
	sysid int identity(1,1) primary key,
	upkidcol0 int not null,
	col1 datetime,
	col2 int,
	col3 float,
	col4 float,
	col5 float
);

--sillytable0表的insert触发器
create trigger sillytable0_insert on sillytable0
for insert as
begin
	insert into trigger4sillytable0 (upkidcol0, col1, col2, col3, col4, col5)
	select upkidcol0, col1, col2, col3, col4, col5 from inserted;
end

--将sillytable0表中已有数据存入备份表
insert into trigger4sillytable0 (upkidcol0, col1, col2, col3, col4, col5)
	select upkidcol0, col1, col2, col3, col4, col5 from sillytable0;
