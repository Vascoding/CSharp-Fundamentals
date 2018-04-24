using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class MyList : IMyList
    {
        public MyList()
        {
            this.Items = new List<string>();
        }

        public List<string> Items { get; set; }

        public int Used => this.Items.Count;

        public int Add(string item)
        {
            this.Items.Insert(0, item);
            return this.Items.IndexOf(item);
        }

        public string Remove()
        {
            var first = this.Items[0];
            this.Items.Remove(first);
            return first;
        }
    }
}