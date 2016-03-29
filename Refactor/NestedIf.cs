using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor
{
    public class NestedIf
    {
        private const int AbsoluteZeroTemp = -273;

        public string SubstancePhysicalState(int substanceMeltingTemp, int substanceBoilingTemp, int substanceTemp)
        {
            if (substanceTemp > AbsoluteZeroTemp)
            {
                if (substanceBoilingTemp > substanceMeltingTemp)
                {
                    if (substanceTemp > substanceMeltingTemp)
                    {
                        if (substanceTemp < substanceBoilingTemp)
                        {
                            return "Liquid";
                        }
                        else
                        {
                            return "Gas";
                        }
                    }
                    else
                    {
                        return "Solid";
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public string SubstancePhysicalStateAfterRefactor(int substanceMeltingTemp, int substanceBoilingTemp, int substanceTemp)
        {
            if (substanceTemp < AbsoluteZeroTemp || substanceBoilingTemp < substanceMeltingTemp) throw new ArgumentOutOfRangeException();

            if (substanceTemp < substanceBoilingTemp && substanceTemp > substanceMeltingTemp) return "Liquid";

            return substanceTemp > substanceBoilingTemp ? "Gas" : "Solid";
        }
    }
}
