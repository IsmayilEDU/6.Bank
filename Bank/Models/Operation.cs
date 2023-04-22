using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Exception.Models
{
    internal class Operation
    {

        //  Operation name
        public string Name { get; set; }

        //  Operation time
        public DateTime date { get; set; }

        public decimal Amount { get; set; }

        //  Constructor with parametres
        public Operation(string name, decimal amount, DateTime date)
        {
            Name = name;
            Amount = amount;
            this.date = date;
        }

        //  For show in console
        public override string ToString()
        {
            return $"Operation name: {Name}\nOperation amount: {Amount}\nOperation time: {date}\n";
        }
    }
}
