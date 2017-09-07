using System;
using System.Timers;

namespace Deneme
{
    internal class Monkey
    {
        public delegate void SearchFruit();
        public event SearchFruit onSearch;

        public int Energy { get; set; }

        public Monkey()
        {
            Energy = 10;

            onSearch += AskForBanana;
            onSearch += DyingWarning;
        }

        private void AskForBanana()
        {
            if (Energy < 5)
            {
                Console.WriteLine("I am hungry, I need banana!");
            }
        }

        private void DyingWarning()
        {
            if (Energy < 2)
            {
                Console.WriteLine("I am dying!");
            }
        }

        public void EatFruit(Fruit fruit)
        {
            Energy += fruit.Energy;

            var timer = new Timer(2000);
            timer.Elapsed += timer_Elapsed;
            timer.Enabled = true;
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Energy--;

            if (Energy < 0)
            {
                onSearch = null;
            }

            if (onSearch != null)
            {
                onSearch.Invoke();
            }
        }
    }
}