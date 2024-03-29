﻿using System;
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
        [Required(ErrorMessage = "Serial Number is Required")]
        [MaxLength(450)]
        [MinLength(2)]
        //public int SerialNumber { get; set; }
        public string SerialNumber { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50)]
        [DisplayName("Name of Gateway")]
        public string Name { get; set; }

        [Required(ErrorMessage = "IPV4 is Required")]
        //[RegularExpression(@"^((\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.){3}(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$", ErrorMessage = "Incorrect IPv4 Format")]
        [MaxLength(15)]
        [MinLength(7)]
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
