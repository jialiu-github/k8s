## Part 1 liveness probe

* 什么是存活探针？（liveness probe）
    用于检测容器是否正常运行的检测器。
* 存活探针有那三种机制？
    HTTP GET / TCP socket / Exec probe

* 创建一个.net core api 项目:
  * 该项目有个Get Api 路由时 /health， 访问到一定次数，（比如10次）的时候，返回400错误
    You can get the .net core project at ./apiForProbe
  * 将该项目发布到docker hub
    You also can get the dockerfile at ./apiForProbe. Please run the following command at this folder to build and push docker image.
    > docker build probe . 
    > docker tag probe [you dockerhub name]/probe

  * 基于该项目创建一个pod， 并且创建一个Http存活探针，探针指向 /health 接口， 该探针需要在容器启动后等待30秒再工作
    You can get apiForProbe.yaml at current dirctory.
    Please copy apiForProbe.yaml to you k8s work dirctory, and run the following command:
    > kubectl apply -f apiForProbe.yaml
  * 查看pod重启原因，
    > kubectl describe pod [api for probe pod name]


## Part 2 Replication controller

* 什么是ReplicationController
    一种资源，用于保证他所管理的pods能正常工作。
* ReplicationController 三部分都是什么？
    a label selector
    a replica count
    a pod template
* 创建一个ReplicationController, pod为上面的api项目，数量为3个
  You can get replicationController.yaml at this dirctory.
  Please copy it to your k8s work dirctory, and run the following command:
  > kubectl apply -f replicationController.yaml

  * 删除其中一个pod后，还有几个存在？
    3
  * RelicationController中的某个Pod移出/移入其作用域
    > kubectl label pod [pod name] app=move --overwrite
  * Pod移出ReplicationController的作用域后，其Pod数量是几个？
    4
  * 将Pod移入ReplicationController之后，其Pod数量是几个？
    3

* 存活探针与ReplicationController有什么区别？

* Pods被删除后，存活探针是否还起作用
否