using System;
using System.Collections.Generic;
using System.Text;

namespace WPFApp.Views
{
    interface IRenderer
    {
        object GetViewResult();
    }
    class Renderer<TView, TModel> : System.Mvc.IView, IRenderer
        where TView : System.Windows.UIElement, new()
    {
        TView _mainContent;
        public TView MainContent => _mainContent;
        protected virtual TView CreateMainContent() { return new TView(); }
        public virtual object GetViewResult()
        {
            return _mainContent;
        }
        public virtual void Render(System.Mvc.Controller controller)
        {
            _mainContent = CreateMainContent();
            this.RenderCore(controller, controller.ViewData, (TModel)controller.ViewData.Model, _mainContent);
        }
        protected virtual void RenderCore(
            System.Mvc.Controller controller, 
            System.Mvc.ViewDataDictionary viewBag,
            TModel model,
            TView mainContent)
        {

        }
    }

    class FormRenderer<TView, TModel> : Renderer<TView, TModel>
        where TView: System.Windows.Window, new()
    {
        public override object GetViewResult()
        {
            MainContent.ShowDialog();
            return null;
        }
    }    
}
