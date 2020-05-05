using System;
using System.Collections.Generic;
using System.Mvc;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WPFApp.Views.Home
{
    class Default : Renderer<StackPanel, DateTime>
    {
        protected override void RenderCore(Controller controller, ViewDataDictionary viewBag, DateTime model, StackPanel mainContent)
        {
            mainContent.Children.Add(new Label { Content = viewBag["caption"] });
            mainContent.Children.Add(new Label { Content = string.Format("{0:dd-MM-yyyy}", model) });

            base.RenderCore(controller, viewBag, model, mainContent);
        }
    }
}
