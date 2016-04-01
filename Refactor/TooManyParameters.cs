using System;

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
