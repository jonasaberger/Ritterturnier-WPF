﻿namespace RitterturnierXUNIT
{
    using RitterturnierKonsole;
    
    public class TeilnehmerlisteTest
    {
        public Teilnehmerliste _teilnehmerliste;

        public TeilnehmerlisteTest()
        {
            this._teilnehmerliste = new Teilnehmerliste();
        }

        [Fact]
        public void AddTeilnehmer_Test()
        {
            int listSize = _teilnehmerliste.TeilnehmerlisteList.Count;
            _teilnehmerliste.AddTeilnehmer(new Ritter("TestRitter", "+12 123 12341234", "TestRitter"));
            Assert.Equal(listSize+1, _teilnehmerliste.TeilnehmerlisteList.Count());
        }

        [Fact]
        public void AddTeilnehmerException_Test()
        {
            Ritter ritter = new Ritter("Ritter", "+12 123 13241234", "TestRitter");
            _teilnehmerliste.AddTeilnehmer(ritter);

            Assert.Equal(new NameSchonVorhandenException(ritter.Name).Message, _teilnehmerliste.AddTeilnehmer(ritter).Message);
        }
    }
}