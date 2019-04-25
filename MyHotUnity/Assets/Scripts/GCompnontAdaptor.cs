using System;
using FairyGUI;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;

public class GCompnontAdaptor : CrossBindingAdaptor
{
    public override Type BaseCLRType
    {
        get
        {
            //如果你是想一个类实现多个Unity主工程的接口，这里需要return null;
            return typeof(GComponent); //这是你想继承的那个类
        }
    }

    public override Type[] BaseCLRTypes
    {
        get
        {
            //跨域继承只能有1个Adapter，因此应该尽量避免一个类同时实现多个外部接口，
            //ILRuntime虽然支持同时实现多个接口，但是一定要小心这种用法，使用不当很容易造成不可预期的问题
            //日常开发如果需要实现多个DLL外部接口，请在Unity这边先做一个基类实现那些个接口，然后继承那个基类
            //如需一个Adapter实现多个接口，请用下面这行
            //return new Type[] { typeof(IEnumerator<object>), typeof(IEnumerator), typeof(IDisposable) };
            return null;
        }
    }
    public override Type AdaptorType
    {
        get
        {
            return typeof(Adaptor); //这是实际的适配器类
        }
    }

    public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
    {
        return new Adaptor(appdomain, instance); //创建一个新的实例
    }
    //实际的适配器类需要继承你想继承的那个类，并且实现CrossBindingAdaptorType接口
    class Adaptor : GComponent, CrossBindingAdaptorType
    {
        ILTypeInstance instance;
        ILRuntime.Runtime.Enviorment.AppDomain appdomain;

        IMethod mConstructFromResourceMethod;
        bool mConstructFromResourceMethodGot;
        bool isConstructFromResourceInvoking = false;
        public override void ConstructFromResource()
        {
            //Unity会在ILRuntime准备好这个实例前调用Awake，所以这里暂时先不掉用
            if (instance != null)
            {
                if (!mConstructFromResourceMethodGot)
                {
                    mConstructFromResourceMethod = instance.Type.GetMethod("ConstructFromResource", 0);
                    mConstructFromResourceMethodGot = true;
                }

                if (mConstructFromResourceMethod != null && !isConstructFromResourceInvoking)
                {
                    isConstructFromResourceInvoking = true;
                    appdomain.Invoke(mConstructFromResourceMethod, instance, null);
                    isConstructFromResourceInvoking = false;
                }
                else
                {
                    base.ConstructFromResource();
                }
            }
        }

        public Adaptor()
        {

        }

        public Adaptor(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
        {
            this.appdomain = appdomain;
            this.instance = instance;
        }

        public ILTypeInstance ILInstance { get { return instance; } }

        public override string ToString()
        {
            IMethod m = appdomain.ObjectType.GetMethod("ToString", 0);
            m = instance.Type.GetVirtualMethod(m);
            if (m == null || m is ILMethod)
            {
                return instance.ToString();
            }
            else
                return instance.Type.FullName;
        }
    }
}
