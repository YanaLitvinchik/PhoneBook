using PhoneBook.Models;
using PhoneBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneBook.Commands
{
    class SaveCommand :MyCommand
    {
        public SaveCommand(DataManager _dm) : base(_dm)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            Contact c = dm.SelectedContact;
            dm.SaveContact(c);
            MessageBox.Show("Saved!");
        }
    }
}
