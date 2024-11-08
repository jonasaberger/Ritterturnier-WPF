using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitterturnierKonsole
{
    public class Teilnehmerliste
    {
        public List<Teilnehmer> TeilnehmerlisteList {  get; set; }

        public Teilnehmerliste() {
            TeilnehmerlisteList = new List<Teilnehmer>();
        }

        public Teilnehmerliste(List<Teilnehmer> teils)
        {
            TeilnehmerlisteList = teils;

        }

        public NameSchonVorhandenException AddTeilnehmer(Teilnehmer teilnehmer)
        {
            try
            {
                foreach (Teilnehmer t in TeilnehmerlisteList)
                {
                    if(t.Name == teilnehmer.Name) { throw new NameSchonVorhandenException(teilnehmer.Name); }
                }
                TeilnehmerlisteList.Add(teilnehmer);
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
            foreach (Teilnehmer t in TeilnehmerlisteList)
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
            foreach(Teilnehmer t in TeilnehmerlisteList)
            {
                if(((Ritter)t).Waffe != null)
                {
                    if (((Ritter)t).Waffe.WaffenArt == waffenArt)
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
