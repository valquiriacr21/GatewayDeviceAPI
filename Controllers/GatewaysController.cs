using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GatewayDeviceAPI.Models;
using System.Net;

namespace GatewayDeviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewaysController : ControllerBase
    {
        #region Fields
        private readonly AppDbContext _context;
        #endregion

        #region Methods and Public Verbs

        public GatewaysController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Gateways
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gateway>>> GetGateways()
        {
            ///private IEnumerable<Gateway> gateways = new List<Gateway>();
            //gateways=await _context.Gateways.ToListA();
            //gateways

            //foreach (var gateway in _context.Gateways)
            //{
            //    gateways= await _context.Gateways.Where(g => g.SerialNumber == id).Include(d => d.Devices).FirstAsync();
            //var gateway = await _context.Gateways.Where(g => g.SerialNumber == _context.Gateways.).Include(d => d.Devices).FirstAsync();
            //var gateway = await _context.Gateways.Select(g=>g.SerialNumber).Include(d => d.Devices).ToListAsync();
            return await _context.Gateways.ToListAsync();
        }

        // GET: api/Gateways/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gateway>> GetGateway(int id)
        {
            // var gateway = await _context.Gateways.FindAsync(id);
            var gateway = await _context.Gateways.Where(g => g.SerialNumber == id).Include(d => d.Devices).FirstAsync();

            if (gateway == null)
            {
                return NotFound();
            }

            return gateway;
        }
        // GET: api/Gateways/name
        [HttpGet("Name={name}")]
        //[Route("{name}")]
        public async Task<ActionResult<IEnumerable<Gateway>>> GetGatewaysByName(string name)
        {
            // var gateway = await _context.Gateways.FindAsync(id);
            var gateways = await _context.Gateways.Where(g => g.Name == name).Include(d => d.Devices).ToListAsync();

            if (gateways == null)
            {
                return NotFound();
            }

            return gateways;
        }

        // GET: api/Gateways/Ipv4
        [HttpGet("IPv4={Ipv4}")]
        //[Route("{Ipv4}")]
        public async Task<ActionResult<IEnumerable<Gateway>>> GetGatewaysByIPv4(string Ipv4)
        {
            // var gateway = await _context.Gateways.FindAsync(id);
            var gateways = await _context.Gateways.Where(g => g.IPV4 == Ipv4).Include(d => d.Devices).ToListAsync();

            if (gateways == null)
            {
                return NotFound();
            }

            return gateways;
        }

        // PUT: api/Gateways/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGateway(int id, [FromBody]Gateway gateway)
        {
            if (id != gateway.SerialNumber)
            {
                return BadRequest();
            }
            if (CheckIPv4Valid(gateway.IPV4) /*&& (IsIPv4NotExist(gateway.IPV4))*/)
            {
                _context.Entry(gateway).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GatewayExists(id))
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
            {
                return Problem("You need to write the correct IPv4 address.");
            }
            return NoContent();
        }

        // POST: api/Gateways
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gateway>> PostGateway([FromBody]Gateway gateway)
        {
            if (CheckIPv4Valid(gateway.IPV4)/*&&(IsIPv4NotExist(gateway.IPV4))*/)
            {
                _context.Gateways.Add(gateway);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetGateway", new { id = gateway.SerialNumber }, gateway);
            }else
            { 
                //return BadRequest("You need to write a good ipv4");
                return Problem("You need to write the correct IPv4 address.");
            }
            
        }

        // DELETE: api/Gateways/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGateway(int id)
        {
            var gateway = await _context.Gateways.FindAsync(id);
            if (gateway == null)
            {
                return NotFound();
            }

            _context.Gateways.Remove(gateway);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
        #region Privete Methods
        private bool GatewayExists(int id)
        {
            return _context.Gateways.Any(e => e.SerialNumber == id);
        }

        private bool CheckIPv4Valid(string strIPv4)
        {
            //  Split string by ".", check that array length is 3
            char chrFullStop = '.';
            string[] arrOctets = strIPv4.Split(chrFullStop);
            if (arrOctets.Length != 4)
            {
                return false;
            }
            //  Check each substring checking that the int value is less than 255 and that is char[] length is !> 2
            Int16 MAXVALUE = 255;
            Int32 tempNumber; // Parse returns Int32
            Int32 tempNumberCero;
            tempNumberCero = int.Parse(arrOctets[0]);
            if (tempNumberCero <= 0)
            {
                return false;
            }
            foreach (string strOctet in arrOctets)
            {
                if (strOctet.Length > 3)
                {
                    return false;
                }
                tempNumber = int.Parse(strOctet);
                if ((tempNumber > MAXVALUE))
                {
                    return false;
                }
            }
            return true;
        }
        //public bool IsIPv4NotExist(Gateway gateway)
        //{
        //    List<Gateway> gateways = new List<Gateway>();
        //    gateways = _context.Gateways.ToList();
        //    foreach (Gateway gatewayhere in gateways)
        //    {  
        //        if(gatewayhere.IPV4 == gateway.IPV4)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
        #endregion

    }
}
