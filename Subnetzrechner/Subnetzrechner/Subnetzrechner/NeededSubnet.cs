namespace Subnetzrechner
{
    internal class NeededSubnet : Subnetz
    {
        public string SubnetzName { get; set; }
        public string GeraeteAnzahl { get; set; }

        public string Netzadresse
        {
            get { if (_netzadresse != null) { return _netzadresse.MakeString(_netzadresse.address); } else { return ""; } }
            set { _netzadresse = new IPV4(value); }
        }

        public string Subnetzmaske
        {
            get { if (_subnetzmaske != null) { return _netzadresse.MakeString(_subnetzmaske._subnetzmaske.address); } else { return ""; } }
            set { _subnetzmaske = new Subnetzmaske(new IPV4(value)); }
        }

        public NeededSubnet() : base() { }

        public NeededSubnet(string netzadresse, string subnetzmaske) : base(netzadresse, subnetzmaske)
        {
        }




    }
}
