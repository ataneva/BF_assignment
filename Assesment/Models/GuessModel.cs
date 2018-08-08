using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assesment.Models
{
    public class GuessModel
    {
        public int Guess { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public int randomNumber { get; set; }

        private List<int> wrongAttemptsList = new List<int>();

        public int NumberOfAttempts { get; set; }
        public string Message { get; set; }
    }
}