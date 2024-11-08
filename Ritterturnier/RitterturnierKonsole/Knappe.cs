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
        public string Name {  get; set; }
        [JsonInclude]
        public string Telefonnummer {  get; set; }
        [JsonInclude]
        public int Ausbildungsgrad {  get; set; }

        public Knappe(string name, string telefonnummer, int ausbildungsgrad) {
            this.Name = name;
            this.Telefonnummer = telefonnummer;
            this.Ausbildungsgrad = ausbildungsgrad;
        }

        public override string ToString()
        {
            return $"\t\tKnappe:\t{Name}\t\tGrad:\t\t{Ausbildungsgrad}\n";
        }

    }
}
