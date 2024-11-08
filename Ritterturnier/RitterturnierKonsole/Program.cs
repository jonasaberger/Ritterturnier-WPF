namespace RitterturnierKonsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();

            Console.WriteLine("Ritterturnier-Konsole\nJonas Aberger\t 19-10-2024\n\n");
            Ritterturnier ritterturnier_1 = new Ritterturnier(new Teilnehmerliste());

            /*Ritter ritter_1 = new Ritter("Jonas", "+43 660 12341324", "Der Coole");
            ritter_1.AddWaffe(new Waffe("Großschwert", WaffenArt.S));
            ritter_1.AddKnappe(new Knappe("Johannes", "+43 660 12341234", 0));
            ritterturnier_1._teilnehmerliste.AddTeilnehmer(ritter_1);

            Ritter ritter_2 = new Ritter("Tom", "+43 660 12341324", "Der Schlaue");
            ritter_2.AddWaffe(new Waffe("Kleinkeule", WaffenArt.K));
            ritterturnier_1._teilnehmerliste.AddTeilnehmer(ritter_2);*/

            /*Ritter ritter_3 = new Ritter("Johannes", "+43 660 12341324", "Der Langweilige");
            ritterturnier_1._teilnehmerliste.AddTeilnehmer(ritter_3);


            Console.WriteLine(ritterturnier_1._teilnehmerliste.ListeAlleTeilnehmer());
            Console.WriteLine(ritterturnier_1._teilnehmerliste.AlleMitWaffenart(WaffenArt.S));

            fileManager.ToFile(ritterturnier_1._teilnehmerliste);*/
            ritterturnier_1.Teilnehmerliste = fileManager.FromFile();


            Console.WriteLine(ritterturnier_1.Teilnehmerliste.ListeAlleTeilnehmer());
        }
    }
}
