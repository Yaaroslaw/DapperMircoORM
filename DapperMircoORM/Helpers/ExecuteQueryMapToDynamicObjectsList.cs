using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace DapperMircoORM.Helpers
{
    /// <summary>
    /// Execute a query and map it to a list of dynamic objects
    /// public static IEnumerable<dynamic> Query (this IDbConnection cnn, string sql, 
    /// object param = null, SqlTransaction transaction = null, bool buffered = true)
    /// </summary>
    
    [TestClass]
    public class ExecuteQueryMapToDynamicObjectsList
    {
        //TODO: A project for unit tests, when the database is ready.
        //Example usage:
        [TestMethod]
        public void ExecuteQueryMapToDynamicObjectsListExample()
        {
            HardCodeConttection2 hardCon = new HardCodeConttection2();
            var connection = hardCon.Create();
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "select 1 A, 2 B union all select 3, 4";

            var rows = command.ExecuteScalar(); 

            Assert.AreEqual(1, (int)rows[0].A);
            Assert.AreEqual(3, (int)rows[1].A);
        }  
    }
}
