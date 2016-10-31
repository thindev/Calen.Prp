using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.Prp.WPF.ViewModel
{
    public  interface IDialogHelper
    {
        void ShowContentDialog(object context, object Content);
        void RemoveContentDialog(object context);
    }

    public class ContentDialogResult
    {
        public ResultType ResultType { get; set; }
        public object Result { get; set; }
    }

    public enum ResultType
    {
       OK,
       Error,
       Cancel
    }
}
