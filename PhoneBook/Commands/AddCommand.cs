using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.ViewModels;
using PhoneBook.Models;
using System.Windows;

namespace PhoneBook.Commands
{
    class AddCommand : MyCommand
    {
        public AddCommand(DataManager _dm) : base(_dm)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            Contact c = new Contact();
            dm.SelectedContact = c;
            dm.Contacts.Add(c);
            MessageBox.Show("New contact is saved");
        }
    }
}
