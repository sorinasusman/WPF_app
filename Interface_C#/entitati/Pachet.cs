using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace entitati
{
    public class Pachet:ProdusAbstract
    {
        public List<IPackageable> elem_pachet= new List<IPackageable>();

        public Pachet(uint id, string? nume, string? codIntern, uint price, string? category) : base(id, nume, codIntern, price, category)
        {
        }
        public Pachet() { }
        public void Adauga(IPackageable prod)
        {
          
                if (prod.canAddToPackage(this))
                    elem_pachet.Add(prod);
   
        }
        public override bool canAddToPackage(Pachet pachet)
        {
            return true;
        }

        public override string Descriere()
        {
            //string ret = String.Empty;
            //ret += 
            return "Pachetul: " + base.Descriere();
            //foreach (ProdusAbstract elem in elem_pachet)
            //{
            //    ret += elem.Descriere()+ "\n  ";
            //}
            //return ret;
        }
        public uint totalPrice()
        {
            uint price = 0;
            foreach (ProdusAbstract elem in elem_pachet)
            {
                price += elem.Price;
            }
            return price;
        }

    }
}
