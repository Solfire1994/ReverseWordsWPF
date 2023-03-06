using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReverseWords
{
    internal class Command : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public Command (Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            execute = Execute ?? throw new ArgumentNullException (nameof(Execute));
            canExecute = CanExecute;
        }

        public bool CanExecute(object parameter) => canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => execute(parameter);
    }
}
