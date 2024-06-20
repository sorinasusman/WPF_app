using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace App1
{
    internal class ProduseMgr : ProduseAbstractMgr
    {
        //public void InitListafromXML()
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load("Produse.xml");
        //    XmlNodeList lista_noduri = doc.SelectNodes("/produse/Produs");
        //    foreach (XmlNode nod in lista_noduri)
        //    {
        //        string nume = nod["Nume"].InnerText;
        //        string codIntern = nod["CodIntern"].InnerText;
        //        string producator = nod["Producator"].InnerText;
        //        string pret = nod["Pret"].InnerText;
        //        string categorie = nod["Categorie"].InnerText;
        //        elemente.Add(new Produs((uint)CountElemente + 1, nume, codIntern, producator, pret, categorie));
        //    }
        //}

        public Produs ReadProdus()
        {
            //instantierea unui Produs
            Console.WriteLine("Introdu un produs");
            Console.Write("Numele:");
            string? nume = Console.ReadLine();
            Console.Write("Codul intern:");
            string? codIntern = Console.ReadLine();
            Console.Write("Producator:");
            string? producator = Console.ReadLine();
            Console.Write("Pret:");
            uint pret = uint.Parse(Console.ReadLine());
            Console.Write("Categorie:");
            string? categorie = Console.ReadLine();
            Produs prod = new Produs((uint)CountElemente, nume, codIntern, producator, pret, categorie);
            return prod;
        }

        public void ReadProduse()
        {
            Console.WriteLine("Nr. produse:");
            uint nr = uint.Parse(Console.ReadLine() ?? string.Empty); //array de produse
            for (int cnt = 0; cnt < nr; cnt++)
            {

                Produs produs = ReadProdus();
                if (!this.Contine(produs))
                    elemente.Add(produs);
            }
        }

        public bool Contine(Produs p)
        {
            bool ok = false;//presupunem ca produsul nu a fost gasit
            for (int i = 0; i < CountElemente; i++)
            {
                if (p.Equals(elemente[i]))
                    ok = true;

            }
            return ok;
        }
    }
}
