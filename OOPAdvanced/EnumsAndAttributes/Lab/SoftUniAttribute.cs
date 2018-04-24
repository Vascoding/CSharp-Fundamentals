using System;
public class SoftUniAttribute : Attribute
{
    public string Name { get; set; }
    public SoftUniAttribute(string name)
    {
        this.Name = name;
    }
}
