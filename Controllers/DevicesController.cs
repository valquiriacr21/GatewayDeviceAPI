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
        private readonly AppDbContext _context;

        public DevicesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Devices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            return await _context.Devices.ToListAsync();
        }

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

        // PUT: api/Devices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice(int id, [FromBody]Device device)
        {
            if (id != device.UID)
            {
                return BadRequest();
            }
            int count = 0;

            var deviceCount = await _context.Devices.Where(d => d.GatewaySerialNumber == device.GatewaySerialNumber).ToListAsync();
            count = deviceCount.Count();
            if (count > 10) 
            {
                return Problem("Each gateway cannot have more than 10 devices, select another gateway");
            }
            //else
            //{
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
                //}
            }

            return NoContent();
        }

        // POST: api/Devices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Device>> PostDevice([FromBody]Device device)
        {
            //int id=device.UID;
            //var deviceContext = await _context.Devices.FindAsync(id);
            //if (deviceContext != null)
            //{
            //    return NotFound();
            //}
            //Además, no se permiten más de 10 dispositivos periféricos por puerta de enlace.
            
            int count = 0;
            
            var deviceCount = await _context.Devices.Where(d => d.GatewaySerialNumber == device.GatewaySerialNumber).ToListAsync();
            count = deviceCount.Count();
            if (count > 10) { return Problem("Each gateway cannot have more than 10 devices, select another gateway"); }
            else
            {
                _context.Devices.Add(device);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetDevice", new { id = device.UID }, device); ;
            }      
        }

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

        private bool DeviceExists(int id)
        {
            return _context.Devices.Any(e => e.UID == id);
        }
    }
}
