using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace hegyekCLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var beolvasas = File.ReadAllLines("hegyek.csv").Skip(1);
            List<Hegycsucs> hegyek = new List<Hegycsucs>();
            foreach (var item in beolvasas)
            {
                hegyek.Add(new Hegycsucs(item));
            }


            //8.feladat
            foreach (var item in hegyek)
            {
                if (item.magassag > 950)
                {
                    Console.WriteLine($"{item.nev} {item.hegyseg} {item.magassag}");
                }
            }
            //11.feladat
            Console.WriteLine("Kérem a keresett szót:");
            string keresett=(Console.ReadLine());
            Console.WriteLine("........");
            foreach (var item in hegyek)
            {
                if (tartalmaz(item.nev, item.hegyseg, keresett))
                {
                    Console.WriteLine($"{item.nev}");
                }
            }
        }

        
        public static bool tartalmaz(string nev, string hegyseg, string keresett)
        {
            if (hegyseg.Contains(keresett) || nev.Contains(keresett))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }  
}
