using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayDeviceAPI.Models
{
    public class Gateway
    {
    
       // public int GatewayId { get; set; }
       [Key]
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        [Required]
        public string IPV4 { get; set; }        
        public List<Device> Devices { get; set; }

        public Gateway()
        {
            Devices = new List<Device>();
        }
    }
}
