using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker
{
    class Vilagranglista
    {
        //Helyezes;Nev;Orszag;Nyeremeny
        private int helyezes;
        private string nev;
        private string orszag;
        private int nyeremeny;

        public int Helyezes { get => helyezes; set => helyezes = value; }
        public string Nev { get => nev; set => nev = value; }
        public string Orszag { get => orszag; set => orszag = value; }
        public int Nyeremeny { get => nyeremeny; set => nyeremeny = value; }

        public Vilagranglista(int helyezes, string nev, string orszag, int nyeremeny)
        {
            Helyezes = helyezes;
            Nev = nev;
            Orszag = orszag;
            Nyeremeny = nyeremeny;
        }
        public Vilagranglista(string sor)
        {
            string[] adatok = sor.Split(';');
            Helyezes = int.Parse(adatok[0]);
            Nev = adatok[1];
            Orszag = adatok[2];
            Nyeremeny = int.Parse(adatok[3]);
        }
    }
}
