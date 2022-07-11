using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GatewayDeviceAPI.Models;

namespace GatewayDeviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        #region Fields
        private readonly AppDbContext _context;
        #endregion

        #region Constructor

        public DevicesController(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region APIController Methods

        #region GET
        // GET: api/Devices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            return await _context.Devices.ToListAsync();
        }
        // GET: api/Devices
        [HttpGet("DevicesGateways={GatewaySerialNumber}")]
        //[RouteAttribute="DevicesGateways")]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevicesByGatewaySerialNumber(string GatewaySerialNumber)
        {
            var devices = await _context.Devices.Where(d => d.GatewaySerialNumber == GatewaySerialNumber).ToListAsync();
            return devices;
        }

        // GET: api/Devices
        [HttpGet("Vendor={Vendor}")]
        //[RouteAttribute="DevicesGateways")]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevicesByVendor(string Vendor)
        {
            var devices = await _context.Devices.Where(d => d.Vendor == Vendor).ToListAsync();
            return devices;
        }

        [HttpGet("Status={Status}")]
        //[RouteAttribute="DevicesGateways")]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevicesByStatus(string Status)
        {
            if (IsStatusValidate(Status))
            {
                var devices = await _context.Devices.Where(d => d.Status == Status).ToListAsync();
                return devices;
            }
            else
                return Problem("the status is not written correctly");
        }
        [HttpGet("DateCreated={DateCreated}")]
        //[RouteAttribute="DevicesGateways")]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevicesByDateCreated(DateTime DateCreated)
        {
            var devices = await _context.Devices.Where(d => d.DateCreated == DateCreated).ToListAsync();
            return devices;
        }

        //[HttpGet("Status={Status}&&Vendor={Vendor}")]
        ////[RouteAttribute="DevicesGateways")]
        //public async Task<ActionResult<IEnumerable<Device>>> GetDevicesByStatusVendor(string Status, string Vendor)
        //{
        //    var devices = await _context.Devices.Where(d => ((d.Status == Status)&&(d.Vendor == Vendor)).ToListAsync();
        //    return devices;
        //}

        // GET: api/Devices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            return device;
        }
        #endregion

        #region PUT Upadate

        // PUT: api/Devices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice(int id, [FromBody]Device device)
        {
    
            if (id != device.UID)
            {
                return BadRequest();
            }
            //if (CountDeviceOfGateway(device.GatewaySerialNumber) > 10) { return Problem("Each gateway cannot have more than 10 devices, select another gateway"); }
            //else
            //{
            if (IsStatusValidate(device.Status))
            {
                if (SerialGatawayHadModifed(id, device.GatewaySerialNumber))
                {
                    if (GatewayDevicesAreLessThanTen(device.GatewaySerialNumber))
                    {
                        //_context.Entry(device).State = EntityState.Detached;
                        _context.Entry(device).State = EntityState.Modified;

                        try
                        {
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!DeviceExists(id))
                            {
                                return NotFound();
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                    else
                        return Problem("Each gateway cannot have more than 10 devices, select another gateway");
                    //}
                }

                else
                {
                    _context.Entry(device).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DeviceExists(id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }else return Problem("the status is not written correctly");


            //else  }
            return NoContent();
        }
        #endregion

        #region POST Add

        // POST: api/Devices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Device>> PostDevice([FromBody]Device device)
        {
            if (DeviceExists(device.UID))
            {
                return NotFound();
            }
           // Además, no se permiten más de 10 dispositivos periféricos por puerta de enlace.
            if (IsStatusValidate(device.Status))
            {
                if(GatewayDevicesAreLessThanTen(device.GatewaySerialNumber))
                {
                    _context.Devices.Add(device);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetDevice", new { id = device.UID }, device); ;
                }
                else return Problem("Each gateway cannot have more than 10 devices, select another gateway");

            }
            else
                return Problem("the status is not written correctly");
        }
        #endregion

        #region Delete

        // DELETE: api/Devices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #endregion

        #region Validations

        private bool DeviceExists(int id)
        {
            return _context.Devices.Any(e => e.UID == id);
        }
        private int CountDevicesForGateway(string SerialNumber)
        {
            int count = _context.Devices.Where(d => d.GatewaySerialNumber == SerialNumber).ToList().Count();
            return count;
        }


        private bool GatewayDevicesAreLessThanTen(string SerialNumber)
        {            
            return (CountDevicesForGateway(SerialNumber) < 10);//Problen to solution
        }
        private bool SerialGatawayHadModifed(int id,string serialnumber)
        {
            return _context.Devices.Any(e => (e.UID == id) && (e.GatewaySerialNumber != serialnumber));
        }
        private bool IsStatusValidate(string Status)
        {
            if ((Status == "Online") || (Status == "Offline"))
            {
                return true;
            }
            else
                return false;

        }
        #endregion
    }
}
