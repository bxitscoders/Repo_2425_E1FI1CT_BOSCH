namespace Subnetzrechner
{
    internal class DataGridFormat
    {
        public string SubnetzName { get; set; }
        public string GeraeteAnzahl { get; set; }
        public string Netzadresse { get; set; }
        public string Subnetzmaske { get; set; }
        public string ErsteAdresse { get; set; }
        public string LetzteAdresse { get; set; }
        public string Broadcastadresse { get; set; }
        public string AnzahlHosts { get; set; }
        public DataGridFormat() { }
    }
}
