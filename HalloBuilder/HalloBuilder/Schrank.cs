
namespace HalloBuilder
{
    internal class Schrank
    {
        public int AnzahlTüren { get; private set; }
        public string Farbe { get; private set; } = string.Empty;
        public Oberfläche Oberfläche { get; private set; }

        internal class Builder
        {
            private Schrank _schrank = new Schrank();

            public Builder SetTüren(int anzahlTüren)
            {
                if (anzahlTüren < 2 || anzahlTüren > 6)
                    throw new System.ArgumentException("Anzahl der Türen muss zwischen 2 und 6 liegen.");

                _schrank.AnzahlTüren = anzahlTüren;
                return this;
            }

            public Builder SetFarbe(string farbe)
            {
                if(_schrank.Oberfläche != Oberfläche.Lackiert)
                    throw new System.ArgumentException("Farbe kann nur bei lackierten Schränken gesetzt werden.");
                _schrank.Farbe = farbe;
                return this;
            }
            
            public Builder SetOberfläche(Oberfläche oberfläche)
            {
                _schrank.Oberfläche = oberfläche;
                return this;
            }   


            public Schrank Build()
            {
                return _schrank;
            }
        }
    }

    public enum Oberfläche
    {
        Natur,
        Lackiert,
        Geölt,
        Gewachst
    }
}
