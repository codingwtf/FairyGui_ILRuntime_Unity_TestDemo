using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class FairyGUI_GList_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(FairyGUI.GList);
            args = new Type[]{};
            method = type.GetMethod("get_onClickItem", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_onClickItem_0);
            args = new Type[]{typeof(System.Int32)};
            method = type.GetMethod("set_numItems", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_numItems_1);
            args = new Type[]{};
            method = type.GetMethod("RemoveChildrenToPool", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, RemoveChildrenToPool_2);
            args = new Type[]{};
            method = type.GetMethod("AddItemFromPool", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, AddItemFromPool_3);
            args = new Type[]{};
            method = type.GetMethod("SetVirtualAndLoop", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, SetVirtualAndLoop_4);
            args = new Type[]{};
            method = type.GetMethod("get_numItems", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_numItems_5);

            field = type.GetField("itemRenderer", flag);
            app.RegisterCLRFieldGetter(field, get_itemRenderer_0);
            app.RegisterCLRFieldSetter(field, set_itemRenderer_0);


        }


        static StackObject* get_onClickItem_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            FairyGUI.GList instance_of_this_method = (FairyGUI.GList)typeof(FairyGUI.GList).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.onClickItem;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* set_numItems_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Int32 @value = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            FairyGUI.GList instance_of_this_method = (FairyGUI.GList)typeof(FairyGUI.GList).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.numItems = value;

            return __ret;
        }

        static StackObject* RemoveChildrenToPool_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            FairyGUI.GList instance_of_this_method = (FairyGUI.GList)typeof(FairyGUI.GList).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.RemoveChildrenToPool();

            return __ret;
        }

        static StackObject* AddItemFromPool_3(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            FairyGUI.GList instance_of_this_method = (FairyGUI.GList)typeof(FairyGUI.GList).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.AddItemFromPool();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* SetVirtualAndLoop_4(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            FairyGUI.GList instance_of_this_method = (FairyGUI.GList)typeof(FairyGUI.GList).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.SetVirtualAndLoop();

            return __ret;
        }

        static StackObject* get_numItems_5(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            FairyGUI.GList instance_of_this_method = (FairyGUI.GList)typeof(FairyGUI.GList).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.numItems;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }


        static object get_itemRenderer_0(ref object o)
        {
            return ((FairyGUI.GList)o).itemRenderer;
        }
        static void set_itemRenderer_0(ref object o, object v)
        {
            ((FairyGUI.GList)o).itemRenderer = (FairyGUI.ListItemRenderer)v;
        }


    }
}
