using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
namespace MVVM
{
    public class Book : ObservableObject // Наследуем Books от ObservableObject для того, чтобы иметь возможность 
                                         // просматривать изменения внутри обьекта, для этого создано свойство Pages
                                         // которое оповещает о своем изменении;
    {
        private int _pages;

        public string Title { get; set; }
        public int Pages
        {
            get
            {
                return _pages;
            }
            set
            {
                _pages = value;
                RaisePropertyChanged(() => Pages);
            }
        }
        public Book()
        {
        }
    }
}
