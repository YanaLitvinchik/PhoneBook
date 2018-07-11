using PhoneBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhoneBook.Commands
{
    abstract class MyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        protected DataManager dm;
        public MyCommand(DataManager _dm)
        {
            dm = _dm;
        }
        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
