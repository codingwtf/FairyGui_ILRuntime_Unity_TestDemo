using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Reflection;
using Assets.Scripts;
using FairyGUI;
using ILRuntime.CLR.TypeSystem;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

public class MainScene : MonoBehaviour
{
    //AppDomain是ILRuntime的入口，最好是在一个单例类中保存，整个游戏全局就一个，这里为了示例方便，每个例子里面都单独做了一个
    //大家在正式项目中请全局只创建一个AppDomain
    AppDomain appdomain;


    void Start()
    {
        StartCoroutine(LoadHotFixAssembly());

        //UIPackage.AddPackage("LoopList");

        //GComponent view = UIPackage.CreateObject("LoopList", "Main").asCom;
        //GRoot.inst.AddChild(view);
        //view.GetChild("n0").asTextField.text = "主工程改变你";

    }

    IEnumerator LoadHotFixAssembly()
    {
        appdomain = SingleClass.AppDomain;

        //首先实例化ILRuntime的AppDomain，AppDomain是一个应用程序域，每个AppDomain都是一个独立的沙盒
        //appdomain = new ILRuntime.Runtime.Enviorment.AppDomain();
        //appdomain.DebugService.StartDebugService(56000);
        //正常项目中应该是自行从其他地方下载dll，或者打包在AssetBundle中读取，平时开发以及为了演示方便直接从StreammingAssets中读取，
        //正式发布的时候需要大家自行从其他地方读取dll

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //这个DLL文件是直接编译Unity.HotFix.sln生成的，已经在项目中设置好输出目录为StreamingAssets，在VS里直接编译即可生成到对应目录，无需手动拷贝
#if UNITY_ANDROID
        WWW www = new WWW(Application.streamingAssetsPath + "/Unity.HotFix.dll");
#else
        WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/Unity.HotFix.dll");
#endif
        while (!www.isDone)
            yield return null;
        if (!string.IsNullOrEmpty(www.error))
            UnityEngine.Debug.LogError(www.error);
        byte[] dll = www.bytes;
        www.Dispose();

        //PDB文件是调试数据库，如需要在日志中显示报错的行号，则必须提供PDB文件，不过由于会额外耗用内存，正式发布时请将PDB去掉，下面LoadAssembly的时候pdb传null即可
#if UNITY_ANDROID
        www = new WWW(Application.streamingAssetsPath + "/Unity.HotFix.pdb");
#else
        www = new WWW("file:///" + Application.streamingAssetsPath + "/Unity.HotFix.pdb");
#endif
        while (!www.isDone)
            yield return null;
        if (!string.IsNullOrEmpty(www.error))
            UnityEngine.Debug.LogError(www.error);
        byte[] pdb = www.bytes;
        System.IO.MemoryStream fs = new MemoryStream(dll);
        System.IO.MemoryStream p = new MemoryStream(pdb);
        appdomain.LoadAssembly(fs, p, new ILRuntime.Mono.Cecil.Pdb.PdbReaderProvider());
        //using (System.IO.MemoryStream fs = new MemoryStream(dll))
        //{
        //    using (System.IO.MemoryStream p = new MemoryStream(pdb))
        //    {
        //        appdomain.LoadAssembly(fs, p, new ILRuntime.Mono.Cecil.Pdb.PdbReaderProvider());
        //    }
        //}

        InitializeILRuntime();
        OnHotFixLoaded();
    }

    void InitializeILRuntime()
    {
        //这里做一些ILRuntime的注册，HelloWorld示例暂时没有需要注册的

        appdomain.DelegateManager.RegisterMethodDelegate<System.Int32, FairyGUI.GObject>();
        appdomain.DelegateManager.RegisterMethodDelegate<FairyGUI.EventContext>();
        appdomain.DelegateManager.RegisterMethodDelegate<FairyGUI.GTweener>();
        appdomain.DelegateManager.RegisterMethodDelegate<System.Object>();


        appdomain.DelegateManager.RegisterDelegateConvertor<FairyGUI.ListItemRenderer>((act) =>
        {
            return new FairyGUI.ListItemRenderer((index, item) =>
            {
                ((Action<System.Int32, FairyGUI.GObject>)act)(index, item);
            });
        });
        appdomain.DelegateManager.RegisterDelegateConvertor<FairyGUI.EventCallback0>((act) =>
        {
            return new FairyGUI.EventCallback0(() =>
            {
                ((Action)act)();
            });
        });
        appdomain.DelegateManager.RegisterDelegateConvertor<FairyGUI.EventCallback1>((act) =>
        {
            return new FairyGUI.EventCallback1((context) =>
            {
                ((Action<FairyGUI.EventContext>)act)(context);
            });
        });

        appdomain.DelegateManager.RegisterDelegateConvertor<FairyGUI.GTweenCallback1>((act) =>
        {
            return new FairyGUI.GTweenCallback1((tweener) =>
            {
                ((Action<FairyGUI.GTweener>)act)(tweener);
            });
        });
        appdomain.DelegateManager.RegisterDelegateConvertor<FairyGUI.GTweenCallback>((act) =>
        {
            return new FairyGUI.GTweenCallback(() =>
            {
                ((Action)act)();
            });
        });



        ILRuntime.Runtime.Generated.CLRBindings.Initialize(appdomain);

        //appdomain.RegisterCrossBindingAdaptor(new GCompnontAdaptor());
        appdomain.RegisterCrossBindingAdaptor(new WindowAdapter());
        appdomain.RegisterCrossBindingAdaptor(new GLoaderAdaptor());
        appdomain.RegisterCrossBindingAdaptor(new MonoBehaviourAdapter());
        appdomain.RegisterCrossBindingAdaptor(new CoroutineAdapter());
    }

    void OnHotFixLoaded()
    {
        UIObjectFactory.SetLoaderExtension(typeof(MyGLoader));

        //appdomain.Invoke("Unity.HotFix.Init2", "Init2StaticTest", null, null);
        //appdomain.Invoke("Unity.HotFix.Init", "InitTest", null, null);
        //var it = appdomain.LoadedTypes["Unity.HotFix.Init"];
        //var type = it.ReflectionType;
        //        MethodInfo method = type.GetMethod("InitTest", new Type[]{});
        //        var ctor = type.GetConstructor(new System.Type[0]);
        //        var obj = ctor.Invoke(null);
        //        method.Invoke(obj, null);

        var obj = appdomain.Instantiate("Unity.HotFix.Basics.BasicsMain");
        IType t = appdomain.LoadedTypes["Unity.HotFix.Basics.BasicsMain"];
        Type type = t.ReflectionType;
        MethodInfo method = type.GetMethod("InitTest");
        method.Invoke(obj, null);

    }




    void Update()
    {

    }
}
