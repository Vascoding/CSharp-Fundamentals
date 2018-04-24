using System.Collections.Generic;

namespace _02.Graphic_Editor
{
    public class Program
    {
        public static void Main()
        {
            GraphicEditor graphicEditor = new GraphicEditor();
            IShape shape = new Rectangle();
            graphicEditor.DrawShape(shape);
        }
    }
}
