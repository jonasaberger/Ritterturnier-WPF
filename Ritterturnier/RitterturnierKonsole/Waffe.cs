using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitterturnierKonsole
{
    public class Waffe
    {
        public string _bezeichnung {  get; set; }
        public WaffenArt _waffenArt {  get; set; }

        public Waffe(string bezeichnung, WaffenArt waffenArt) {
            this._bezeichnung = bezeichnung;
            this._waffenArt = waffenArt;
        }

        public override string ToString() {
            return $"\t\tWaffe: {_bezeichnung}\tArt: {_waffenArt}\n";
        }
    }
}
