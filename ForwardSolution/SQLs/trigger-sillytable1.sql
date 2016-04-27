--sillytable1备份表
create table trigger4sillytable1 (
	uid int identity(1,1) primary key,
	upkidcol0 int not null,
	col1 int,
	col2 int,
	col3 int,
	col4 int,
	col5 nvarchar(100)
);

--RMF表的insert触发器
create trigger sillytable1_insert on sillytable1
for insert as
begin
	insert into trigger4sillytable1 (upkidcol0, col1, col2, col3, col4, col5)
	select upkidcol0, col1, col2, col3, col4, col5 from inserted;
end

--将sillytable1中已有数据存入备份表
insert into trigger4sillytable1 (upkidcol0, col1, col2, col3, col4, col5)
	select upkidcol0, col1, col2, col3, col4, col5 from sillytable1;
