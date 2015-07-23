using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesServiceCore.Abstract.Paging
{
    public struct Page<T>
    {
        public int PageNum { get; set; }
        public List<T> Items { get; set; }
        public int NextPage { get; set; }

        public Page(int num, List<T> items) : this()
        {
            this.PageNum = num;
            this.Items = items;
            this.NextPage = num++;
        }
    }
}
