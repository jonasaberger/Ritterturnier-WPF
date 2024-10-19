namespace RitterturnierXUNIT
{
    using RitterturnierKonsole;
    [Collection("Non-Parallelizable Tests")]
    public class RitterTest
    {
        public Ritter _ritter;

        public RitterTest() {

            this._ritter = new Ritter("Ritter", "+12 123 12341234", "TestRitter");
            this._ritter._id = 1; // ID manuell zuweisen um Fehler in der toString-Testung vorzubeugen
        }

        [Fact]
        public void AddWaffe_Test()
        {
            Waffe waffe = new Waffe("Schwert", WaffenArt.S);
            Assert.Equal(waffe, _ritter.AddWaffe(waffe)._waffe);
        }

        [Fact]
        public void AddKnappe_Test()
        {
            Knappe knappe = new Knappe("Knappe", "+12 123 12341234", 1);
            Assert.Equal(knappe,_ritter.AddKnappe(knappe)._knappe);
        }

        [Fact]
        public void ToString_Test()
        {
            Assert.Equal("Ritter 1\tName: Ritter\t\tRufname: TestRitter\n", _ritter.ToString());
        }
    }
}