using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactor
{
    public class PeselValidator
    {
        public bool PeselValid(string pesel)
        {
            var peselValid = false;

            if (pesel == null)
            {
                peselValid = false;
            }
            else if (pesel.Length != 11)
            {
                peselValid = false;
            }
            else if (!pesel.All(Char.IsDigit))
            {
                peselValid = false;
            }
            else if (IsAllZeros(pesel))
            {
                peselValid = false;
            }
            else if (CorrectDateInPesel(pesel))
            {
                peselValid = false;
            }
            else
            {
                peselValid = PeselAlgorithmValid(pesel);
            }

            return peselValid;
        }      


        public bool PeselAlgorithmValid(string value)
        {
            var weights = new int[] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            var peselDigits = value.ToCharArray();
            long sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += long.Parse(peselDigits[i].ToString()) * weights[i];
            }

            long controlDigit = long.Parse(peselDigits.Last().ToString());

            sum = (10 - (sum % 10)) % 10;

            return (sum == controlDigit);
        }


        public bool CorrectDateInPesel(string value)
        {
            try
            {
                var centuryFromMonthDict = new Dictionary<int, int>() { { 0, 1900 }, { 1, 1900 }, { 2, 2000 }, { 3, 2000 }, { 4, 2100 }, { 5, 2100 }, { 6, 2200 }, { 7, 2200 }, { 8, 1800 }, { 9, 1800 } };

                var datePesel = value.Substring(0, 6);
                var monthCenturyId = int.Parse(datePesel.Substring(2, 1));
                var monthPesel = monthCenturyId % 2 == 0 ? int.Parse(datePesel.Substring(3, 1)) : int.Parse(string.Format("1{0}", datePesel.Substring(3, 1)));
                var dayPesel = int.Parse(datePesel.Substring(4, 2));
                var yearPesel = centuryFromMonthDict[monthCenturyId] + int.Parse(datePesel.Substring(0, 2));
                var dateFromPesel = new DateTime(yearPesel, monthPesel, dayPesel);
                return dateFromPesel == null;
            }
            catch
            {
                return false;
            }

        }

        public bool IsAllZeros(string value)
        {
            return !value.Any(v => v != '0');
        }

    }
}
