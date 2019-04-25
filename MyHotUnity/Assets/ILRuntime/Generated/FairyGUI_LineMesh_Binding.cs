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
    unsafe class FairyGUI_LineMesh_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(FairyGUI.LineMesh);

            field = type.GetField("lineWidthCurve", flag);
            app.RegisterCLRFieldGetter(field, get_lineWidthCurve_0);
            app.RegisterCLRFieldSetter(field, set_lineWidthCurve_0);
            field = type.GetField("roundEdge", flag);
            app.RegisterCLRFieldGetter(field, get_roundEdge_1);
            app.RegisterCLRFieldSetter(field, set_roundEdge_1);
            field = type.GetField("gradient", flag);
            app.RegisterCLRFieldGetter(field, get_gradient_2);
            app.RegisterCLRFieldSetter(field, set_gradient_2);
            field = type.GetField("path", flag);
            app.RegisterCLRFieldGetter(field, get_path_3);
            field = type.GetField("lineWidth", flag);
            app.RegisterCLRFieldGetter(field, get_lineWidth_4);
            app.RegisterCLRFieldSetter(field, set_lineWidth_4);
            field = type.GetField("fillEnd", flag);
            app.RegisterCLRFieldGetter(field, get_fillEnd_5);
            app.RegisterCLRFieldSetter(field, set_fillEnd_5);


        }



        static object get_lineWidthCurve_0(ref object o)
        {
            return ((FairyGUI.LineMesh)o).lineWidthCurve;
        }
        static void set_lineWidthCurve_0(ref object o, object v)
        {
            ((FairyGUI.LineMesh)o).lineWidthCurve = (UnityEngine.AnimationCurve)v;
        }
        static object get_roundEdge_1(ref object o)
        {
            return ((FairyGUI.LineMesh)o).roundEdge;
        }
        static void set_roundEdge_1(ref object o, object v)
        {
            ((FairyGUI.LineMesh)o).roundEdge = (System.Boolean)v;
        }
        static object get_gradient_2(ref object o)
        {
            return ((FairyGUI.LineMesh)o).gradient;
        }
        static void set_gradient_2(ref object o, object v)
        {
            ((FairyGUI.LineMesh)o).gradient = (UnityEngine.Gradient)v;
        }
        static object get_path_3(ref object o)
        {
            return ((FairyGUI.LineMesh)o).path;
        }
        static object get_lineWidth_4(ref object o)
        {
            return ((FairyGUI.LineMesh)o).lineWidth;
        }
        static void set_lineWidth_4(ref object o, object v)
        {
            ((FairyGUI.LineMesh)o).lineWidth = (System.Single)v;
        }
        static object get_fillEnd_5(ref object o)
        {
            return ((FairyGUI.LineMesh)o).fillEnd;
        }
        static void set_fillEnd_5(ref object o, object v)
        {
            ((FairyGUI.LineMesh)o).fillEnd = (System.Single)v;
        }


    }
}
