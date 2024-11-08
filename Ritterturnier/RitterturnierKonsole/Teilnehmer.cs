using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RitterturnierKonsole
{
    public abstract class Teilnehmer
    {
        [JsonInclude]
        public int ID {  get; set; }
        public static int IDCounter = 0;

        [JsonInclude]
        public string Name {  get; set; }
        [JsonInclude]
        public string Telefonnummer { get; set; }

        public Teilnehmer(string name, string telefonnummer) {
            IDCounter++;
            this.Name = name;
            this.Telefonnummer = telefonnummer;
            this.ID = IDCounter;
        }

        public virtual string ToString()
        {
            // toString fuer Ritter
            if (this.GetType() == typeof(Ritter)) {
                return $"Ritter\t{ID}\tName:\t{Name}\t\t";
            }

            return $"Name:\t{Name}\t\t";
        }

    }
}
