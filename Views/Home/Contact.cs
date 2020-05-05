using System;
using System.Collections.Generic;
using System.Mvc;
using System.Text;
using System.Windows.Controls;

namespace WPFApp.Views.Home
{
    class Contact : Renderer<Border, object>
    {
        protected override void RenderCore(Controller controller, ViewDataDictionary viewBag, object model, Border mainContent)
        {
            base.RenderCore(controller, viewBag, model, mainContent);

            var signals = new object[] { 
                new MenuItemInfo { Text = "Mở khóa", Url = "UNLOCK" },
                new MenuItemInfo { Text = "Khóa", Url = "LOCK" } 
            };

            var panel = new StackPanel();
            foreach (MenuItemInfo mi in signals)
            {
                var btn = new Button {
                    Content = mi.Text,
                };
                btn.Click += (s, e) => Engine.Execute("Device/Control", mi.Url);
                panel.Children.Add(btn);
            }

            
            mainContent.Child = panel;
        }
    }
}
