using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RitterturnierKonsole
{
    public class Waffe
    {
        [JsonInclude]
        public string Bezeichnung {  get; set; }
        [JsonInclude]
        public WaffenArt WaffenArt {  get; set; }

        public Waffe(string bezeichnung, WaffenArt waffenArt) {
            this.Bezeichnung = bezeichnung;
            this.WaffenArt = waffenArt;
        }

        public override string ToString() {
            return $"\t\tWaffe:\t{Bezeichnung}\t\tArt:\t\t{WaffenArt}\n";
        }
    }
}
