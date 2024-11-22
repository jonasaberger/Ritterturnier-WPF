using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace RitterturnierKonsole
{
    public class FileManager
    {
        public string Path { get; set; }

        public FileManager(string path) { this.Path = path; }

        public Teilnehmerliste FromFile()
        {
            Teilnehmerliste teilnehmerliste = new Teilnehmerliste();
            if (File.Exists(Path))
            {
                string json = File.ReadAllText(Path);
                // Schreibweise bewusst ausgelegt auf Erweiterbarkeit
                List<Ritter> ritterListe = JsonSerializer.Deserialize<List<Ritter>>(json);

                if (ritterListe != null)
                {
                    foreach (var ritter in ritterListe)
                    {
                        teilnehmerliste.AddTeilnehmer(ritter);
                    }
                }
            }
            return teilnehmerliste;
        }


        public async Task ToFile(Teilnehmerliste teilnehmerliste)
        {
            List<string> ritterJsonList = new List<string>();
            foreach (Teilnehmer teilnehmer in teilnehmerliste.TeilnehmerlisteList)
            {
                if (teilnehmer is Ritter ritter)
                {
                    ritterJsonList.Add(ritter.PrintRitterAsJson());
                }
            }
            await File.WriteAllTextAsync(Path, $"[{string.Join(",\n", ritterJsonList)}]");
        }
    }
}
