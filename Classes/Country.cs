using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinylRecordsApplication_Klimov.Classes
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static IEnumerable<Country> AllCountries()
        {
            List<Country> countries = new List<Country>();
            DataTable requestCountries = DBConnection.Connection("SELECT * FROM [dbo].[Country]");
            foreach (DataRow row in requestCountries.Rows)
                countries.Add(new Country()
                {
                    Id = Convert.ToInt32(row[0]),
                    Name = Convert.ToString(row[1])
                });
            return countries;
        }
    }
}
