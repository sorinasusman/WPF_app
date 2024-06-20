using entitati;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace App1
{
    abstract class ProduseAbstractMgr
    {
        public static List<IPackageable> elemente = new List<IPackageable>();

        protected static int CountElemente { get; set; } = 0;
        public void Write2Console()
        {
            foreach (Pachet element in elemente)
            {
                Console.WriteLine(element.Descriere());
            }

        }

        //public void save2XML(string fileName)
        //{
        //    Type[] produsAbstractTypes=new Type[2];
        //    produsAbstractTypes[0] = typeof(Produs);
        //    produsAbstractTypes[1] = typeof(Serviciu);
        //    XmlSerializer xs = new XmlSerializer(typeof(List<ProdusAbstract>),produsAbstractTypes);
        //    StreamWriter sw = new StreamWriter(fileName + ".xml");
        //    xs.Serialize(sw, elemente);
        //    sw.Close();
        //}
        //public List<ProdusAbstract> loadFromXML(string fileName)
        //{
        //    Type[] produsAbstractTypes = new Type[2];
        //    produsAbstractTypes[0] = typeof(Produs);
        //    produsAbstractTypes[1] = typeof(Serviciu);
        //    XmlSerializer xs = new XmlSerializer(typeof(List<ProdusAbstract>), produsAbstractTypes);
        //    FileStream fs = new FileStream(fileName + ".xml", FileMode.Open);
        //    XmlReader reader = new XmlTextReader(fs);
        //    List<ProdusAbstract> elem=(List<ProdusAbstract>)xs.Deserialize(reader);
        //    return elem;
        //}

    }
}
