using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var rows = connection.Query("select 1 A, 2 B union all select 3, 4");

            Assert.AreEqual(1, (int)rows[0].A);
            Assert.AreEqual(2, (int)rows[0].B);
            Assert.AreEqual(3, (int)rows[1].A);
            Assert.AreEqual(4, (int)rows[1].B);
        }  
    }
}
