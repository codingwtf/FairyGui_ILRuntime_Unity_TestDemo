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
    unsafe class FairyGUI_EventContext_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(FairyGUI.EventContext);
            args = new Type[]{};
            method = type.GetMethod("get_sender", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_sender_0);
            args = new Type[]{};
            method = type.GetMethod("get_inputEvent", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_inputEvent_1);
            args = new Type[]{};
            method = type.GetMethod("PreventDefault", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, PreventDefault_2);

            field = type.GetField("data", flag);
            app.RegisterCLRFieldGetter(field, get_data_0);
            app.RegisterCLRFieldSetter(field, set_data_0);


        }


        static StackObject* get_sender_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            FairyGUI.EventContext instance_of_this_method = (FairyGUI.EventContext)typeof(FairyGUI.EventContext).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.sender;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_inputEvent_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            FairyGUI.EventContext instance_of_this_method = (FairyGUI.EventContext)typeof(FairyGUI.EventContext).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.inputEvent;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* PreventDefault_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            FairyGUI.EventContext instance_of_this_method = (FairyGUI.EventContext)typeof(FairyGUI.EventContext).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.PreventDefault();

            return __ret;
        }


        static object get_data_0(ref object o)
        {
            return ((FairyGUI.EventContext)o).data;
        }
        static void set_data_0(ref object o, object v)
        {
            ((FairyGUI.EventContext)o).data = (System.Object)v;
        }


    }
}
