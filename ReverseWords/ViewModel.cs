using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ReverseWords
{
    class ViewModel : INotifyPropertyChanged
    {
        private string textbox1;
        private string textbox2;
        private string textbox3;
        private ObservableCollection<string> collectionwords;
        private readonly string task1Title = "Напишите в блок ниже текст, нажмите соответствующую кнопку" +
            " и программа разделит его на отдельные элементы разделяя их по пробелу";
        private readonly string task2Title = "Напишите в блок ниже текст, нажмите соответствующую кнопку" +
            " и программа перевернет порядок слов в предложении";

        #region Свойства
        public string Task1Title { get { return task1Title; } }
        public string Task2Title { get { return task2Title; } }
        public string Textbox1 
        { 
            get { return textbox1; } 
            set 
            { 
                textbox1 = value;
                OnPropertyChanged("Textbox1");
            } 
        }

        public string Textbox2
        {
            get { return textbox2; }
            set
            {
                textbox2 = value;
                OnPropertyChanged("Textbox2");
            }
        }

        public string Textbox3
        {
            get { return textbox3 = Model.ReverseWords(textbox2); }
            set
            {
                textbox3 = value;
            }
        }

        public ObservableCollection<string> Collectionwords
        {
            get 
            {
                string[] strarr = Model.DivideString(Textbox1);
                if (strarr != null)
                {
                    collectionwords = new ObservableCollection<string>();
                    foreach (string str in strarr)
                    {
                        if (string.IsNullOrEmpty(str)) continue;
                        collectionwords.Add(str);
                    }
                }
                return collectionwords; }
            set
            {
                collectionwords = value;
            }
        }
        #endregion

        #region Комманда на кнопку выполнения задания 1

        public ICommand Task1CompleteCommand { get; }
        private bool CanTask1CompleteCommandExecute(object p) => true;

        private void OnTask1CompleteCommandExecuted (object p)
        {
            OnPropertyChanged("Collectionwords");
        }


        #endregion

        #region Комманда на кнопку выполнения задания 2
        public ICommand Task2CompleteCommand { get; }
        private bool CanTask2CompleteCommandExecute(object p) => true;

        private void OnTask2CompleteCommandExecuted(object p)
        {
            OnPropertyChanged("Textbox3");
        }
        #endregion

        #region INPC
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public ViewModel()
        {
            Task1CompleteCommand = new Command(OnTask1CompleteCommandExecuted, CanTask1CompleteCommandExecute);
            Task2CompleteCommand = new Command(OnTask2CompleteCommandExecuted, CanTask2CompleteCommandExecute);
        }
    }
}
