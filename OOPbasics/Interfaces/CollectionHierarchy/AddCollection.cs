using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        public AddCollection()
        {
            this.Items = new List<string>();
        }

        public List<string> Items { get; }

        public int Add(string item)
        {
            this.Items.Add(item);
            return this.Items.Count - 1;
        }
    }
}