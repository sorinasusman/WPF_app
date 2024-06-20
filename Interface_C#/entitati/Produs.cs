using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Produs:ProdusAbstract
    {
        public string? Producator { get; set; }
        public Produs(uint id, string? nume, string? codIntern, string? producator, uint price, string? category) : base(id, nume, codIntern, price, category) 
        { 
            Producator = producator; 
        }
        public Produs() { }
        public override string Descriere()
        {
            return "Produsul: " + base.Descriere() + "Producator: [" + Producator + "]";
        }
       public override bool canAddToPackage(Pachet pachet) 
        {
            return true; 
        }
    }
    

}
