using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolBox.MVVM.ViewModel
{
    public abstract class ViewModelCollectionBase<T> : ViewModelBase
        where T : class
    {               
        private ObservableCollection<T> _Items = null;
        private T _SelectedItem = null;

        public ObservableCollection<T> Items {
            get { return _Items = _Items ?? ChargerItems(); }
        }

        public T SelectedItem {
            get { return _SelectedItem; }
            set {
                if (_SelectedItem != value) {
                    _SelectedItem = value;
                    RaisePropertyChanged(() => SelectedItem);
                }
            }
        }

        protected abstract ObservableCollection<T> ChargerItems();
    }
}

