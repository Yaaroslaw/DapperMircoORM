using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
