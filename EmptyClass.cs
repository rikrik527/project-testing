using System;
namespace AssemblyCSharp
{
    public class EmptyClass
    {
        public void Main()
        {
            string[] cars = { "eeeee", "1eeeee" };
            foreach(string i in cars)
            {
                Console.WriteLine(i);
            }
        }
    }
}
