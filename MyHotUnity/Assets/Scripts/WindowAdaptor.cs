using UnityEngine;
using System.Collections.Generic;
using ILRuntime.Other;
using System;
using System.Collections;
using FairyGUI;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.CLR.Method;


public class WindowAdapter : CrossBindingAdaptor
{
    public override Type BaseCLRType
    {
        get
        {
            return typeof(Window);
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

    public class Adaptor : Window, CrossBindingAdaptorType
    {
        ILTypeInstance instance;
        ILRuntime.Runtime.Enviorment.AppDomain appdomain;

        public Adaptor()
        {

        }

        public Adaptor(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
        {
            this.appdomain = appdomain;
            this.instance = instance;
        }

        public ILTypeInstance ILInstance { get { return instance; } set { instance = value; } }

        public ILRuntime.Runtime.Enviorment.AppDomain AppDomain { get { return appdomain; } set { appdomain = value; } }

        IMethod mOnInitMethod;
        bool mOnInitMethodGot;
        bool isOnInitInvoking = false;
        protected override void OnInit()
        {
            //Unity会在ILRuntime准备好这个实例前调用Awake，所以这里暂时先不掉用
            if (instance != null)
            {
                if (!mOnInitMethodGot)
                {
                    mOnInitMethod = instance.Type.GetMethod("OnInit", 0);
                    mOnInitMethodGot = true;
                }

                if (mOnInitMethod != null && !isOnInitInvoking)
                {
                    isOnInitInvoking = true;
                    appdomain.Invoke(mOnInitMethod, instance, null);
                    isOnInitInvoking = false;
                }
                else
                {
                    base.OnInit();
                }
            }
        }

        IMethod mOnShownMethod;
        bool mOnShowMethodGot;
        bool isOnShownInvoking = false;
        protected override void OnShown()
        {
            if (instance != null)
            {
                if (!mOnShowMethodGot)
                {
                    mOnShownMethod = instance.Type.GetMethod("OnShown", 0);
                    mOnShowMethodGot = true;
                }

                if (mOnShownMethod != null && !isOnShownInvoking)
                {
                    isOnShownInvoking = true;
                    appdomain.Invoke(mOnShownMethod, instance, null);
                    isOnShownInvoking = false;
                }
                else
                {
                    base.OnShown();
                }
            }
        }

        IMethod mOnHideMethod;
        bool mOnHideMethodGot;
        bool isOnHideInvoking = false;
        protected override void OnHide()
        {
            if (instance != null)
            {
                if (!mOnHideMethodGot)
                {
                    mOnHideMethod = instance.Type.GetMethod("OnHide", 0);
                    mOnHideMethodGot = true;
                }

                if (mOnHideMethod != null && !isOnHideInvoking)
                {
                    isOnHideInvoking = true;
                    appdomain.Invoke(mOnHideMethod, instance, null);
                    isOnHideInvoking = false;
                }
                else
                {
                    base.OnHide();
                }
            }
        }


        IMethod mDoShowAnimationMethod;
        bool mDoShowAnimationMethodGot;
        bool isDoShowAnimationInvoking = false;

        protected override void DoShowAnimation()
        {
            if (!mDoShowAnimationMethodGot)
            {
                mDoShowAnimationMethod = instance.Type.GetMethod("DoShowAnimation", 0);
                mDoShowAnimationMethodGot = true;
            }

            if (mDoShowAnimationMethod != null && !isDoShowAnimationInvoking)
            {
                isDoShowAnimationInvoking = true;
                appdomain.Invoke(mDoShowAnimationMethod, instance, null);
                isDoShowAnimationInvoking = false;
            }
            else
            {
                base.DoShowAnimation();
            }
        }

        IMethod mDoHideAnimationMethod;
        bool mDoHideAnimationMethodGot;
        bool isDoHideAnimationInvoking = false;

        protected override void DoHideAnimation()
        {
            if (!mDoHideAnimationMethodGot)
            {
                mDoHideAnimationMethod = instance.Type.GetMethod("DoHideAnimation", 0);
                mDoHideAnimationMethodGot = true;
            }

            if (mDoHideAnimationMethod != null && !isDoHideAnimationInvoking)
            {
                isDoHideAnimationInvoking = true;
                appdomain.Invoke(mDoHideAnimationMethod, instance, null);
                isDoHideAnimationInvoking = false;
            }
            else
            {
                base.DoHideAnimation();
            }
        }


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
