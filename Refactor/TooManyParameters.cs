using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor
{
    public class TooManyParameters
    {
        public int CalculateCarInsuranceRate(int DriversAge, DateTime DriversLicenceIssueDate, 
            bool DriverIsMarried, bool DriverHasChildren, 
            int DriversAccidentsNumber, DateTime CarsProductionDate,
            int CarsValue, string CarsMake, 
            string CarsModel, bool CarIsParkedInGarage)
        {
            // business logic

            return 123;
        }

    }


}
