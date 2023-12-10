using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PalAnettTagokNyilvantartasa
{
    internal class Tag
    {
        public int azon;
        public string nev;
        public int szulev;
        public int iszam;
        public string orsz;

        public Tag(int azon, string nev, int szulev, int iszam, string orsz)
        {
            this.azon = azon;
            this.nev = nev;
            this.szulev = szulev;
            this.iszam = iszam;
            this.orsz = orsz;
        }
        public override string ToString()
        {
            return nev;
        }
    }
}
