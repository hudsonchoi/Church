using System;
using System.Web.UI;
using System.Web.UI.Design;
using System.ComponentModel;

namespace Dothan.Web.Design
{

    public class DothanDataSourceDesigner : DataSourceDesigner
    {

        private DothanDataSource _control = null;
        private DothanDesignerDataSourceView _view = null;

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            _control = (DothanDataSource)component;
        }


        public override DesignerDataSourceView GetView(string viewName)
        {
            if (_view == null)
                _view = new DothanDesignerDataSourceView(this, "Default");
            return _view;
        }

     
        public override string[] GetViewNames()
        {
            return new string[] { "Default" };
        }

     
        public override void RefreshSchema(bool preferSilent)
        {
            this.OnSchemaRefreshed(EventArgs.Empty);
        }

     
        public override bool CanRefreshSchema
        {
            get { return true; }
        }

        public override bool AllowResize
        {
            get { return false; }
        }

     
        internal DothanDataSource DataSourceControl
        {
            get { return _control; }
        }

    }
}
