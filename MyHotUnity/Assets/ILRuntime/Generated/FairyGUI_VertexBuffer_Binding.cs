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
    unsafe class FairyGUI_VertexBuffer_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(FairyGUI.VertexBuffer);

            field = type.GetField("NormalizedUV", flag);
            app.RegisterCLRFieldGetter(field, get_NormalizedUV_0);
            app.RegisterCLRFieldSetter(field, set_NormalizedUV_0);


        }



        static object get_NormalizedUV_0(ref object o)
        {
            return FairyGUI.VertexBuffer.NormalizedUV;
        }
        static void set_NormalizedUV_0(ref object o, object v)
        {
            FairyGUI.VertexBuffer.NormalizedUV = (UnityEngine.Vector2[])v;
        }


    }
}
