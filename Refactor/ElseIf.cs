using System;
using System.Collections.Generic;



namespace Refactor
{
    public class ElseIf
    {
        public int LongElseIf(string valueToCheck)
        {
            if (valueToCheck == "a")
            {
                return 0;
            }
            else if(valueToCheck == "b")
            {
                return 1;
            }
            else if (valueToCheck == "c")
            {
                return 2;
            }
            else if (valueToCheck == "d")
            {
                return 3;
            }
            else if (valueToCheck == "e")
            {
                return 4;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public int LongElseIfRefactorSwitch(string valueToCheck)
        {
            switch (valueToCheck)
            {
                case "a":
                    return 0;
                case "b":
                    return 1;
                case "c":
                    return 2;
                case "d":
                    return 3;
                case "e":
                    return 4;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public int LongElseIfRefactorDict(string valueToCheck)
        {
            var dict = new Dictionary<string, int>
            {
                {"a", 0 },
                {"b", 1 },
                {"c", 2 },
                {"d", 3 },
                {"e", 4 },
            };

            if (dict.ContainsKey(valueToCheck))
            {
                return dict[valueToCheck];
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}
