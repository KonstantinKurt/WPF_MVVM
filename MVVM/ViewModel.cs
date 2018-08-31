using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
namespace MVVM
{
    public class ViewModel:ViewModelBase
    {
        string _text;
        int _counter = 0;
        public int Counter
        {
            get
            {
                return _counter;
            }
            set
            {
                
            }
        }
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                RaisePropertyChanged(() => Text);   
            }
        }
        ICommand get_text; // Создаю поле команды для кнопки "ОК";
        ICommand clear_text;// Cancel;
        public ICommand Get_text
        {
            get
            {
                return get_text ?? (get_text = new RelayCommand(() =>Text="First try MVVM"+_counter)); //Обработчик команды кнопки "ОК";
            }
        }
        public ICommand Clear_text
        {
            get
            {
                return clear_text ?? (clear_text = new RelayCommand(Clear_and_Count)); // Бредовый метод
            }
        }
        void Clear_and_Count()// Бредовый метод просто для проверки работы RelayCommand;
        {
            Text = "";
            _counter++;
        }



    }
}

