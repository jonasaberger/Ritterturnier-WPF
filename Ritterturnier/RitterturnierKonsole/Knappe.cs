using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitterturnierKonsole
{
    public class Knappe : Teilnehmer
    {
        public int _ausbildungsgrad {  get; set; }
        public Knappe(string name, string telefonnummer, int ausbildungsgrad) : base(name,telefonnummer) {
            this._name = name;
            this._telefonnummer = telefonnummer;
            this._ausbildungsgrad = ausbildungsgrad;
        }

        public override string ToString()
        {
            return base.ToString() + $"Grad: {_ausbildungsgrad}\n";
        }

    }
}
