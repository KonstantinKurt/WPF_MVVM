using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; //Библиотека для наблюдаемой коллекции;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input; // Библиотека для комманд;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
namespace MVVM
{
    public class ViewModel : ViewModelBase
    {
        // Все названия полей начинаются в нижнем регистре, свойства - в верхнем;
        string _text = "Let's start!";
        int _counter = 0;
        public int Get_Selected{get;set;}
        public ObservableCollection<Book> Books { get; set; } //Наблюдаемая коолекция, содержит оповещение о изменении коллекции
                                                              //т.е. добавление/удаление, но не изменении обьектов внутри
                                                              //этой коллекции;
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
        public ViewModel()
        {
            Books = new ObservableCollection<Book>
            {
                new Book{Title = "Book" + _counter,Pages = Get_random()}
            };
        }
        #region Commands      
        ICommand _get_text; // Создаю поле команды для кнопки "ОК";
        ICommand _clear_text;// Cancel;
        ICommand _add_new; //Метод добавления нового элемента в коллекцию и ListView соответственно;
        ICommand _change_pages; //Метод изменения колличества страниц в выбранном элементе ListView;
        public ICommand Get_text
        {
            get
            {
                return _get_text ?? (_get_text = new RelayCommand(() =>Text="First try MVVM "+_counter)); //Обработчик команды кнопки "ОК";
            }   // Если get_text уже создан (не равен null), то используем его, если комманда используется впервые, то создаем;
        }
        public ICommand Clear_text
        {
            get
            {
                return _clear_text ?? (_clear_text = new RelayCommand(Clear_and_Count)); 
            }
        }
        public ICommand Add_new //Добавляем элемент в коллекцию Books(команда);

        {
            get
            {
                
                return _add_new ?? (_add_new = new RelayCommand(()=>
                {
                    
                    Books.Add(new Book { Title = "Book" + _counter, Pages = Get_random() });
                }));
            }
        }
        public ICommand Сhange_pages //Меняет колличество страниц выбранного итема ListView на 1488;
        {
            get
            {
                return _change_pages ?? (_change_pages = new RelayCommand(() =>
                {
                    Books[Get_Selected].Pages = 1488;
                }));
            }
        }

        #endregion
        void Clear_and_Count()// Бредовый метод просто для проверки работы RelayCommand;
        {
            Text = "";
            _counter++;
        }
        int Get_random()
        {
            _counter++;
            Random rand = new Random();
            return rand.Next(100, 1000);
        }
        
    }
}

