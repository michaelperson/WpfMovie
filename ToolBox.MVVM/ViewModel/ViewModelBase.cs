using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ToolBox.MVVM.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected void RaisePropertyChanged<T>(Expression<Func<T>> exp)
        {
            //MemberExpression représente l'accès à un champ ou à une propriété.
            MemberExpression memberExpression = exp.Body as MemberExpression;
            if (memberExpression != null)
            {
                string PropertyName = memberExpression.Member.Name;
                RaisePropertyChanged(PropertyName);
            }
        }
        #endregion
    }
}
