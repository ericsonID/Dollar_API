using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotacaoDolarHG
{
    public class Market
    {
        [JsonProperty(PropertyName = "currencies")]
        public Currency Currency { get; set; }
        public Market()
        {
            this.Currency = new Currency();
        }
    }
}
