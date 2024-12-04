using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subnetzrechner
{
    internal class Subnetz
    {
        private int _anzahlHosts;
        public IPV4 _netzadresse;
        public Subnetzmaske _subnetzmaske;
        public string ErsteAdresse { get; set; }
        public string LetzteAdresse { get; set; }
        public string Broadcastadresse { get; set; }
        public int AnzahlHosts { get { return _subnetzmaske.GetHosts(); }
            set { } }

        public Subnetz()
        {
        }

            public Subnetz(string netzadresse, string subnetzmaske)
        {
            try
            {
                _netzadresse = new IPV4(netzadresse);
            }
            catch (Exception)
            {
                throw;
            }
            try
            {
                _subnetzmaske = new Subnetzmaske(new IPV4(subnetzmaske));
            }
            catch (Exception)
            {
                throw;
            }
            ErsteAdresse = this._netzadresse.AddOneToIPv4();
            LetzteAdresse = this._netzadresse.AddMultiToIPv4(_subnetzmaske.GetHosts());
            Broadcastadresse = this._netzadresse.AddMultiToIPv4(_subnetzmaske.GetHosts() + 1);
        }

        public bool CheckSubnetz(IPV4 netzadresse, Subnetzmaske subnetzmaske)
        {
            List<int> hosts;
            switch (subnetzmaske.GetHosts()+2)
            {
                case 256:
                    hosts = new List<int> { 0 };
                    if (hosts.Contains(netzadresse.address[3]))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 128:
                    hosts = new List<int> { 0, 128 };
                    if (hosts.Contains(netzadresse.address[3]))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 64:
                    hosts = new List<int> { 0, 64, 128, 192 };
                    if (hosts.Contains(netzadresse.address[3]))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 32:
                    hosts = new List<int> { 0, 32, 64, 96, 128, 160, 192, 224 };
                    if (hosts.Contains(netzadresse.address[3]))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 16:
                    hosts = new List<int> { 0, 16, 32, 48, 64, 80, 96, 112, 128, 144, 160, 176, 192, 208, 224, 240 };
                    if (hosts.Contains(netzadresse.address[3]))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 8:
                    hosts = new List<int> { 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 88, 96, 104, 112, 120, 128, 136, 144, 152, 160, 168, 176, 184, 192, 200, 208, 216, 224, 232, 240, 248 };
                    if (hosts.Contains(netzadresse.address[3]))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 4:
                    hosts = new List<int> { 0, 4, 8, 12, 16, 20, 24, 28, 32, 36, 40, 44, 48, 52, 56, 60, 64, 68, 72, 76, 80, 84, 88, 92, 96, 100, 104, 108, 112, 116, 120, 124, 128, 132, 136, 140, 144, 148, 152, 156, 160, 164, 168, 172, 176, 180, 184, 188, 192, 196, 200, 204, 208, 212, 216, 220, 224, 228, 232, 236, 240, 244, 248, 252 };
                    if (hosts.Contains(netzadresse.address[3]))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
                    break;
            }
        }

    }
}
