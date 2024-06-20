using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public abstract class ProdusAbstract : IPackageable
    {
        private uint id;// identificator
        private String? nume;// numele produsului
        private String? codIntern;// codul Intern
        private uint price;// pret
        private String? category;// categorie

        public uint Id { get => id; set => id = value; }
        public string? Nume { get => nume; set => nume = value; }
        public string? CodIntern { get => codIntern; set => codIntern = value; }
        public uint Price { get => price; set => price = value; }
        public string? Category { get => category; set => category = value; }

        public ProdusAbstract(uint id, string? nume, string? codIntern, uint price, string? category)
        {
            Id = id;
            Nume = nume;
            CodIntern = codIntern;
            Price = price;
            Category = category;
        }

        protected ProdusAbstract(){}

        public virtual string Descriere()
        {
            return "Nume [" + this.Nume + "] " + "Cod intern [" + this.CodIntern + "] " + "Pret [" + this.Price + "] " + "Categorie [" + this.Category + "] ";
        }
        public abstract bool canAddToPackage(Pachet pachet);
    }
}
