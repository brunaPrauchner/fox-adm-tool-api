using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoxAdmTool.API.Models
{
    public class Order
    {
        // scalar properties: The primitive type properties
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        //reference to user
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        public virtual List<Product> Products { get; set; }

    }
}
