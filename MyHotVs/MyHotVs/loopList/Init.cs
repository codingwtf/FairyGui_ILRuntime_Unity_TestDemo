using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using FairyGUI;

namespace Unity.HotFix
{
    public class Init
    {
        public static GList _list;
        public static GComponent _mainView;

        public Init()
        {
            Debug.Log("Unity.HotFix Init 初始话");

        }

        public static void InitTest()
        {
            Debug.Log("Unity.HotFix InitTest");

            UIPackage.AddPackage("LoopList");

            _mainView = UIPackage.CreateObject("LoopList", "Main").asCom;
            //_mainView.GetChild("n0").asTextField.text = "热更工程改变你";
            GRoot.inst.AddChild(_mainView);

            _list = _mainView.GetChild("list").asList;
            _list.SetVirtualAndLoop();

            _list.itemRenderer = RenderListItem;
            _list.numItems = 5;
            _list.scrollPane.onScroll.Add(DoSpecialEffect);
            DoSpecialEffect();

        }

        public static void DoSpecialEffect()
        {
            //change the scale according to the distance to middle
            float midX = _list.scrollPane.posX + _list.viewWidth / 2;
            int cnt = _list.numChildren;
            for (int i = 0; i < cnt; i++)
            {
                GObject obj = _list.GetChildAt(i);
                float dist = Mathf.Abs(midX - obj.x - obj.width / 2);
                if (dist > obj.width) //no intersection
                    obj.SetScale(1, 1);
                else
                {
                    float ss = 1 + (1 - dist / obj.width) * 0.24f;
                    obj.SetScale(ss, ss);
                }
            }
            _mainView.GetChild("n3").text = "" + ((_list.GetFirstChildInView() + 1) % _list.numItems);
        }

        public static void RenderListItem(int index, GObject obj)
        {
            GButton item = (GButton)obj;
            item.SetPivot(0.5f, 0.5f);
            item.icon = UIPackage.GetItemURL("LoopList", "n" + (index + 1));
        }

    }
}
