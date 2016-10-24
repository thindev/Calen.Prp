using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.Prp.WPF.ViewModel
{
    public class ViewModelBase<T> : ViewModelBase
    {
        public ViewModelBase(T model)
        {
            _model = model; 
        }

        T _model;
        public T Model
        {
            get { return _model;  }
            protected set
            {
                if (!_model.Equals(value))
                {
                    _model = value;
                    RaisePropertyChanged(()=>Model);
                }
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                Set(() => IsBusy, ref _isBusy, value);
            }
        }

        bool _isBusy;
    }
}
