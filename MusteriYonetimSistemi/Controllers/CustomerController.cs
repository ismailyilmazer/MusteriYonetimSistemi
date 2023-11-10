using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusteriYonetimSistemi.DataAccesLayer;
using MusteriYonetimSistemi.Model;

namespace MusteriYonetimSistemi.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly Context _context;
        public CustomerController(Context context)=>_context=context;

        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
            => await _context.Customers.ToListAsync();

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Customer customer)
        {
            await  _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), new { id = customer.Id }, customer);
        }

      
        
    }
}
