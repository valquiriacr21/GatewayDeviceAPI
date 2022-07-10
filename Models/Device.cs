using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayDeviceAPI.Models
{
    public class Device
    {
        #region Properties
        //public int DeviceId { get; set; }
        [Key]
        public int UID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Vendor { get; set; }
        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }
        [Required]
        [MaxLength(7)]
        public string Status { get; set; }
        [Required]
        //[MaxLength(100)]
        public int GatewaySerialNumber { get; set; }
        Gateway Gateway { get; set; }
        #endregion

    }
}
