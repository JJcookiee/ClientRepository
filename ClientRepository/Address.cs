using System;
using System.Collections.Generic;
using System.Text;

namespace Programming03Project
{
    internal class Address
    {
        public string HouseName { get; set; }
        public string Town {  get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }

        public Address(string houseName, string town, string county, string postCode)
        {
            HouseName = houseName;
            Town = town;
            County = county;
            PostCode = postCode;
        }
        public Address()
        {
            HouseName = "";
            Town = "";
            County = "";
            PostCode = "";
        }

        public static string todb(Address address)
        {
            string dbstring = (
                $"{address.HouseName}, " +
                $"{address.Town}, " +
                $"{address.County}, " +
                $"{address.PostCode}"
                );
            return dbstring;
        }
        public static Address fromdb(string dbstring)
        {
            string[] dbstrings = dbstring.Split(", ");
            Address address = new Address(
                houseName : dbstrings[0],
                town: dbstrings[1],
                county : dbstrings[2],
                postCode : dbstrings[3]
                );
            return address;
        }
    }
}
