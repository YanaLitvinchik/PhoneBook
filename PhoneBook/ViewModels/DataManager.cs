using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using PhoneBook.Models;
using System.Collections.ObjectModel;
using PhoneBook.Commands;

namespace PhoneBook.ViewModels
{
    class DataManager : INotifyPropertyChanged
    {
        private string path;
        private XDocument doc;

        private Contact selectedContact;
        public Contact SelectedContact
        {
            get{ return selectedContact; }
            set { selectedContact = value; OnPropertyChanged("SelectedContact");}
        }
        public ObservableCollection<Contact> Contacts { get; set; }

        //Commands : 
        private AddCommand add;
        private DelCommand del;
        private SaveCommand save;

        public AddCommand Add
        {
            get
            {
                if (add == null)
                    add = new AddCommand(this);
                return add;                    
            }
        }
        public DelCommand Del
        {
            get
            {
                if (del == null)
                    del = new DelCommand(this);
                return del;
            }
        }
        public SaveCommand Save
        {
            get
            {
                if (save == null)
                    save = new SaveCommand(this);
                return save;
            }
        }

        public DataManager()
        {
            Contacts = new ObservableCollection<Contact>();
            path = @"..\..\Data\Contacts.xml";
            doc = XDocument.Load(path);
            LoadData();
        }
        public void LoadData()
        {
            var res = doc.Element("root").Elements("contact").ToList();
            foreach (var x in res)
            {
                Contact c = new Contact()
                {
                    Person = x.Attribute("person").Value,
                    Phone = x.Attribute("phone").Value,
                    Email = x.Attribute("email").Value
                };
                Contacts.Add(c);
            }
        }

        public void DelContact(Contact c)
        {
            //var res = doc.Element("root").Element("contact")
            //    .Where(x => x.Attribute("person").Value == c.Person)
            //    .FirstOrDafault();
            //if(res != null)
            //{
            //    res.Remove();
            //    doc.Save(path);
            //}
        }
        public void SaveContact(Contact c)
        {
            XElement elem = new XElement("contact",
                new XAttribute("person",c.Person), 
                new XAttribute("phone", c.Phone),
                new XAttribute("email", c.Email));
            doc.Element("root").Add(elem);
            doc.Save(path);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
