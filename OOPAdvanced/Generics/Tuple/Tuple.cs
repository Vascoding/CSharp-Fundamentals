using System;

namespace Tuple
{
    public class Tuple<Item1, Item2, Item3> 
    {
        public Tuple(Item1 firstItem, Item2 secondItem, Item3 thirdItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
            this.ThirdItem = thirdItem;
        }
        public Item1 FirstItem { get; set; }
        public Item2 SecondItem { get; set; }
        public Item3 ThirdItem { get; set; }
        public override string ToString()
        {
            return $"{this.FirstItem} -> {this.SecondItem} -> {this.ThirdItem}";
        }
    }
}