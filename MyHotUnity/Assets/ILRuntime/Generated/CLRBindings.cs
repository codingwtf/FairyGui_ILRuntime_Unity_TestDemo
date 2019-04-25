using System;
using System.Collections.Generic;
using System.Reflection;

namespace ILRuntime.Runtime.Generated
{
    class CLRBindings
    {


        /// <summary>
        /// Initialize the CLR binding, please invoke this AFTER CLR Redirection registration
        /// </summary>
        public static void Initialize(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            FairyGUI_UIPackage_Binding.Register(app);
            FairyGUI_GObject_Binding.Register(app);
            FairyGUI_Window_Binding.Register(app);
            FairyGUI_GComponent_Binding.Register(app);
            FairyGUI_GList_Binding.Register(app);
            FairyGUI_EventListener_Binding.Register(app);
            UnityEngine_Random_Binding.Register(app);
            System_String_Binding.Register(app);
            FairyGUI_GButton_Binding.Register(app);
            UnityEngine_Vector2_Binding.Register(app);
            FairyGUI_GTweener_Binding.Register(app);
            FairyGUI_EventContext_Binding.Register(app);
            FairyGUI_GLoader_Binding.Register(app);
            FairyGUI_Transition_Binding.Register(app);
            UnityEngine_Debug_Binding.Register(app);
            FairyGUI_GRoot_Binding.Register(app);
            FairyGUI_ScrollPane_Binding.Register(app);
            UnityEngine_Mathf_Binding.Register(app);
            FairyGUI_UIConfig_Binding.Register(app);
            UnityEngine_Application_Binding.Register(app);
            FairyGUI_Stage_Binding.Register(app);
            FairyGUI_DisplayObject_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_GComponent_Binding.Register(app);
            FairyGUI_Controller_Binding.Register(app);
            FairyGUI_InputEvent_Binding.Register(app);
            FairyGUI_GGraph_Binding.Register(app);
            FairyGUI_NGraphics_Binding.Register(app);
            FairyGUI_EllipseMesh_Binding.Register(app);
            FairyGUI_PolygonMesh_Binding.Register(app);
            System_Collections_Generic_List_1_Vector2_Binding.Register(app);
            FairyGUI_VertexBuffer_Binding.Register(app);
            FairyGUI_Shape_Binding.Register(app);
            UnityEngine_Color_Binding.Register(app);
            UnityEngine_Color32_Binding.Register(app);
            System_Single_Binding.Register(app);
            UnityEngine_AnimationCurve_Binding.Register(app);
            FairyGUI_LineMesh_Binding.Register(app);
            FairyGUI_GPathPoint_Binding.Register(app);
            UnityEngine_Vector3_Binding.Register(app);
            FairyGUI_GPath_Binding.Register(app);
            FairyGUI_GTween_Binding.Register(app);
            System_Type_Binding.Register(app);
            System_Enum_Binding.Register(app);
            FairyGUI_GTextField_Binding.Register(app);
            FairyGUI_GProgressBar_Binding.Register(app);
            FairyGUI_GMovieClip_Binding.Register(app);
            FairyGUI_PopupMenu_Binding.Register(app);
            UnityEngine_Rect_Binding.Register(app);
            System_Nullable_1_Rect_Binding.Register(app);
            FairyGUI_Timers_Binding.Register(app);
            FairyGUI_TweenValue_Binding.Register(app);
            FairyGUI_DragDropManager_Binding.Register(app);

            ILRuntime.CLR.TypeSystem.CLRType __clrType = null;
        }

        /// <summary>
        /// Release the CLR binding, please invoke this BEFORE ILRuntime Appdomain destroy
        /// </summary>
        public static void Shutdown(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
        }
    }
}
