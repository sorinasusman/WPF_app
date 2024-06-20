using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfPOS
{
    /// <summary>
    /// Interaction logic for Service.xaml
    /// </summary>
    public partial class Service : Window
    {
        public event Action<Serviciu> ServiceAdded;

        public List<ProdusAbstract> servicii = new List<ProdusAbstract>();
        public Service(List<ProdusAbstract> service)
        {
            InitializeComponent();
            this.servicii = service;
        }
        private void serviceButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(serviceNameTextBox.Text) || string.IsNullOrEmpty(internalCodeTextBox.Text) || string.IsNullOrEmpty(categorieTextBox.Text) || string.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Va rog sa introduceti date!!!");
                serviceNameTextBox.Clear();
                internalCodeTextBox.Clear();
                categorieTextBox.Clear();
                priceTextBox.Clear();
                return;
            }

            if (!uint.TryParse(priceTextBox.Text, out uint price) || price == 0)
            {
                MessageBox.Show("Va rog introduceti o valoare pentru pret!!!");
                serviceNameTextBox.Clear();
                internalCodeTextBox.Clear();
                categorieTextBox.Clear();
                priceTextBox.Clear();
                return;
            }

            string nume = serviceNameTextBox.Text;
            string codIntern = internalCodeTextBox.Text;
            string categorie = categorieTextBox.Text;
            uint pret = uint.Parse(priceTextBox.Text);

            Serviciu serv = new Serviciu() { Nume = nume, CodIntern = codIntern, Price = pret, Category = categorie};
            ServiceAdded?.Invoke(serv);
            serviceNameTextBox.Clear();
            internalCodeTextBox.Clear();
            categorieTextBox.Clear();
            priceTextBox.Clear();
            MessageBox.Show("Serviciu adăugat!!!");
            this.Close();
        }
    }
}
