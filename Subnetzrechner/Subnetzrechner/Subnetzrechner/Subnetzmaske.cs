using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Subnetzrechner
{
    internal class Subnetzmaske
    {
        public IPV4 _subnetzmaske = new IPV4( "0.0.0.0" );
        // ohne 255, da dies als Ausgangspunkt angenommen wird
        private List<int> _moeglicheSubnetzmasken = new List<int> {0, 128, 192, 224, 240, 248, 252, 254};

        public Subnetzmaske(IPV4 _ip)
        {
            if (!CheckSubnetmask(_ip)) { throw new ArgumentException("Bitte richtige Subnetzmaske eingeben"); }
        }

        public bool CheckSubnetmask(IPV4 _ip)
        {
            bool _isSubnetmask = false;
            bool _lower255 = false;
            for (int i = 0; i < 4; i++)
            {
                if (_lower255)
                {
                    if (_ip.address[i] == 0)
                    {
                        _isSubnetmask = true;
                    }
                    else
                    {
                        _isSubnetmask = false;
                        break;
                    }
                }
                else
                {
                    if (_ip.address[i] == 255)
                    {
                        _isSubnetmask = true;
                    }
                    else
                    {
                        if (_moeglicheSubnetzmasken.Contains(_ip.address[i]))
                        {
                            _isSubnetmask = true;
                        }
                        else
                        {
                            _isSubnetmask = false;
                            break;
                        }
                        _lower255 = true;
                    }
                }
            }

            if (_ip.address[3] == 255 || _ip.address[3] == 254)
            {
                _isSubnetmask = false;
            }
            if (_isSubnetmask)
            {
                this._subnetzmaske = _ip;
            }
            return _isSubnetmask;
        }

        public int GetHosts()
        {
            int returnHosts = 0;
            int[] _anzahlenHosts = { 0, 0, 0, 0 };

            int _counter = 0;
            foreach (int item in _subnetzmaske.address)
            {
                switch (item)
                {
                    case 0:
                        _anzahlenHosts[_counter] = 256;
                        break;
                    case 128:
                        _anzahlenHosts[_counter] = 128;
                        break;
                    case 192:
                        _anzahlenHosts[_counter] = 64;
                        break;
                    case 224:
                        _anzahlenHosts[_counter] = 32;
                        break;
                    case 240:
                        _anzahlenHosts[_counter] = 16;
                        break;
                    case 248:
                        _anzahlenHosts[_counter] = 8;
                        break;
                    case 252:
                        _anzahlenHosts[_counter] = 4;
                        break;
                    case 254:
                        _anzahlenHosts[_counter] = 2;
                        break;
                    case 255:
                        _anzahlenHosts[_counter] = 1;
                        break;
                    default:
                        break;
                }
                _counter++;
            }
            return _anzahlenHosts[0] * _anzahlenHosts[1] * _anzahlenHosts[2] * _anzahlenHosts[3] - 2;
        }
    }
}
