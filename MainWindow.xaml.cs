using System;
using System.Collections.Generic;
using System.Linq;
using System.Mvc;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var navItems = new object[] {
                new MenuItemInfo { Text = "Home", Url = "Home" },
                new MenuItemInfo { Text = "Contact", Url = "Home/Contact" },
            };

            foreach (MenuItemInfo mi in navItems)
            {
                var btn = new Button { 
                    Content = mi.Text,
                    Margin = new Thickness(20, 5, 20, 5),
                };
                btn.Click += (s, e) => Engine.Execute(mi.Url);
                navContent.Children.Add(btn);
            }    

            System.Mvc.Engine.Register(this, result => { 
                if (result == null || result.Handled) { return; }
                var renderer = result.View as Views.IRenderer;
                var control = renderer.GetViewResult() as UIElement;

                if (control != null)
                {
                    mainContent.Child = control;
                }    
            });
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            Engine.Execute("Home");
        }
    }
}
