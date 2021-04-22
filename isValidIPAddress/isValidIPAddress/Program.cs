using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isValidIPAddress
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = ValidIPAddress("172.16.254.1");
            Console.ReadLine();
        }

        public static string ValidIPAddress(string IP)
        {
            if (isValidIPV4(IP))
            {
                return "IPv4";
            }
            if (isValidIPV6(IP))
            {
                return "IPv6";
            }

            return "Neither";
        }

        private static bool isValidIPV4(string IP)
        {
            string[] address = IP.Split('.');
            if (address.Length != 4)
            {
                return false;
            }

            foreach (var addr in address)
            {
                if (addr.Length == 0 || addr.Length > 1 && addr[0] == '0' || isAnyLetter(addr) || outOfRange(addr))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool isValidIPV6(string IP)
        {
            string[] address = IP.Split(':');
            if (address.Length != 8)
            {
                return false;
            }

            foreach (var addr in address)
            {
                if (addr.Length == 0 || addr.Length > 4 || !isHex(addr))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool isAnyLetter(string str)
        {
            foreach (char ch in str)
            {
                if (!char.IsDigit(ch))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool outOfRange(string str)
        {
            return !int.TryParse(str, out int digit) || digit  < 0 || digit  > 255;
        }

        private static bool isHex(string str)
        {
            foreach (char c in str)
            {
                bool isHex = ((c >= '0' && c <= '9') ||
              (c >= 'a' && c <= 'f') ||
              (c >= 'A' && c <= 'F'));

                if (!isHex)
                {
                    return false;
                }
            }

            return true;
        }


        /*  public static string ValidIPAddress(string IP)
          {
              if (isValidV4(IP))
              {
                  return "IPv4";
              }

              else if (isValidV6(IP))
              {
                  return "IPv6";
              }

              else
              {
                  return "Neither";
              }
          }

          private static bool isValidV4(string ip)
          {
              string[] adresses = ip.Split('.');
              if (adresses.Length != 4)
              {
                  return false;
              }

              foreach (var adress in adresses)
              {
                  if (adress.Length == 0 || (adress.Length > 1 && adress[0] == '0') || !isAlldigits(adress) || !int.TryParse(adress, out int digit) || digit < 0 || digit > 255)
                  {
                      return false;
                  }
              }

              return true;
          }

          private static bool isValidV6(string ip)
          {
              string[] adresses = ip.Split(':');
              if (adresses.Length != 8)
              {
                  return false;
              }

              foreach (var adress in adresses)
              {
                  if (adress.Length == 0 || adress.Length > 4 || !IsHex(adress))
                  {
                      // Console.WriteLine(adress);
                      return false;
                  }
              }

              return true;
          }

          private static bool IsHex(IEnumerable<char> chars)
          {
              bool isHex;
              foreach (var c in chars)
              {
                  isHex = ((c >= '0' && c <= '9') ||
                           (c >= 'a' && c <= 'f') ||
                           (c >= 'A' && c <= 'F'));

                  if (!isHex)
                  {
                      return false;
                  }
              }
              return true;
          }

          private static bool isAlldigits(IEnumerable<char> chars)
          {
              foreach (var c in chars)
              {
                  if (!Char.IsDigit(c))
                  {
                      return false;
                  }
              }
              return true;
          }
        */
    }
}
