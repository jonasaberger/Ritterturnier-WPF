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
        public string _bezeichnung {  get; set; }
        [JsonInclude]
        public WaffenArt _waffenArt {  get; set; }

        public Waffe(string bezeichnung, WaffenArt waffenArt) {
            this._bezeichnung = bezeichnung;
            this._waffenArt = waffenArt;
        }

        public override string ToString() {
            return $"\t\tWaffe:\t{_bezeichnung}\t\tArt:\t\t{_waffenArt}\n";
        }
    }
}
