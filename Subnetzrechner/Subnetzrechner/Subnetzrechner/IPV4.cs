using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Subnetzrechner
{
    /*  IPv4 Klasse
     * 
     * In dieser Klasse wird die IP als Ganzzahl-Array abgespeichert
     * die Form ist (192,168,0,10)
     * 
     * Es gibt folgende Methoden:
     * 
     * IP als String ausgeben (MakeString)
     * IP Adresse um eins erhöhen und als String ausgeben (AddOneToIPv4)
     * IP Adresse um mehrere Schritte erhöhen und als String ausgeben (AddMultiToIPv4)
     * IP Adresse um eins verringern und als String ausgeben (MinusOneToIPv4)
     */
    internal class IPV4
    {
        public int[] address {  get; set; }
        private int[] _tmpIPv4;
        private bool _multisteps = false;

        public IPV4(string address)
        {
            if (!CheckIP(address)) { throw new ArgumentException("Bitte richtige IP eingeben"); }
        }

        // Überprüfung, ob die IP Adresse richtig ist und trägt die IP Adresse in der Klasse ein
        private bool CheckIP(string ip)
        {
            bool _isip = false;
            int[] _ip = {0, 0, 0, 0};
            string[] _ipString = ip.Split('.');
            if (_ipString.Length == 4)
            {
                for(int i = 0; i < 4; i++)
                {
                    if (int.TryParse(_ipString[i], out int _ipnr))
                    {
                        if (_ipnr >= 0 && _ipnr <= 255)
                        {
                            _ip[i] = _ipnr;
                            _isip = true;
                        }
                        else
                        {
                            _isip = false;
                            break;
                        }
                    }
                    else
                    {
                        _isip = false;
                        break;
                    }
                }

                if (_isip)
                {
                    this.address = _ip;
                }              
                
            }
            return _isip;
        }

        //Gibt eine IP als String aus (Format: 192.168.0.10)
        public string MakeString(int[] address)
        {
            return $"{address[0]}.{address[1]}.{address[2]}.{address[3]}";
        }

        public string AddOneToIPv4()
        {
            if (!_multisteps) 
            {
                this._tmpIPv4 = (int[])address.Clone();
            }
            
            // testen, ob die letzte Zahl 255 ist, dann auf 0 setzen und den nächsten Block erhöhen
            if (_tmpIPv4[3] == 255)
            {
                _tmpIPv4[3] = 0;
                if (_tmpIPv4[2] == 255)
                {
                    _tmpIPv4[2] = 0;
                    if (_tmpIPv4[1] == 255)
                    {
                        _tmpIPv4[1] = 0;
                        if (_tmpIPv4[0] == 255)
                        {
                            throw new Exception("Zu große IP");
                            return "Zu große IP";
                        }
                        else
                        {
                            _tmpIPv4[0]++;
                        }
                    }
                    else
                    {
                        _tmpIPv4[1]++;
                    }
                }
                else
                {
                    _tmpIPv4[2]++;
                }
            }
            else
            {
                _tmpIPv4[3]++;
            }

            return MakeString(_tmpIPv4);
        }

        public string AddMultiToIPv4(int Steps)
        {
            this._tmpIPv4 = (int[])address.Clone();
            this._multisteps = true;
            for (int i = 0; i < Steps; i++)
            {
                AddOneToIPv4();
            }
            this._multisteps = false;
            return MakeString(this._tmpIPv4);
        }

            public string MinusOneToIPv4()
        {
            this._tmpIPv4 = (int[])address.Clone();
            // testen, ob die letzte Zahl 255 ist, dann auf 0 setzen und den nächsten Block erhöhen
            if (_tmpIPv4[3] == 0)
            {
                _tmpIPv4[3] = 255;
                if (_tmpIPv4[2] == 0)
                {
                    _tmpIPv4[2] = 255;
                    if (_tmpIPv4[1] == 0)
                    {
                        _tmpIPv4[1] = 255;
                        if (_tmpIPv4[0] == 0)
                        {
                            throw new Exception("Zu kleine IP");
                            return "Zu große IP";
                        }
                        else
                        {
                            _tmpIPv4[0]--;
                        }
                    }
                    else
                    {
                        _tmpIPv4[1]--;
                    }
                }
                else
                {
                    _tmpIPv4[2]--;
                }
            }
            else
            {
                _tmpIPv4[3]--;
            }

            return MakeString(_tmpIPv4);
        }
    }

}
