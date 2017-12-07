using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperMircoORM.Helpers
{
    /// <summary>
    /// Execute a Command that returns no results
    /// public static int Execute(this IDbConnection cnn, string sql,
    /// object param = null, SqlTransaction transaction = null)
    /// </summary>
    public class ExecuteCommandThatReturnsNoResults
    {
        //Example usage:
        //TODO: FIX SQL
        public static void NoResultCommand()
        {
            HardCodeConttection hardCon = new HardCodeConttection();
            var connection = hardCon.Create();
            var count = connection.Execute(@"
                            set nocount on 
                            create table #t(i int) 
                            set nocount off 
                            insert #t 
                            select @a a union all select @b 
                            set nocount on 
                            drop table #t", new { a = 1, b = 2 });
            Assert.AreEqual(2, count);
        }
        /// <summary>
        /// The same signature also allows you to conveniently and efficiently 
        /// execute a command multiple times (for example to bulk-load data)
        /// Example usage:
        /// </summary>
        public static void NoResultCommandMultipleTimes()
        {
            HardCodeConttection hardCon = new HardCodeConttection();
            var connection = hardCon.Create();
            var count = connection.Execute(@"insert MyTable(colA, colB) values (@a, @b)",
                new[] { new { a = 1, b = 1 }, new { a = 2, b = 2 }, new { a = 3, b = 3 } }
                );
            Assert.AreEqual(3, count); // 3 rows inserted: "1,1", "2,2" and "3,3"
        }


    }
}
