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
        /// <summary>
        /// Parameters are passed in as anonymous classes. This allow you to name your 
        /// parameters easily and gives you the ability to simply cut-and-paste SQL 
        /// snippets and run them in Query analyzer.
        /// new {A = 1, B = "b"} // A will be mapped to the param @A, B to the param @B 
      /// </summary>
      /// <param name="args"></param>

    static void Main(string[] args)
        {
            //TODO: Add a real database;
            var guid = Guid.NewGuid();
            var dog = connection.Query<Dog>("select Age = @Age, Id = @Id", new { Age = (int?)null, Id = guid });

            Console.WriteLine($"Dogs count should be 1, actually is: {dog.Count()}");
            Console.WriteLine($"First dog age should be NULL, actually is: {dog.First().Age}");
            Console.WriteLine($"First dog id should be: {guid.ToString()} actually is: {dog.First().Id}");

        }
    }
}
