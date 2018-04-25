Linux 定时执行命令 
===
#### 1. at  [选项参数]  [时间]
>选项参数
* -c      显示即将执行任务的细节             <code>实例: at -c 1 查看任务号为1的任务细节</code>
* -d      用任务id号删除指定的任务           <code>实例: at -d 1 删除任务</code>
* -l       等同于atq，用job的id号显示指定的未删除而待执行的任务
#### 2. at 指定一个将要执行的计划  【备注】结束编写时按 Ctrl+D 不需要敲打<EOT>
*  at实例
  >[root@izn4pjam1xnbipz bins]# at now +1 minutes <br> 
  >at> touch website.txt<br> 
  >at> \<EOT\> <br> 
  >job 8 at Wed Apr 25 20:50:00 2018
* at唯一问题: 时间格式
>at命令格式
at HH:MM YYYY-MM-DD //HH（小时）:MM（分钟） YYYY（年）-MM（月份）-DD（日）<br> 
例:at 4:00 2004-11-27<br> 
HH[am pm]+D(天) days //HH（小时）[am（上午）pm（下午）]+days（天）<br> 
例:4pm + 3days :3天以后下午4:00执行at命令设定的计划任务。
