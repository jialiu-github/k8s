本次练习请对照《k8s in action》第三章.
请将本次练习答案上传至github远端仓库.

part1 pod
请简述：
* 什么是node？
* 什么是pod?
* pod和node是什么关系？
* pod和docker container是什么关系？

基于第三次作业请回答以下问题：
* 当前集群有几个node?
* 当前集群有几个pod？
* 怎么查询asp.net core app所在的pod运行在哪个node上？

part2 labels
请简述：
* 什么是labels？
* labels有什么用？

请分别通过yaml文件和command，给任意pod加上以下标签：
hello-label=world

请分别通过yaml文件和command，将上述标签修改为：
hi-label=universe

请使用command，查询：
* 含有标签"hi-label"的所有pod
* 不含有标签"hi-label"的所有pod
* 含有标签"hi-lable"且值为"universe"的所有pod
* 含有标签"hi-lable"且值不为"universe"的所有pod

请使用command删除含有标签"hi-label"的所有pod

part3 namespace
请简述：
* 什么是namespace？
* namespace有什么用？

增
* 请分别通过yaml文件和command，创建一个名为world的namespace
* 请分布通过yaml文件和command，创建一个pod使其隶属于上述创建的namespace

改
* 请分别通过yaml文件和command，将上述namespace的名字修改为universe

查
* 请使用command，查询所有namespace
* 请使用command，查询universe中的所有pod

删
* 请使用command，删除universe中的所有pod，但保留该namespace
