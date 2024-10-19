using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitterturnierKonsole
{
    public class Teilnehmerliste
    {
        public List<Teilnehmer> _teilnehmerliste {  get; set; }

        public Teilnehmerliste() {
            _teilnehmerliste = new List<Teilnehmer>();
        }

        public NameSchonVorhandenException AddTeilnehmer(Teilnehmer teilnehmer)
        {
            try
            {
                foreach (Teilnehmer t in _teilnehmerliste)
                {
                    if(t._name == teilnehmer._name) { throw new NameSchonVorhandenException(teilnehmer._name); }
                }
                _teilnehmerliste.Add(teilnehmer);
            }
            catch(NameSchonVorhandenException e)
            {
                Console.WriteLine(e.Message);
                return e;
            }
            return null;
        }

        // Ausgabe aller Teilnehmer
        public string ListeAlleTeilnehmer()
        {
            string fString = string.Empty;
            foreach (Teilnehmer t in _teilnehmerliste)
            {
                fString += t.ToString();
                fString += "\n\n";
            }
            return fString;
        }

        // Gefilterte Ausgabe nach der Waffenart
        public string AlleMitWaffenart(WaffenArt waffenArt)
        {
            string fString = $"Alle Teilnehmer mit Waffenart: {waffenArt}\n";
            foreach(Teilnehmer t in _teilnehmerliste)
            {
                if(((Ritter)t)._waffe != null)
                {
                    if (((Ritter)t)._waffe._waffenArt == waffenArt)
                    {
                        fString += t.ToString();
                        fString += "\n\n";
                    }
                }
            }
            return fString;
        }
    }
}
