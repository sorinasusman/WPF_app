using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace entitati
{
    public class Serviciu : ProdusAbstract
    {
        public Serviciu(uint id, string? nume, string? codIntern, uint price, string? category) : base(id, nume, codIntern, price, category) { }

        public Serviciu() { }

        public override string Descriere() 
        {
            return "Serviciul: " + base.Descriere();
        }
        public override bool Equals(object? obj)
        {
            if (obj is Serviciu)
            {
                Serviciu serv = (Serviciu)obj;
                return base.Equals(serv);
            }
            else
                return false;

        }

        public override bool canAddToPackage(Pachet pachet)
        {
            return true;
        }
    }
}
