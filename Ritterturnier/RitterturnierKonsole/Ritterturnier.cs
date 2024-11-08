using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitterturnierKonsole
{
    public class Ritterturnier
    {
        public Teilnehmerliste Teilnehmerliste { get; set; }

        public Ritterturnier(Teilnehmerliste teilnehmerliste) {
            this.Teilnehmerliste = teilnehmerliste;
        }
    }
}
