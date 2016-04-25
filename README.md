# DBSync

由于原有的设计的两套程序都是假定数据同步的双方至少有一方是有公网IP的，否则无法访问。但是实际需求的环境并无法满足条件，所以只好考虑了另一套方案（*ForwardSolution*），利用中间服务器来转发数据。这个故事告诉我们：

> 在方案设计好写程序之前一定要问清楚前提条件是否能满足

原有两个方案还有各种bug，ForwardSolution的完成度较高，如果有需要可以直接看这个方案。[传送门](https://github.com/Yuvv/DBSync/tree/master/ForwardSolution "ForwardSolution")

## 功能描述

此程序可以用于将本地数据库与远程数据库数据同步（测试使用的是SQL Server）。

这里主要针对插入数据的同步，程序可以根据每个表里面自增类型的id字段的大小更改类检测数据的变化，然后将变化的记录查询出来再update到远程数据库。

## 程序说明

程序中包含了多个解决方案。

- DBSyncClient，DBSyncServer，SyncClient，SyncServer是通过*tcp*通信来传输数据（前两个是*GUI*程序，后两个是*console*）。数据都被转化成*json*进行传输（使用了[Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json "Newtonsoft.Json")）。
- DBTransport，Transport是直接远程连接到远程数据库，然后将本地得到的 *DataTable/DataSet* update到远程数据库。
- DBOps是操作SQL Server的公用库。
- FileParser是解析INI配置文件的公用库（这部分是在网上找的代码，修复了其中读取section中所有ident会将注释部分同样读取的bug）。
- SQLs中包含了程序测试用的两个表的schema和只有主键时使用触发器来实现的sql栗子。
在配置文件中包含了数据库连接，同步周期，最后同步id的信息。程序启动后会加载其中的配置，然后进行数据库连接，根据LastID来按照周期进行更改检测和数据同步。

## 试用范围

- 需要同步的表中有可进行比较的唯一字段（如自增ID，插入时间等）。
- 需要同步的表中有主键但不可比较（此时可使用触发器，但**推荐使用SQL Server自带复制技术**）。
- 需要同步的表中没有可比较唯一字段也没有主键（此时使用触发器）

## 其它

可能你已经知道了，现在许多数据库本身是支持远程同步的，但是一般来说限制比较多，比如SQL Server，它要求同步的表必须包含主键，两服务器能够浮想访问，不能使用IP，hostname等。*MSSQL-SYNC.docx* 是我自己写的一个SQL Server2005的远程同步配置文档。

如果你的服务器可以开远程连接，数据库中各个表都有主键，或者可以更改表结构以添加主键，那么毫不犹豫的使用这种方式吧！:smiley: