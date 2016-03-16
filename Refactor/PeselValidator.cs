using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactor
{
    public class PeselValidator
    {
        private int[] peselWeights = new int[] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        private Dictionary<int, int> monthToCenturyMapping = new Dictionary<int, int>()
            {
                { 0, 1900 },
                { 1, 1900 },
                { 2, 2000 },
                { 3, 2000 },
                { 4, 2100 },
                { 5, 2100 },
                { 6, 2200 },
                { 7, 2200 },
                { 8, 1800 },
                { 9, 1800 }
            };

        public bool PeselValid(string pesel)
        {
            //check if pesel is not null
            if (pesel == null)
            {
                return false;
            }
            //check if pesel length is correct
            else if (pesel.Length != 11)
            {
                return false;
            }
            //check pesel is numeric
            else if (!pesel.All(Char.IsDigit))
            {
                return false;
            }
            //check if pesel is not all zeros
            else if (!pesel.Any(x => x != '0'))
            {
                return false;
            }
            //if all is valid then we check if correct date is in pesel
            else
            {
                //first 6 digits in pesel represent date of birth of pesel owner
                var dateFromPesel = pesel.Substring(0, 6);

                // based on 3 we can establish the century of birth
                var monthCenturyId = int.Parse(dateFromPesel.Substring(2, 1));
                int monthFromPesel = 0;

                //check what month is in pesel - if monthcentury is even then month equals 4 digit of pesel. otherwise month equals 10 + 4 digit of pesel
                if(monthCenturyId % 2 == 0)
                {
                    monthFromPesel = int.Parse(dateFromPesel.Substring(3, 1));
                }
                else
                {
                    monthFromPesel = int.Parse(string.Format("1{0}", dateFromPesel.Substring(3, 1)));
                }

                //day is represented by 5 and 6 digit of pesel
                var dayPesel = int.Parse(dateFromPesel.Substring(4, 2));

                //year equals first 2 digits plus century which can be determined by 3 digit of pesel
                int yearFromPesel = int.Parse(dateFromPesel.Substring(0, 2));

                // third digit of pesel represents following centuries of birth:
                // 0 or 1 = 1900
                // 2 or 3 = 2000
                // 4 or 5 = 2100
                // 6 or 7 = 2200
                // 8 or 9 = 1800
                if (monthCenturyId == 0 || monthCenturyId == 1)
                {
                    yearFromPesel += 1900;
                }
                else if (monthCenturyId == 2 || monthCenturyId == 3)
                {
                    yearFromPesel += 2000;
                }
                else if (monthCenturyId == 4 || monthCenturyId == 5)
                {
                    yearFromPesel += 2100;
                }
                else if (monthCenturyId == 6 || monthCenturyId == 7)
                {
                    yearFromPesel += 2200;
                }
                else if (monthCenturyId == 8 || monthCenturyId == 9)
                {
                    yearFromPesel += 1800;
                }

                //try to parse the date from pesel to see if it's valid. if can't then catch exception and return false instead
                try
                {
                    var date = DateTime.Parse(string.Format("{0}-{1}-{2}", yearFromPesel, monthFromPesel, dayPesel));
                }
                catch (Exception)
                {
                    return false;
                }

            }

            // finally after all prerequisites have passed then check pesel algorithm
            // first 10 digits of pesel should be multiplied by weights and sumed togehter
            // weights are 1, 3, 7, 9, 1, 3, 7, 9, 1, 3
            // then reminder from that sum is substracted from 10 and should equal 11 digit of pesel
            // if reminder is 2 digit numer the it should be divided by 10 one more time and the reminder of that operation should equal 11 digit of pesel
            var weights = new int[] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

            var peselDigits = pesel.ToCharArray(0, 10).ToList();
            long sum = 0;

            //for (int i = 0; i < 10; i++)
            //{
            //    sum += long.Parse(peselDigits[i].ToString()) * weights[i];
            //}

            int i = 0;
            peselDigits.ForEach(x =>
            {
                sum += long.Parse(x.ToString()) * weights[i];
                i++;
            });

            var controlDigit = long.Parse(pesel.Last().ToString());

            sum = (10 - (sum % 10)) % 10;

            return sum == controlDigit;
        }

        public bool PeselValidAfterRefactor(string pesel)
        {

            if (pesel == null) return false;
            if (pesel.Length != 11) return false;
            if (!IsDigit(pesel)) return false;
            if (IsAllZeros(pesel)) return false;
            if (!CorrectDateInPesel(pesel)) return false;
            return PeselAlgorithmValid(pesel);
        }

        public bool IsDigit(string value)
        {
            return value.All(Char.IsDigit);
        }

        public bool IsAllZeros(string value)
        {
            return value.All(v => v == '0');
        }

        public bool CorrectDateInPesel(string value)
        {
            var dateFromPesel = value.Substring(0, 6);
            var monthCenturyId = int.Parse(dateFromPesel.Substring(2, 1));
            var monthPesel = monthCenturyId % 2 == 0 ? int.Parse(dateFromPesel.Substring(3, 1)) : int.Parse(string.Format("1{0}", dateFromPesel.Substring(3, 1)));
            var dayPesel = int.Parse(dateFromPesel.Substring(4, 2));
            var yearPesel = monthToCenturyMapping[monthCenturyId] + int.Parse(dateFromPesel.Substring(0, 2));

            DateTime result;
            return DateTime.TryParse(string.Format("{0}-{1}-{2}", yearPesel, monthPesel, dayPesel), out result);
        }

        public bool PeselAlgorithmValid(string value)
        {
            var peselDigits = value.ToCharArray(0, 10).ToList();
            long sum = 0;

            //for (int i = 0; i < 10; i++)
            //{
            //    sum += long.Parse(peselDigits[i].ToString()) * weights[i];
            //}

            int i = 0;
            peselDigits.ForEach(x =>
            {
                sum += long.Parse(x.ToString()) * peselWeights[i];
                i++;
            });

            var controlDigit = long.Parse(value.Last().ToString());

            sum = (10 - (sum % 10)) % 10;

            return sum == controlDigit;
        }

    }
}
