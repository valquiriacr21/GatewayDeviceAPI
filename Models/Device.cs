using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Vendor")]
        [Required(ErrorMessage = "Vendor is Required")]
        [MaxLength(50)]
        public string Vendor { get; set; }

        [DisplayName("Date Created")]
        [Required(ErrorMessage = "DateCreated is Required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }


        [Required(ErrorMessage = "Status is Required")]
        [DisplayName("Status: Online/Offline ")]
        [RegularExpression(@"Online|Offline", ErrorMessage = "Incorrect status Format")]
        [MaxLength(7)]
        [MinLength(6)]        
        public string Status { get; set; }
        [Required]
        //[MaxLength(100)]
        [ForeignKey("Gateway")]
        [DisplayName("Select Gateway")]
        [MaxLength(450)]
        public string GatewaySerialNumber { get; set; }
        Gateway Gateway { get; set; }
        #endregion

    }
}
