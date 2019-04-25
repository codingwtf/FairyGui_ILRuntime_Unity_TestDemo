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
    unsafe class FairyGUI_EllipseMesh_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(FairyGUI.EllipseMesh);

            field = type.GetField("startDegree", flag);
            app.RegisterCLRFieldGetter(field, get_startDegree_0);
            app.RegisterCLRFieldSetter(field, set_startDegree_0);
            field = type.GetField("endDegreee", flag);
            app.RegisterCLRFieldGetter(field, get_endDegreee_1);
            app.RegisterCLRFieldSetter(field, set_endDegreee_1);


        }



        static object get_startDegree_0(ref object o)
        {
            return ((FairyGUI.EllipseMesh)o).startDegree;
        }
        static void set_startDegree_0(ref object o, object v)
        {
            ((FairyGUI.EllipseMesh)o).startDegree = (System.Single)v;
        }
        static object get_endDegreee_1(ref object o)
        {
            return ((FairyGUI.EllipseMesh)o).endDegreee;
        }
        static void set_endDegreee_1(ref object o, object v)
        {
            ((FairyGUI.EllipseMesh)o).endDegreee = (System.Single)v;
        }


    }
}
