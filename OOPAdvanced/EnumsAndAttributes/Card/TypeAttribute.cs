using System;
using System.Text;

namespace Card
{
    public class TypeAttribute : Attribute
    {
        private string type;
        private string category;
        private string description;
        public TypeAttribute(string type, string category, string description)
        {
            this.type = type;
            this.category = category;
            this.description = description;
        }
        public override string ToString()
        {
            return new StringBuilder($"Type = {this.type}, Description = {this.description}").ToString();
        }
    }
}