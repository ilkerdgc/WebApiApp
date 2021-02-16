using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        //aşağıda metotların üzerine yazılan üç / ifadesi ile Swagger arayüzünde api url lerinin yanına not yazabilmemiz için. bu işlem için birde şu yol izlenmelidir;
        //projede xml kodların yorumlanmasını sağlamak -> projeye sağ tıkla properties-Build-XML document file


        private IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            //_hotelService = new HotelMenager();
            _hotelService = hotelService;

        }

        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Hotel> Get()
        {
            return _hotelService.GetAllHotels(); // burada business katmanındaki fonksiyonu kullanıyoruz. 
        }

        /// <summary>
        /// Get Hotel By Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Hotel Get(int id)
        {
            return _hotelService.GetHotelById(id);
        }

        /// <summary>
        /// Create an Hotel
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Hotel Post([FromBody] Hotel hotel)
        {
            return _hotelService.CreateHotel(hotel);
        }

        /// <summary>
        /// Update the Hotel
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public Hotel Put([FromBody] Hotel hotel)
        {
            return _hotelService.UpdateHotel(hotel);
        }

        /// <summary>
        /// Delete the Hotel
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _hotelService.DeleteHotel(id);
        }
    }
}
