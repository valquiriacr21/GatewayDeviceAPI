using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [MaxLength(450)]
        //public int SerialNumber { get; set; }
        public string SerialNumber { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50)]
        [DisplayName("Name of Gateway")]
        public string Name { get; set; }

        [Required(ErrorMessage = "IPV4 is Required")]
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
