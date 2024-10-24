using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RitterturnierKonsole
{
    public class Knappe
    {
        [JsonInclude]
        public string _name {  get; set; }
        [JsonInclude]
        public string _telefonnummer {  get; set; }
        [JsonInclude]
        public int _ausbildungsgrad {  get; set; }

        public Knappe(string name, string telefonnummer, int ausbildungsgrad) {
            this._name = name;
            this._telefonnummer = telefonnummer;
            this._ausbildungsgrad = ausbildungsgrad;
        }

        public override string ToString()
        {
            return $"\t\tKnappe:\t{_name}\t\tGrad:\t\t{_ausbildungsgrad}\n";
        }

    }
}
