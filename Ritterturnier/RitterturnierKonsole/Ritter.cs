using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RitterturnierKonsole
{
    public class Ritter : Teilnehmer
    {
        [JsonInclude]
        public string _rufname {  get; set; }
        [JsonInclude]
        public Waffe _waffe { get; set; }
        [JsonInclude]
        public Knappe _knappe { get; set; }


        public Ritter(string name, string telefonnummer, string rufname) : base(name, telefonnummer)
        {
            this._rufname = rufname;

            this._waffe = null;
            this._knappe = null;
        }


        // Hinzufuegen eines Knappen zu dem Ritter
        public Ritter AddKnappe(Knappe knappe)
        {
            _knappe = knappe;
            return this;
        }

        // Hinzufuegen einer Waffe zu dem Ritter
        public Ritter AddWaffe(Waffe waffe)
        {
            _waffe = waffe;
            return this;
        }

        public override string ToString()
        {
            //Wenn kein Knappe & Waffe vorhanden ist
            if(_knappe != null && _waffe != null) {
                return base.ToString() + $"Rufname:\t{_rufname}\n" + _knappe.ToString() + _waffe.ToString();
            }
            if(_knappe == null && _waffe != null) // Wenn nur kein Knappe vorhanden
            {
                return base.ToString() + $"Rufname:\t{_rufname}\n" + _waffe.ToString();
            }
            if (_knappe == null && _waffe != null) // Wenn nur kein Waffe vorhanden
            {
                return base.ToString() + $"Rufname:\t{_rufname}\n" + _knappe.ToString();
            }

            return base.ToString() + $"Rufname:\t{_rufname}\n";
        }

        public string PrintRitterAsJson()
        {
            var json = JsonSerializer.Serialize(new
            {
                _id,
                _name,
                _telefonnummer,
                _rufname,
                _waffe,
                _knappe
            }, new JsonSerializerOptions { WriteIndented = true});

            return json;
        }

    }
}
