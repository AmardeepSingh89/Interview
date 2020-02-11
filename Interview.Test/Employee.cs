using System;
namespace Interview.Test
{
    public class Employee : IStoreable<int>
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
