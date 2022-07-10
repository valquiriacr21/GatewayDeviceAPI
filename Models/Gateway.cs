using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayDeviceAPI.Models
{
    public class Gateway
    {
        #region Properties
        // public int GatewayId { get; set; }
        [Key]
        [MaxLength(100)]
        //public int SerialNumber { get; set; }
        public int SerialNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(15)]
        public string IPV4 { get; set; }        
        public List<Device> Devices { get; set; }
        #endregion


        #region Constructor
        public Gateway()
        {
            Devices = new List<Device>();
        }
        #endregion
    }
}
