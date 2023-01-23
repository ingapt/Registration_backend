using Microsoft.AspNetCore.Mvc;
using Registration_backend.Models.Entities;
using Registration_backend.Models.Interfaces;

namespace Registration_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository addressRepository;

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

        [HttpGet("id")]
        public ActionResult<Address> GetAddressById([FromRoute] int id)
        {
            var address = addressRepository.GetById(id);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpPost]
        public ActionResult<bool> AddAddress([FromBody] AddressData address)
        {
            if (address == null)
            {
                return NotFound();
            }

            return Ok(addressRepository.AddAddress(address));
        }

        [HttpPut("City")]
        public ActionResult<Address> UpdateUserCity([FromQuery] int id, [FromQuery] string data)
        {
            var address = addressRepository.UpdateUserCity(id, data);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpPut("Street")]
        public ActionResult<Address> UpdateUserStreet([FromQuery] int id, [FromQuery] string data)
        {
            var address = addressRepository.UpdateUserStreet(id, data);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpPut("HouseNumber")]
        public ActionResult<Address> UpdateUserHouseNumber([FromQuery] int id, [FromQuery] string data)
        {
            var address = addressRepository.UpdateUserHouseNumber(id, data);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpPut("FlatNumber")]
        public ActionResult<Address> UpdateUserFlatNumber([FromQuery] int id, [FromQuery] string data)
        {
            var address = addressRepository.UpdateUserFlatNumber(id, data);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpDelete]
        public ActionResult<bool> DeleteAddress([FromQuery] int id)
        {
            var address = addressRepository.DeleteAddress(id);

            if (address == null)
            {
                return null;
            }

            return Ok(address);
        }
    }
}
