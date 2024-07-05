using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVCPatternF
{
    public class ContactController
    {
        private ContactModel model;
        private MainWindow view;

        public ContactController(ContactModel model, MainWindow view)
        {
            this.model = model;
            this.view = view;
            LoadContacts();
        }

        public void AddContact(string name, string phoneNumber){
            var newContact = new Contact()
            {
                Id = model.GetContacts().Count + 1,
                Name = name,
                PhoneNumber = phoneNumber
            };

            model.AddContact(newContact);
            LoadContacts();
        }

        public void RemoveContact(int id)
        {
            model.RemoveContact(id);
            LoadContacts();
        }

        private void LoadContacts()
        {
            view.ContactListBox.Items.Clear();
            foreach (var contact in model.GetContacts())
            {
                view.ContactListBox.Items.Add($"{contact.Name} - {contact.PhoneNumber}");
            }
        }
    }

    public partial class MainWindow : Window
    {
        private ContactController controller;
        public MainWindow()
        {
            InitializeComponent();
            var model = new ContactModel();
            controller = new ContactController(model, this);
        }

        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            controller.AddContact(NameTextBox.Text, PhoneNumberTextBox.Text);
            NameTextBox.Clear();
            PhoneNumberTextBox.Clear();
        }

    }
}