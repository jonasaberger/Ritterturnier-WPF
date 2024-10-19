namespace RitterturnierKonsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ritterturnier-Konsole\nJonas Aberger\t 19-10-2024\n\n");
            Ritterturnier ritterturnier_1 = new Ritterturnier(new Teilnehmerliste());

            Ritter ritter = new Ritter("Jonas", "+43 660 12341324", "Der Coole");
            ritter.AddWaffe(new Waffe("Großschwert", WaffenArt.S));
            ritter.AddKnappe(new Knappe("Johannes", "+43 660 12341234", 0));

            Console.WriteLine(ritter.ToString());
        }
    }
}
