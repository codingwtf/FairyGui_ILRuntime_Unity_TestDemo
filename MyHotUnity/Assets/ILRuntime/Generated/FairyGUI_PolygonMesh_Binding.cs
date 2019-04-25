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
    unsafe class FairyGUI_PolygonMesh_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(FairyGUI.PolygonMesh);

            field = type.GetField("usePercentPositions", flag);
            app.RegisterCLRFieldGetter(field, get_usePercentPositions_0);
            app.RegisterCLRFieldSetter(field, set_usePercentPositions_0);
            field = type.GetField("points", flag);
            app.RegisterCLRFieldGetter(field, get_points_1);
            field = type.GetField("texcoords", flag);
            app.RegisterCLRFieldGetter(field, get_texcoords_2);


        }



        static object get_usePercentPositions_0(ref object o)
        {
            return ((FairyGUI.PolygonMesh)o).usePercentPositions;
        }
        static void set_usePercentPositions_0(ref object o, object v)
        {
            ((FairyGUI.PolygonMesh)o).usePercentPositions = (System.Boolean)v;
        }
        static object get_points_1(ref object o)
        {
            return ((FairyGUI.PolygonMesh)o).points;
        }
        static object get_texcoords_2(ref object o)
        {
            return ((FairyGUI.PolygonMesh)o).texcoords;
        }


    }
}
