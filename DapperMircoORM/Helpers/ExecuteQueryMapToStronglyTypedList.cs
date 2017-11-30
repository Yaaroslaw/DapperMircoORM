using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperMircoORM.Helpers
{
    /// <summary>
    /// Execute a query and map the results to a strongly typed List
    /// public static IEnumerable<T> Query<T>(this IDbConnection cnn, string sql, object param = null, SqlTransaction transaction = null, bool buffered = true)
    /// </summary>
    static class ExecuteQueryMapToStronglyTypedList
    {
        public class Dog
        {            
            public int? Age { get; set; }
            public Guid Id { get; set; }
            public string Name { get; set; }
            public float? Weight { get; set; }

            public int IgnoredProperty { get { return 1; } }
        }
    }
}
