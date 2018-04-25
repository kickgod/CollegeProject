Linux 分区管理
==
### 新建磁盘分区作为swap分区
1. 以root身份进入控制台（登录系统）<br/>
  输入 swapoff -a  以此停止所有的swap分区<br/>
2. 用fdisk命令（例：# fdisk /dev/sdb）对磁盘进行分区，添加swap分区，新建分区，在fdisk中用“t”命令将新添的分区id改为82（Linux swap类型），最后用w将操作实际写入硬盘（没用w之前的操作是无效的）。
3.  mkswap /dev/sdb2       格式化swap分区，这里的sdb2要看加完后p命令显示的实际分区设备名。
4.  swapon /dev/sdb2       启动新的swap分区。
5. 为了让系统启动时能自动启用这个交换分区，可以编辑/etc/fstab,加入下面一行：
/dev/sdb2       swap        swap        defaults        0 0
