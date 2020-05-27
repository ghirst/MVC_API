using System;

namespace MVCDemoApp
{
    public class APIPage
    {
        public DateTime Date { get; set; }

        public int RandomNumber { get; set; }

        public int RandomNumberPlus7 => 7 + (int)(RandomNumber);

        public string Summary { get; set; }
    }
}
