using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitterturnierKonsole
{
    public class Knappe
    {
        public string _name {  get; set; }
        public string _telefonnummer {  get; set; }
        public int _ausbildungsgrad {  get; set; }

        public Knappe(string name, string telefonnummer, int ausbildungsgrad) {
            this._name = name;
            this._telefonnummer = telefonnummer;
            this._ausbildungsgrad = ausbildungsgrad;
        }

        public override string ToString()
        {
            return $"\t\tKnappe: {_name}\tGrad: {_ausbildungsgrad}\n";
        }

    }
}
