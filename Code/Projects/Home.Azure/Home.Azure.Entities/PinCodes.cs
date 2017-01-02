using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Azure.Entities
{
    public class PinCodes : TableEntity
    {
        public PinCodes(string city)
        {
            this.PartitionKey = city;
            this.RowKey = Guid.NewGuid().ToString();
        }

        public PinCodes() { }

        public string PinCode { get; set; }

        public string City { get; set; }

        public string Weather { get; set; }
    }
}