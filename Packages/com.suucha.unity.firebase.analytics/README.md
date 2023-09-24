# Suucha Suucha ADKU - Google Firebase Analytics

## ����Google�� Unity ��
Google��û���ڸ���ֿ����ṩGoogle�����Unity UPM��������Ҫʹ��UPM����Ҫ��[����](https://developers.google.com/unity/archive)����tarball������ŵ���Ŀ��Ŀ¼�£�����GooglePackages����Ȼ����Packages/manifest.json�ļ���dependencies����ӣ�
``` json
"dependencies": {
		"com.google.external-dependency-manager": "file:../GooglePackages/com.google.external-dependency-manager-1.2.177.tgz",
		"com.google.firebase.analytics": "file:../GooglePackages/com.google.firebase.analytics-11.3.0.tgz",
		"com.google.firebase.app": "file:../GooglePackages/com.google.firebase.app-11.3.0.tgz",
    //...
}
```
> ֻ��Ҫ���غ���������Ҫ�İ���Google Firebase Analytics��Ҫ�����г�����������

## ����Suucha Unity Firebase Analytics
�޸�Packages/manifest.json�ļ���dependencies����ӣ�
``` json
"dependencies": {
  "com.suucha.unity.firebase.analytics":"1.0.0"��

  //...
 }
```

��ʵ���˽ӿ�IAfterSuuchaInit�����Execute�����У������´����ʼ��AppsFlyer������AppsFlyer���¼��ϱ�����
``` csharp
public class AfterSuuchaInit: IAfterSuuchaInit
{
    public void Execute()
    {
        //��ʼ��Firebase
        Suucha.App.InitFirebase();
        //��ʼ��Firebase Log Event Reproter������
        Suucha.App.InitFirebaseAnalyticsReporter().Use();

        //�����߼�
        // ...
    }
}
```