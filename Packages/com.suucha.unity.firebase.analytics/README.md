# Suucha Suucha ADKU - Google Firebase Analytics

## 接入Google的 Unity 包
Google并没有在各大仓库中提供Google服务的Unity UPM包，所以要使用UPM包需要到[这里](https://developers.google.com/unity/archive)下载tarball包，存放到项目的目录下（比如GooglePackages），然后在Packages/manifest.json文件的dependencies中添加：
``` json
"dependencies": {
		"com.google.external-dependency-manager": "file:../GooglePackages/com.google.external-dependency-manager-1.2.177.tgz",
		"com.google.firebase.analytics": "file:../GooglePackages/com.google.firebase.analytics-11.3.0.tgz",
		"com.google.firebase.app": "file:../GooglePackages/com.google.firebase.app-11.3.0.tgz",
    //...
}
```
> 只需要下载和引用你需要的包，Google Firebase Analytics需要上面列出的三个包。

## 接入Suucha Unity Firebase Analytics
修改Packages/manifest.json文件在dependencies中添加：
``` json
"dependencies": {
  "com.suucha.unity.firebase.analytics":"1.0.0"，

  //...
 }
```

在实现了接口IAfterSuuchaInit的类的Execute方法中，用以下代码初始化AppsFlyer和启用AppsFlyer的事件上报器：
``` csharp
public class AfterSuuchaInit: IAfterSuuchaInit
{
    public void Execute()
    {
        //初始化Firebase
        Suucha.App.InitFirebase();
        //初始化Firebase Log Event Reproter并启用
        Suucha.App.InitFirebaseAnalyticsReporter().Use();

        //其他逻辑
        // ...
    }
}
```