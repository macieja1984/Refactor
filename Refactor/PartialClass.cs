using System;

namespace Refactor
{
    public partial class PartialClass
    {
        public int Age { get; set; }

        public void SaySomething(string phraseToSay)
        {
            Console.WriteLine(phraseToSay);
        }
    }
}
