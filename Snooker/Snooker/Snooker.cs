using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snooker
{
    class Snooker
    {
        static List<Vilagranglista> vilaglista = new List<Vilagranglista>();
        static void Main(string[] args)
        {
            Console.WriteLine("2.feladat:snooker.txt beolvasása");
            Beolvasas("snooker.txt");
            Console.WriteLine($"\n3.feladat:A világranglistán {vilaglista.Count} versenyző szerepel");
            Console.WriteLine($"\n4.feladat:A verenyzők átlagosan {vilaglista.Average(a =>a.Nyeremeny) :N2} fontot kerestek");
            Console.WriteLine("\n5.feladat:A legjobb kereső kínai versenyző");
            int legjobbkinai = vilaglista.Where(a => a.Orszag.Equals("Kína")).Max( b => b.Nyeremeny);
            Vilagranglista legjobb=vilaglista.Find(c => c.Nyeremeny==legjobbkinai);
            Console.WriteLine($"\tHelyezés:{legjobb.Helyezes}");
            Console.WriteLine($"\tNév:{legjobb.Nev}");
            Console.WriteLine($"\tOrszág:{legjobb.Orszag}");
            Console.WriteLine($"\tNyeremény összege:{(legjobb.Nyeremeny*380).ToString("#,##0")} FT");
            string norveg = "";
            if (vilaglista.Find( d => d.Orszag.Equals("Norvégia"))==null)
            {
                norveg = "A versenyzők között nincs norvég versenyző";
            }
            else
            {
                norveg = "A versenyzők között van norvég versenyző";
            }
            Console.WriteLine($"\n6.feladat:"+norveg);
            Console.WriteLine("\n7.feladat:Statisztika");
            var orszagok = vilaglista.GroupBy(a => a.Orszag).Select(b => new {o = b.Key , db= b.Count()}).Where(g =>g.db>4);
            foreach (var item in orszagok)
            {
                Console.WriteLine($"\t{item.o}-{item.db} fő");
            }
            Console.WriteLine("\nProgram vége:");
            Console.ReadLine();
        }
        static void Beolvasas(string filenev)
        {
            using (StreamReader sr=new StreamReader(filenev,Encoding.Default))
            {
                string fejlec = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                   
                    Vilagranglista v = new Vilagranglista(sr.ReadLine());
                    vilaglista.Add(v);
                }
                sr.Close();
            }
        }
    }
}
