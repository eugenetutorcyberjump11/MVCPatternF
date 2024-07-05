using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPatternF
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ContactModel
    {
        private List<Contact> contacts = new List<Contact>();

        public List<Contact> GetContacts() { return contacts; }

        public void AddContact(Contact contact) {  
            contacts.Add(contact); 
        }

        public void RemoveContact(int id)
        {
            contacts.RemoveAll(contact => contact.Id == id);
        }
    }
}
