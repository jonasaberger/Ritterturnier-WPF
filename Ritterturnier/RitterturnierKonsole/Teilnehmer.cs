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
        public int _id {  get; set; }
        public static int _idCounter = 0;

        [JsonInclude]
        public string _name {  get; set; }
        [JsonInclude]
        public string _telefonnummer { get; set; }

        public Teilnehmer(string name, string telefonnummer) {
            _idCounter++;
            this._name = name;
            this._telefonnummer = telefonnummer;
            this._id = _idCounter;
        }

        public virtual string ToString()
        {
            // toString fuer Ritter
            if (this.GetType() == typeof(Ritter)) {
                return $"Ritter\t{_id}\tName:\t{_name}\t\t";
            }

            return $"Name:\t{_name}\t\t";
        }

    }
}
