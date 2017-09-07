using System;

namespace Deneme
{
    class Program
    {
        static void Main(string[] args)
        {
            var monkey = new Monkey();
            var banana = new Banana();
            monkey.EatFruit(banana);

            Console.Read();
        }
    }
}