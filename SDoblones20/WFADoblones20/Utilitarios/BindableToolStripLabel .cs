using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFADoblones20.Utilitarios
{
    public class BindableToolStripLabel : ToolStripLabel, IBindableComponent
    {
        #region IBindableComponent Members

        private BindingContext bindingContext;
        private ControlBindingsCollection dataBindings;

        public BindingContext BindingContext
        {
            get
            {
                if (bindingContext == null)
                {
                    bindingContext = new BindingContext();
                }
                return bindingContext;
            }
            set
            {
                bindingContext = value;
            }
        }

        public ControlBindingsCollection DataBindings
        {
            get
            {
                if (dataBindings == null)
                {
                    dataBindings = new ControlBindingsCollection(this);
                }
                return dataBindings;
            }
        }

        #endregion
    }

}
