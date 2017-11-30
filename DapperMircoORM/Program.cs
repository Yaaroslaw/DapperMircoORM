using System;
using System.Data.SqlClient;
using System.Linq;
using static DapperMircoORM.Helpers.ExecuteQueryMapToStronglyTypedList;


namespace DapperMircoORM
{
    /// <summary>
    /// Dapper is a NuGet library that you can add in to your project 
    /// that will extend your IDbConnection interface. It provides 3 helpers
    /// See folder "Helpers"
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            var guid = Guid.NewGuid();
            var dog = connection.Query<Dog>("select Age = @Age, Id = @Id", new { Age = (int?)null, Id = guid });

            Console.WriteLine("Dogs count should be 1, actually is: " + dog.Count());
            Console.WriteLine("First dog age should be NULL, actually is: " + dog.First().Age);
            //TODO: STRING INTERPOLATION
            Console.WriteLine("First dog id should be: " + guid.ToString() + " actually is: " + dog.First().Id);

        }
    }
}
