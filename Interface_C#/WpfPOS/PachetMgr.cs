using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace App1
{
    internal class PachetMgr : ProduseAbstractMgr
    {
        uint id = 0;
        public void ReadPachet()
        {
            //citeste inf. pachet
            Console.WriteLine("Introdu informatii pachet");
            Console.Write("Numele:");
            string? nume = Console.ReadLine();
            Console.Write("Codul intern:");
            string? codIntern = Console.ReadLine();
            uint pret = 0;
            Console.Write("Categorie:");
            string? categorie = Console.ReadLine();
            Pachet pachet = new Pachet(id++, nume, codIntern, pret, categorie);
            Console.WriteLine("Introduceti numarul de produse din pachet:");
            uint nrProduse = uint.Parse(Console.ReadLine());
            ProduseMgr produseMgr = new ProduseMgr();
            for (int i = 0; i < nrProduse; i++)
            {
                Produs prod = new Produs();
                prod = produseMgr.ReadProdus();
                pachet.Adauga(prod);

            }

            Console.WriteLine("Introduceti numarul de servicii din pachet:");
            uint nrServicii = uint.Parse(Console.ReadLine());
            ServiciiMgr serviciiMgr = new ServiciiMgr();
            for (int i = 0; i < nrServicii; i++)
            {
                Serviciu serv = new Serviciu();
                serv = serviciiMgr.ReadServiciu();
                pachet.Adauga(serv);
            }
            pachet.Price = pachet.totalPrice();
            elemente.Add(pachet);

        }
        public void InitListPacheteFromXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Produse.xml");

            XmlNodeList nodeList = doc.SelectNodes("/root/Pachet");

            foreach (XmlNode node in nodeList)
            {
                string nume = node["Nume"]?.InnerText;
                string codIntern = node["CodIntern"]?.InnerText;
                uint pret = uint.Parse(node["Pret"]?.InnerText ?? "0");
                string categorie = node["Categorie"]?.InnerText;

                Pachet pachet = new Pachet(id++, nume, codIntern, pret, categorie);

                XmlNodeList produseNodes = node.SelectNodes("produse/Produs");
                foreach (XmlNode serviciuNode in produseNodes)
                {
                    Produs prod = new Produs();

                    prod.Nume = serviciuNode["Nume"]?.InnerText;
                    prod.CodIntern = serviciuNode["Cod intern"]?.InnerText;
                    prod.Producator = serviciuNode["Producator"]?.InnerText;
                    prod.Price = uint.Parse(serviciuNode["Pret"]?.InnerText ?? "0");
                    prod.Category = serviciuNode["Categorie"]?.InnerText;
                    pachet.Adauga(prod);
                }

                XmlNodeList serviciiNodes = node.SelectNodes("produse/Serviciu");
                foreach (XmlNode serviciuNode in serviciiNodes)
                {
                    Serviciu serv = new Serviciu();
                    serv.Nume = serviciuNode["Nume"]?.InnerText;
                    serv.CodIntern = serviciuNode["Cod intern"]?.InnerText;
                    serv.Price = uint.Parse(serviciuNode["Pret"]?.InnerText ?? "0");
                    serv.Category = serviciuNode["Categorie"]?.InnerText;
                    pachet.Adauga(serv);
                }
                pachet.Price = pachet.totalPrice();
                elemente.Add(pachet);
            }
        }

    }
}
