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
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : Window
    {
        public event Action<Produs> ProductAdded;

        public List<ProdusAbstract> produse = new List<ProdusAbstract>();
        public Product(List<ProdusAbstract> products)
        {
            InitializeComponent();
            this.produse = products;
        }

        private void productButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(productNameTextBox.Text) || string.IsNullOrEmpty(internalCodeTextBox.Text) || string.IsNullOrEmpty(categorieTextBox.Text) || string.IsNullOrEmpty(priceTextBox.Text) || string.IsNullOrEmpty(producatorTextBox.Text))
            {
                MessageBox.Show("Va rog sa introduceti date!!!");
                productNameTextBox.Clear();
                internalCodeTextBox.Clear();
                categorieTextBox.Clear();
                producatorTextBox.Clear();
                priceTextBox.Clear();
                return;
            }

            if (!uint.TryParse(priceTextBox.Text, out uint price) || price == 0)
            {
                MessageBox.Show("Va rog introduceti o valoare numerica pentru pret!!!");
                productNameTextBox.Clear();
                internalCodeTextBox.Clear();
                categorieTextBox.Clear();
                producatorTextBox.Clear();
                priceTextBox.Clear();
                return;
            }

            string nume = productNameTextBox.Text;
            string codIntern = internalCodeTextBox.Text;
            string producator = producatorTextBox.Text;
            string categorie = categorieTextBox.Text;
            uint pret = uint.Parse(priceTextBox.Text);

            Produs prod = new Produs() { Nume = nume, CodIntern = codIntern, Price = pret, Category = categorie,Producator=producator };
            ProductAdded?.Invoke(prod);
            productNameTextBox.Clear();
            internalCodeTextBox.Clear();
            producatorTextBox.Clear();
            categorieTextBox.Clear();
            priceTextBox.Clear();
            MessageBox.Show("Produs adăugat!!!");
            this.Close();
        }
    }
}
