using System.IO;

namespace Exercise
{
    class CopyBinaryFile
    {
        public static void Copy()
        {
            FileStream open = new FileStream("../../Files/Judge.jpg", FileMode.Open);
            FileStream copy = new FileStream("../../Files/JudgeCopy.jpg", FileMode.Create);

            using (open)
            {
                using (copy)
                {
                    open.CopyTo(copy);
                }
            }
        }
    }
}
