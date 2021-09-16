using System;
using Newtonsoft.Json; 

namespace CurrencyB.Models
{
    public class CurrencyConvert
    {

        ///Manages the objects returned from the API

        public bool success { get; set; }

        public string timestamp { get; set; }

        public string baseCurrency { get; set;}

        public DateTime date { get; set; }

        public Rates rates { get; set; }


    }

    public class Rates
    {
        public float USD { get; set; }

        public float AUD { get; set; }

        public float CAD { get; set; }

        public float PLN { get; set; }

        public float MXN { get; set; }

        public int EUR { get; set; }
    }

    
}
