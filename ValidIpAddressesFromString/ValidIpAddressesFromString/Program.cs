using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidIpAddressesFromString
{
    class Program
    {
        static void Main(string[] args)
        {
			var output = ValidIPAddresses("1921680");
			Console.ReadLine();
		}


		public static List<string> ValidIPAddresses(string str)
		{
			// Write your code here.
			// T.C and S.C is O(1)
			List<string> output = new List<string>();
			for (int i = 0; i < Math.Min(str.Length, 3); i++)
			{
				string[] ipAddress = new string[4];
				string firstByteSubIp = str.Substring(0, i - 0 + 1);
				ipAddress[0] = firstByteSubIp;
				if (!isValidSubString(firstByteSubIp))
				{
					continue;
				}

				for (int j = i + 1; j < i + 1 + Math.Min(str.Length - i - 1, 3); j++)
				{
					string secondByteSubIp = str.Substring(i + 1, j - i);
					ipAddress[1] = secondByteSubIp;
					if (!isValidSubString(secondByteSubIp))
					{
						continue;
					}


					for (int k = j + 1; k < j + 1 + Math.Min(str.Length - j - 1, 3); k++)
					{
						string thirdByteSubIp = str.Substring(j + 1, k - j);
						if(k + 1 == str.Length)
                        {
							continue;
                        }
						string fourthByteSubIp = str.Substring(k + 1, str.Length - k - 1);
						ipAddress[2] = thirdByteSubIp;
						ipAddress[3] = fourthByteSubIp;

						if (isValidSubString(thirdByteSubIp)
							&& isValidSubString(fourthByteSubIp))
						{
							addCurrentIPAddressToOutput(ipAddress, output);
						}
					}
				}
			}

			return output;

		}

		private static bool isValidSubString(string str)
		{
			int integerValueOfString = Convert.ToInt32(str);
			if (integerValueOfString > 255)
			{
				return false;
			}

			//check for leading zeroes
			return integerValueOfString.ToString().Length == str.Length;
		}

		private static void addCurrentIPAddressToOutput(string[] ipAddress, List<string> output)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < ipAddress.Length; i++)
			{
				sb.Append(ipAddress[i]);
				if (i < ipAddress.Length - 1)
				{
					sb.Append(".");
				}
			}
			output.Add(sb.ToString());
		}
	}
}
