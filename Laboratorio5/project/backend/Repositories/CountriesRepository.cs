using backend.Models;
using System.Data;
using System.Data.SqlClient;


namespace backend.Repositories
{
    public class CountriesRepository
    {
        private SqlConnection _connection;
        private string _connectionRoute;
        public CountriesRepository()
        {
            var builder = WebApplication.CreateBuilder();
            _connectionRoute = builder.Configuration.GetConnectionString("CountriesContext");
            _connection = new SqlConnection(_connectionRoute);
        }
        private DataTable CreateTableQuery(string query)
        {
            SqlCommand queryCommand = new SqlCommand(query, _connection);
            SqlDataAdapter tableAdapter = new SqlDataAdapter(queryCommand);
            DataTable tableFormatQuery = new DataTable();
            _connection.Open();
            tableAdapter.Fill(tableFormatQuery);
            _connection.Close();
            return tableFormatQuery;
        }
        public List<CountryModel> GetCountries()
        {
            List<CountryModel> countries = new List<CountryModel>();
            string query = "SELECT * FROM dbo.Country";
            DataTable resultTable = CreateTableQuery(query);
            foreach (DataRow row in resultTable.Rows)
            {
                countries.Add(
                    new CountryModel
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Name = Convert.ToString(row["Name"]),
                        Continent = Convert.ToString(row["Continent"]),
                        Language = Convert.ToString(row["Language"])
                    });
            }
            return countries;
        }

        public bool CreateCountry(CountryModel country)
        {
            var query =
            @"INSERT INTO [dbo].[Country]([Name], [Continent], [Language])
            VALUES(@Name, @Continent, @Language)";

            var queryCommand = new SqlCommand(query, _connection);

            queryCommand.Parameters.AddWithValue("@Name", country.Name);
            queryCommand.Parameters.AddWithValue("@Continent", country.Continent);
            queryCommand.Parameters.AddWithValue("@Language", country.Language);

            _connection.Open();
            bool success = queryCommand.ExecuteNonQuery() >= 1;
            _connection.Close();
            return success;
        }
    }
}
