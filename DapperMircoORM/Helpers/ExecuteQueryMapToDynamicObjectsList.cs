using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperMircoORM.Helpers
{
    /// <summary>
    /// Execute a query and map it to a list of dynamic objects
    /// public static IEnumerable<dynamic> Query (this IDbConnection cnn, string sql, 
    /// object param = null, SqlTransaction transaction = null, bool buffered = true)
    /// </summary>
    public class ExecuteQueryMapToDynamicObjectsList
    {
        //Example usage:
        var rows = connection.Query("select 1 A, 2 B union all select 3, 4");

        Assert.Equal(1, (int)rows[0].A);
        Assert.Equal(2, (int)rows[0].B);
        Assert.Equal(3, (int)rows[1].A);
        Assert.Equal(4, (int)rows[1].B);
    }
}
