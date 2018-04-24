using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    public int Count { get { return this.elements.Count; } }
    public Box()
    {
        this.elements = new List<T>();
    }
    public void Add(T element)
    {
        this.elements.Add(element);
    }

    private List<T> elements;
    public T Remove()
    {
        var element = this.elements.Last();
        this.elements.RemoveAt(elements.Count - 1);
        return element;
    }
}
