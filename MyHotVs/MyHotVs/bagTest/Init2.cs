using UnityEngine;
using FairyGUI;

namespace Unity.HotFix
{
    public class Init2
    {
        static GComponent _mainView;
        static BagWindow _bagWindow;
        public static void Init2StaticTest()
        {
            Debug.Log("Init2StaticTest ");

            UIPackage.AddPackage("Bag");


            _mainView = UIPackage.CreateObject("Bag", "Main").asCom;
            GRoot.inst.AddChild(_mainView);

            _bagWindow = new BagWindow();
            _mainView.GetChild("bagBtn").onClick.Add(() => { _bagWindow.Show(); });
        }
    }
}