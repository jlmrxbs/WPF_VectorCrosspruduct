using System;
using System.Windows.Input;

namespace MVVM
{
    public class DelegateCommand : ICommand
    {
        readonly Action<object> execute;
        readonly Predicate<object> canExecute;


        public DelegateCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Kann Berechnung ausgeführt werden?
        /// </summary>
        public void CanCommandExecute()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public DelegateCommand(Action<object>execute) : this(null, execute) { }
        public bool CanExecute(object parameter) => this.canExecute?.Invoke(parameter) ?? true ;
        public void Execute(object parameter) => this.execute?.Invoke(parameter);
    }
}
