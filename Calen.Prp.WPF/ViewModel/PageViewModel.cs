using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Calen.Prp.WPF.ViewModel
{
    public class PageViewModel:ViewModelBase
    {
        int _index;
        object _content;
        string _title;
        Geometry _iconGeometry;

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                Set(() => Title, ref _title, value);
            }
        }

        public int Index
        {
            get
            {
                return _index;
            }

            set
            {
                Set(() => Index, ref _index, value);
            }
        }

        public object Content
        {
            get
            {
                return _content;
            }

            set
            {
                Set(() => Content, ref _content, value);
            }
        }

        public Geometry IconGeometry
        {
            get
            {
                return _iconGeometry;
            }
            set
            {
                Set(() => IconGeometry, ref _iconGeometry, value);
            }
        }
    }
}
