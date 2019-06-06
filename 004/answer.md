## part1 pod
请简述：
* 什么是node？
    > node是k8s的工作节点，是k8s集群的物理基础。 //虚拟机？实体机？推荐做法？在node章节中记得回答
* 什么是pod?
    > pod是k8s的基本构建模块，是最小的部署单元。
* pod和node是什么关系？
    > pod运行在node上，一个node可运行若干pod，但是一个pod只可属于某一个node。  
    > （？不同pod属于不同的linux namespace）.
* pod和docker container是什么关系？
    > docker container运行在pod中，一个pod可以包含若干docker container。同一个pod中的container可共享资源。

基于第三次作业请回答以下问题：
* 当前集群有几个node?
    > 一个,查询命令如下：  
    > kubectl get nodes
* 当前集群有几个pod？
    > 12个，查询命令如下：  
    > kubectl get pods --all-namespaces | wc -l  
    > 得到结果减一  
    > 注：wc -l： linux命令，用于计算目标行数。
* 怎么查询asp.net core app所在的pod运行在哪个node上？
    > kubectl describe pod [pod-name]  
    > 打印出的描述中Containers列出了pod上所有的container  
    > kubectl get pods -o wide  
    > 注释：拓展：怎么查询pod上的所有container?
 
## part2 labels
请简述：
* 什么是labels？
    > 标签，可以附加到任意k8s资源上的键值对。
* labels有什么用？
    > 用于组织资源，例如用标签对资源进行分组。
    > 可根据labels指定pod部署到哪个node上。

请分别通过yaml文件和command，给任意pod加上以下标签：
hello-label=world

 > yaml文件：更改作业三中的配置如文件./yamls/label.yaml所示。然后运行命令：  
 > kubectl apply -f label.yaml

 > 命令如下：  
 > kubectl label [resource_type] [resource_identity] [label_key]=[label_value]  
 > 如：kubectl label pods [pod_id] hello-label=world

 > 请通过命令：  
 > kubectl get pods --show-labels  
 > 来验证label是否添加成功.

请分别通过yaml文件和command，将上述标签修改为：
hi-label=universe

> yaml文件：同上所述

> 命令如下：  
> kubectl label pods [pod_id] hello-label-  //删除现有标签hello-label  
> kubectl label pods [pod_id] hi-label=universe  //添加新标签

请使用command，查询：
* 含有标签"hi-label"的所有pod
    > kubectl get pods -l hi-lable --show-labels
* 不含有标签"hi-label"的所有pod
    > kubectl get pods -l '!hi-label' --show-labels
* 含有标签"hi-label"且值为"universe"的所有pod
    > kubectl get pods -l hi-label=universe --show-labels
* 含有标签"hi-lable"且值不为"universe"的所有pod
    > kubectl get pods -l hi-label!=universe --show-labels

请使用command删除含有标签"hi-label"的所有pod
> kubectl delete pods -l hi-label

## part3 namespace
请简述：
* 什么是namespace？
    > 命名空间，为对象名称提供了一个作用域，即资源名在同一个命名空间中唯一，但在不同的命名空间之间可以重复。
* namespace有什么用？
    > 同上

增
* 请分别通过yaml文件和command，创建一个名为world的namespace
    > yaml文件：./yamls/namespace.yaml，然后运行命令：
    > kubectl create -f namespace.yaml  

    > 命令如下：
    > kubectl create namespace world

* 请分布通过yaml文件和command，创建一个pod使其隶属于上述创建的namespace
    > yaml文件：./yamls/helloworld.yaml，然后运行命令：
    > kubectl create -f helloworld.yaml  

    > 命令如下：
    > kubectl run hello-world-command --image=gcr.io/hightowerlabs/helloworld:0.0.1 --namespace=world

改
* 请分别通过yaml文件和command，将上述namespace的名字修改为universe
    > namespace的name作为唯一标识符并不能被修改，如果一定要修改只能遵循以下操作：
    * 创建新namespace， kubectl create namespace universe
    * 将原namespace下的所有资源迁移到新namespace下
    * 删除原有namespace

查
* 请使用command，查询所有namespace
    > kubectl get ns
* 请使用command，查询universe中的所有pod
    > kubectl get pods -n universe

删
* 请使用command，删除universe中的所有pod，但保留该namespace
    > kubectl delete pods -n universe --all