namespace Refactor
{
    public class MutliClassFile
    {
    }

    #region Person

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Address PersonAddress { get; set; }
        public Phone PersonPhone { get; set; }
    }

    #endregion

    #region Address

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public int HouseNumber { get; set; }
        public int? FlatNumber { get; set; }
    }

    #endregion

    #region Phone

    public class Phone
    {
        public PhoneType Type { get; set; }
        public long Number { get; set; }
    }

    #endregion

    #region PhoneType

    public enum PhoneType
    {
        Mobile,
        Landline,
        Sat        
    }

    #endregion

}
