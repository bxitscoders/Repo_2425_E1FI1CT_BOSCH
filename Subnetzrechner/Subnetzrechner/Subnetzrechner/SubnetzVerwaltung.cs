namespace Subnetzrechner
{
    internal class SubnetzVerwaltung
    {
        public List<DataGridFormat> DataGridFormats { get; private set; }
        public List<NeededSubnet> NeededSubnets { get; private set; }
        public bool isVLSM { get; private set; }
        public IPV4 IPV4 { get; private set; }

        public SubnetzVerwaltung()
        {
            NeededSubnets = new List<NeededSubnet>();
            DataGridFormats = new List<DataGridFormat>();
        }
        public void AddSubnet(NeededSubnet subnetz)
        {
            NeededSubnets.Add(subnetz);
        }

        public void RemoveSubnet(NeededSubnet subnetz)
        {
            NeededSubnets.Remove(subnetz);
        }

        public void BerechneSubnetze(bool isVLSM, string IPV4)
        {
            this.isVLSM = isVLSM;
            this.IPV4 = new IPV4(IPV4);

            IPV4 tmpNetzadresse = this.IPV4;
            string tmpIPV4 = IPV4;
            string tmpSubnetzmaske = BerechneSubnetzmaske();
            // Schleife über alle Datagrids
            foreach (var subnetz in DataGridFormats)
            {
                //Pruefe ob das DataGrid gesetzt ist
                if (subnetz.AnzahlHosts.Length > 0)
                {
                    if (this.isVLSM)
                    {
                        tmpSubnetzmaske = berechneVLSMSubnetzmaske(subnetz);
                    }
                    // Neues Subnetz zu der Liste hinzufuegen
                    NeededSubnet neuesSubnetz = new NeededSubnet(tmpNetzadresse.MakeString(tmpNetzadresse.address), tmpSubnetzmaske);
                    AddSubnet(neuesSubnetz);

                    // Netzadresse neu bestimmen
                    tmpNetzadresse = new IPV4(tmpNetzadresse.AddMultiToIPv4(neuesSubnetz.AnzahlHosts + 2));
                }
            }

            //Aktualisiere DataGridData
            int counterDG = 0;
            foreach (var item in NeededSubnets)
            {
                DataGridFormats[counterDG].Netzadresse = item.Netzadresse;
                DataGridFormats[counterDG].Subnetzmaske = item.Subnetzmaske;
                DataGridFormats[counterDG].ErsteAdresse = item.ErsteAdresse;
                DataGridFormats[counterDG].LetzteAdresse = item.LetzteAdresse;
                DataGridFormats[counterDG].Broadcastadresse = item.Broadcastadresse;
                DataGridFormats[counterDG].AnzahlHosts = "" + item.AnzahlHosts;
                counterDG++;
            }
        }

        private string BerechneSubnetzmaske()
        {
            string neueSubnetzmaske = "";
            int maxClients = 0;

            // ToDo

            return neueSubnetzmaske;
        }

        private string RechneSubnetzmaske(int maxClients)
        {
            int maxAnzahlIP = 0;
            string neueSubnetzmaske = "";

            for (int i = 0; i < 32; i++)
            {
                if (Math.Pow(2, i) >= maxClients + 2)
                {
                    maxAnzahlIP = (int) Math.Pow(2, i);
                    int trennungNetzHost = 3 - (int) i / 8;
                    int modulo = (i) % 8;
                    int trennungNetzHostZahl = 256 - (int) Math.Pow(2, modulo);
                    for (int j = 0; j <= 3; j++)
                    {
                        if (j < trennungNetzHost)
                        {
                            neueSubnetzmaske += "255.";
                        }
                        else if (j == trennungNetzHost)
                        {
                            if (j == 3)
                            {
                                neueSubnetzmaske += trennungNetzHostZahl;
                            }
                            else
                            {
                                neueSubnetzmaske += trennungNetzHostZahl + ".";
                            }
                        }
                        else if (j == 3)
                        {
                            neueSubnetzmaske += "0";
                        }
                        else
                        {
                            neueSubnetzmaske += "0.";
                        }
                    }
                    //fertig
                    return neueSubnetzmaske;
                }
            }

            return neueSubnetzmaske;
        }

        private string berechneVLSMSubnetzmaske(DataGridFormat datagrid)
        {
            string neueSubnetzmaske = "";
            int maxClients = 0;

            // ToDo

            return neueSubnetzmaske;
        }
    }

}
