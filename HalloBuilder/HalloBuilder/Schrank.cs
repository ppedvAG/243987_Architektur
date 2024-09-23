
namespace HalloBuilder
{
    internal class Schrank
    {
        public int AnzahlTüren { get; private set; }
        public string Farbe { get; private set; } = string.Empty;
        public Oberfläche Oberfläche { get; private set; }

        /// <summary>
        /// Builder class to construct a Schrank object.
        /// </summary>
        internal class Builder
        {
            private Schrank _schrank = new Schrank();

            /// <summary>
            /// Sets the number of doors for the Schrank.
            /// </summary>
            /// <param name="anzahlTüren">Number of doors (must be between 2 and 6).</param>
            /// <returns>The Builder instance.</returns>
            /// <exception cref="System.ArgumentException">Thrown when the number of doors is not between 2 and 6.</exception>
            public Builder SetTüren(int anzahlTüren)
            {
                if (anzahlTüren < 2 || anzahlTüren > 6)
                    throw new System.ArgumentException("Anzahl der Türen muss zwischen 2 und 6 liegen.");

                _schrank.AnzahlTüren = anzahlTüren;
                return this;
            }

            /// <summary>
            /// Sets the color for the Schrank.
            /// </summary>
            /// <param name="farbe">Color of the Schrank.</param>
            /// <returns>The Builder instance.</returns>
            /// <exception cref="System.ArgumentException">Thrown when the surface is not painted.</exception>
            public Builder SetFarbe(string farbe)
            {
                if (_schrank.Oberfläche != Oberfläche.Lackiert)
                    throw new System.ArgumentException("Farbe kann nur bei lackierten Schränken gesetzt werden.");
                _schrank.Farbe = farbe;
                return this;
            }

            /// <summary>
            /// Sets the surface type for the Schrank.
            /// </summary>
            /// <param name="oberfläche">Surface type of the Schrank.</param>
            /// <returns>The Builder instance.</returns>
            public Builder SetOberfläche(Oberfläche oberfläche)
            {
                _schrank.Oberfläche = oberfläche;
                return this;
            }

            /// <summary>
            /// Builds and returns the Schrank object.
            /// </summary>
            /// <returns>The constructed Schrank object.</returns>
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
