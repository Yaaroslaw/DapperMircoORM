using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperMircoORM
{
    public class MultiMapping
    {
        public class Post
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public User Owner { get; set; }
        }

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public void TestMultiMapping()
        {
            var sql =
                    @"select * from #Posts p 
                    left join #Users u on u.Id = p.OwnerId 
                    Order by p.Id";

            var data = connection.Query<Post, User, Post>(sql, (p, user) => { p.Owner = user; return p; });
            var post = data.First();

            Assert.AreEqual("Sams Post1", post.Content);
            Assert.AreEqual(1, post.Id);
            Assert.AreEqual("Sam", post.Owner.Name);
            Assert.AreEqual(99, post.Owner.Id);
        }

    }
}
