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
        public FileManager() { }

        public Teilnehmerliste FromFile()
        {
            Teilnehmerliste teilnehmerliste = new Teilnehmerliste();
            if (File.Exists("../../../saves/ritterturnier-save.json"))
            {
                string json = File.ReadAllText("../../../saves/ritterturnier-save.json");
                Console.WriteLine(json);
                var ritterListe = JsonSerializer.Deserialize<List<Ritter>>(json);

                if (ritterListe != null)
                {
                    foreach (var ritter in ritterListe)
                    {
                        Console.WriteLine(ritter.ToString());
                    }
                }

                //ERFOLG


            }
            return teilnehmerliste;
        }




        public async Task ToFile(Teilnehmerliste teilnehmerliste)
        {
            List<string> ritterJsonList = new List<string>();
            foreach (Teilnehmer teilnehmer in teilnehmerliste._teilnehmerliste)
            {
                if (teilnehmer is Ritter ritter)
                {
                    ritterJsonList.Add(ritter.PrintRitterAsJson());
                }
            }
            await File.WriteAllTextAsync("../../../saves/ritterturnier-save.json", $"[{string.Join(",\n", ritterJsonList)}]");
        }

    }
}
