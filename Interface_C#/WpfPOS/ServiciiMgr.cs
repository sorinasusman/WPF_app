using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace App1
{
    internal class ServiciiMgr : ProduseAbstractMgr
    {

        //public void InitListafromXML()
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load("Produse.xml");
        //    XmlNodeList lista_noduri = doc.SelectNodes("/produse/Serviciu");
        //    foreach (XmlNode nod in lista_noduri)
        //    {
        //        string nume = nod["Nume"].InnerText;
        //        string codIntern = nod["CodIntern"].InnerText;
        //        string pret = nod["Pret"].InnerText;
        //        string categorie = nod["Categorie"].InnerText;
        //        elemente.Add(new Serviciu((uint)CountElemente + 1, nume, codIntern, pret, categorie));
        //    }
        //}

        public Serviciu ReadServiciu()
        {
            Console.WriteLine("Introdu un serviciu");
            Console.Write("Numele:");
            string? nume = Console.ReadLine();
            Console.Write("Codul intern:");
            string? codIntern = Console.ReadLine();
            Console.Write("Pret:");
            uint pret = uint.Parse(Console.ReadLine());
            Console.Write("Categorie:");
            string? categorie = Console.ReadLine();
            Serviciu serv = new Serviciu((uint)CountElemente, nume, codIntern, pret, categorie);
            return serv;
        }

        public void ReadServiicii()
        {
            Console.WriteLine("Nr. servicii:");
            uint nr = uint.Parse(Console.ReadLine() ?? string.Empty);//array de servicii
            for (int cnt = 0; cnt < nr; cnt++)
            {
                //instantierea unui Serviciu
                Serviciu serviciu = ReadServiciu();
                if (!this.Contine(serviciu))
                    elemente.Add(serviciu);
            }
        }
        public bool Contine(Serviciu s)
        {
            bool ok = false;//presupunem ca serviciul nu a fost gasit
            for (int i = 0; i < CountElemente; i++)
            {
                if (s.Equals(elemente[i]))
                    ok = true;

            }
            return ok;
        }
    }
}