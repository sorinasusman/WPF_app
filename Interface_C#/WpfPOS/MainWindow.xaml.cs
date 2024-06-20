using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WpfPOS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<ProdusAbstract> packs = new List<ProdusAbstract>();//retine pachetele, produsele si serviciile
        private int productsAddedCount = 0;
        private int servicesAddedCount = 0;
        private int nrProduse;//produse de adaugat
        private int nrServicii;//servicii de adaugat

        public MainWindow()
        {
            InitializeComponent();
        }

        private void addpackageButton_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(packageNameTextBox.Text) || string.IsNullOrEmpty(internalCodeTextBox.Text) || string.IsNullOrEmpty(categoryTextBox.Text) || string.IsNullOrEmpty(priceTextBox.Text)) {
                MessageBox.Show("Va rog sa introduceti date!!!");
                packageNameTextBox.Clear();
                internalCodeTextBox.Clear();
                categoryTextBox.Clear();
                priceTextBox.Clear();
                numberOfProductsTextBox.Clear();
                numberOfServicesTextBox.Clear();
                return;
            }

            if (!uint.TryParse(priceTextBox.Text, out uint price) || price == 0) {
                MessageBox.Show("Va rog introduceti o valoare numerica pentru pret!!!");
                return;
            }

            if (!int.TryParse(numberOfProductsTextBox.Text, out nrProduse) || nrProduse == 0) {
                MessageBox.Show("Va rog introduceti o valoare numerica pentru numarul de produse!!!");
                return;
            }

            if (!int.TryParse(numberOfServicesTextBox.Text, out nrServicii) || nrServicii == 0) {
                MessageBox.Show("Va rog introduceti o valoare numerica pentru numarul de servicii!!!");
                return;
            }

            string nume = packageNameTextBox.Text;
            string codIntern = internalCodeTextBox.Text;
            string categorie = categoryTextBox.Text;
            uint pret = uint.Parse(priceTextBox.Text);
            nrProduse = int.Parse(numberOfProductsTextBox.Text);
            nrServicii = int.Parse(numberOfServicesTextBox.Text);


            productsAddedCount = 0; // reseteaza contorul
            servicesAddedCount = 0; // reseteaza contorul


            Pachet pach = new Pachet() { Nume = nume, CodIntern = codIntern, Price = pret, Category = categorie, };
            packs.Add(pach);
            DisplayPack();
            packageNameTextBox.Clear();
            internalCodeTextBox.Clear();
            categoryTextBox.Clear();
            priceTextBox.Clear();
            numberOfProductsTextBox.Clear();
            numberOfServicesTextBox.Clear();
            MessageBox.Show("Pachet adăugat!!! Acum puteti adauga produsele si serviciile dorite.");

        }

        private void addproductButton_Click(object sender, RoutedEventArgs e)
        {
            AddProduct();
            
        }

        private void AddProduct()//rol functie:pentru a nu putea introduce produse inainte de a adauga un pachet
        {
            if (nrProduse == 0)
                MessageBox.Show("Introduceti un pachet!!! " + nrProduse);

            else
            {
                if (productsAddedCount < nrProduse)//introducere produse in functie de numarul introdus in textboxul din pagina Package manager
                {
                    Product produs = new Product(packs);
                    produs.ProductAdded += ProductAddedHandler;
                    produs.ShowDialog();

                    productsAddedCount++;
                }
                else MessageBox.Show("Ati adaugat deja toate produsele!!!");//atentionare in cazul in care vor sa se introduca mai multe produse
            }
        }

        private void ProductAddedHandler(Produs produs)
        {
            packs.Add(produs);
            DisplayPack();
        }

        private void addserviceButton_Click(object sender, RoutedEventArgs e)
        {
            AddService();
        }

        private void AddService()
        {
            if (nrServicii == 0)
                MessageBox.Show("Introduceti un pachet!!!");
            else {
                if (servicesAddedCount < nrServicii)
                {
                    Service serviciu = new Service(packs);
                    serviciu.ServiceAdded += ServiceAddedHandler;
                    serviciu.ShowDialog();

                    servicesAddedCount++;
                }
            
                else MessageBox.Show("Ati adaugat deja toate serviciile!!!");//atentionare in cazul in care vor sa se introduca mai multe servicii
                 }

        }

        private void ServiceAddedHandler(Serviciu serviciu)
        {
            packs.Add(serviciu);
            DisplayPack();
        }

        private void DisplayPack()
        {
            packagesListBox.Items.Clear();

            foreach (ProdusAbstract pachet in packs)
            {
                //string descriere = "Pachet " + "Nume [" + pachet.Nume + "] " + "Cod intern [" + pachet.CodIntern + "] " + "Pret [" + pachet.Price + "] " + "Categorie [" + pachet.Category + "] ";
                packagesListBox.Items.Add(pachet.Descriere());
            }
        }

        
    }
}
