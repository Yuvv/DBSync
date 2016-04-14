# DBSync

## 功能描述

此程序可以用于将本地数据库与远程数据库数据同步（测试使用的是SQL Server）。

这里主要针对插入数据的同步，程序可以根据每个表里面自增类型的id字段的大小更改类检测数据的变化，然后将变化的记录查询出来再update到远程数据库。

## 程序说明

程序中包含了多个解决方案。

DBSyncClient，DBSyncServer，SyncClient，SyncServer是通过*tcp*通信来传输数据（前两个是*GUI*程序，后两个是*console*）。数据都被转化成*json*进行传输（使用了[Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json "Newtonsoft.Json")）。

DBTransport，Transport是直接远程连接到远程数据库，然后将本地得到的 *DataTable/DataSet* update到远程数据库。

DBOps是操作SQL Server的公用库。

FileParser是解析INI配置文件的公用库（这部分是在网上找的代码，修复了其中读取section中所有ident会将注释部分同样读取的bug）。

SQLs中包含了程序测试用的两个表的schema和只有主键时使用触发器来实现的sql栗子。

在配置文件中包含了数据库连接，同步周期，最后同步id的信息。程序启动后会加载其中的配置，然后进行数据库连接，根据LastID来按照周期进行更改检测和数据同步。

## 试用范围

- 需要同步的表中有可进行比较的唯一字段（如自增ID，插入时间等）。

- 需要同步的表中有主键没有但不可比较（此时使用触发器）。
