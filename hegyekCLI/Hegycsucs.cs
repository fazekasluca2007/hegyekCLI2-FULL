using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hegyekCLI
{
    public  class Hegycsucs
    {
        public string nev { get;  private set; }
        public string hegyseg { get;  private set; }
        public int magassag { get;  private set; }

        public Hegycsucs(string nev, string hegyseg, int magassag)
        {
            this.nev = nev;
            this.hegyseg = hegyseg;
            this.magassag = magassag;
        }
        public Hegycsucs(string sor)
        {
            string[] adatok = sor.Split(';');
            this.nev = adatok[0];
            this.hegyseg = adatok[1];
            this.magassag = int.Parse(adatok[2]);
        }


    }
}
