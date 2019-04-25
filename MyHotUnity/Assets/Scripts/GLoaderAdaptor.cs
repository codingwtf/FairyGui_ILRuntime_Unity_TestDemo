using UnityEngine;
using System.Collections.Generic;
using ILRuntime.Other;
using System;
using System.Collections;
using FairyGUI;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.CLR.Method;


public class GLoaderAdaptor : CrossBindingAdaptor
{
    public override Type BaseCLRType
    {
        get
        {
            return typeof(GLoader);
        }
    }

    public override Type AdaptorType
    {
        get
        {
            return typeof(Adaptor);
        }
    }

    public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
    {
        return new Adaptor(appdomain, instance);
    }

    public class Adaptor : GLoader, CrossBindingAdaptorType
    {
        ILTypeInstance instance;
        ILRuntime.Runtime.Enviorment.AppDomain appdomain;

        public Adaptor()
        {

        }
        object[] param1 = new object[1];
        public Adaptor(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
        {
            this.appdomain = appdomain;
            this.instance = instance;
        }

        public ILTypeInstance ILInstance { get { return instance; } set { instance = value; } }

        public ILRuntime.Runtime.Enviorment.AppDomain AppDomain { get { return appdomain; } set { appdomain = value; } }

        IMethod mLoadExternalMeth;
        bool mLoadExternalMethGod;
        bool isLoadExternalInvoking = false;
        protected override void LoadExternal()
        {
            //Unity会在ILRuntime准备好这个实例前调用Awake，所以这里暂时先不掉用
            if (instance != null)
            {
                if (!mLoadExternalMethGod)
                {
                    mLoadExternalMeth = instance.Type.GetMethod("LoadExternal", 0);
                    mLoadExternalMethGod = true;
                }

                if (mLoadExternalMeth != null && !isLoadExternalInvoking)
                {
                    isLoadExternalInvoking = true;
                    appdomain.Invoke(mLoadExternalMeth, instance, null);
                    isLoadExternalInvoking = false;
                }
                else
                {
                    base.LoadExternal();
                }
            }
        }

        IMethod mFreeExternalMeth;
        bool mFreeExternalMethGod;
        bool isFreeExternalInvoking = false;
        protected override void FreeExternal(NTexture texture)
        {
            //Unity会在ILRuntime准备好这个实例前调用Awake，所以这里暂时先不掉用
            if (instance != null)
            {
                if (!mFreeExternalMethGod)
                {
                    mFreeExternalMeth = instance.Type.GetMethod("FreeExternal", 1);
                    mFreeExternalMethGod = true;
                }

                if (mFreeExternalMeth != null && !isFreeExternalInvoking)
                {
                    isFreeExternalInvoking = true;
                    param1[0] = texture;
                    appdomain.Invoke(mFreeExternalMeth, instance, null);
                    isFreeExternalInvoking = false;
                }
                else
                {
                    base.FreeExternal(texture);
                }
            }
        }

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
