using Microsoft.AspNetCore.Mvc;
using Registration_backend.Models.Entities;
using Registration_backend.Models.Interfaces;

namespace Registration_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        IAddressRepository addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        [HttpGet]
        public ActionResult<List<Address>> Get()
        {
            List<Address> address = addressRepository.Get();
            return address == null ? NotFound() : Ok(address);

        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Address> GetAddressById([FromRoute] int id)
        {
            var address = addressRepository.GetAddressById(id);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpPost]
        [Route("{id:int}")]
        public ActionResult<bool> AddAddress([FromRoute] int id, [FromBody] Address address)
        {
            if (address == null)
            {
                return NotFound();
            }

            return Ok(addressRepository.AddAddress(id, address));
        }

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult<bool> UpdateAddress([FromRoute] int id, [FromBody] Address updateAddress)
        {
            if (updateAddress == null)
            {
                return NotFound();
            }

            var existingAddress = addressRepository.UpdateAddress(id, updateAddress);

            return Ok(existingAddress);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult<bool> DeleteAddress([FromRoute] int id)
        {
            return Ok(addressRepository.DeleteAddress(id));
        }
    }
}
