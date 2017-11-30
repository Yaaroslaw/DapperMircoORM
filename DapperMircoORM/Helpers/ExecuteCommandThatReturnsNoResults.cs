using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        var count = connection.Execute(@"
                            set nocount on 
                            create table #t(i int) 
                            set nocount off 
                            insert #t 
                            select @a a union all select @b 
                            set nocount on 
                            drop table #t", new { a = 1, b = 2 });
        Assert.Equal(2, count);
    }
}
