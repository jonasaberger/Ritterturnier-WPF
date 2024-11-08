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
        public string Rufname {  get; set; }
        [JsonInclude]
        public Waffe Waffe { get; set; }
        [JsonInclude]
        public Knappe Knappe { get; set; }


        public Ritter(string name, string telefonnummer, string rufname) : base(name, telefonnummer)
        {
            this.Rufname = rufname;

            this.Waffe = null;
            this.Knappe = null;
        }


        // Hinzufuegen eines Knappen zu dem Ritter
        public Ritter AddKnappe(Knappe knappe)
        {
            Knappe = knappe;
            return this;
        }

        // Hinzufuegen einer Waffe zu dem Ritter
        public Ritter AddWaffe(Waffe waffe)
        {
            Waffe = waffe;
            return this;
        }

        public override string ToString()
        {
            //Wenn kein Knappe & Waffe vorhanden ist
            if(Knappe != null && Waffe != null) {
                return base.ToString() + $"Rufname:\t{Rufname}\n" + Knappe.ToString() + Waffe.ToString();
            }
            if(Knappe == null && Waffe != null) // Wenn nur kein Knappe vorhanden
            {
                return base.ToString() + $"Rufname:\t{Rufname}\n" + Waffe.ToString();
            }
            if (Knappe == null && Waffe != null) // Wenn nur kein Waffe vorhanden
            {
                return base.ToString() + $"Rufname:\t{Rufname}\n" + Knappe.ToString();
            }

            return base.ToString() + $"Rufname:\t{Rufname}\n";
        }

        public string PrintRitterAsJson()
        {
            var json = JsonSerializer.Serialize(new
            {
                ID,
                Name,
                Telefonnummer,
                Rufname,
                Waffe,
                Knappe
            }, new JsonSerializerOptions { WriteIndented = true});

            return json;
        }

    }
}
