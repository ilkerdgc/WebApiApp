using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Concrete
{
    public class HotelMenager : IHotelService  // ilgili interface'i kalıtım alarak içeriğindeki metotları dolduruyoruz.
    {
        private IHotelRepository _hotelRepository;
        public HotelMenager(IHotelRepository hotelRepository) 
        {
            //_hotelRepository = new HotelRepository();
            _hotelRepository = hotelRepository; // dependency injection prensibine aykırı olan new ile bir nesne oluşturmamak için için dependency injection gereği startup da tanımlama yapıyoruz
        }


        public Hotel CreateHotel(Hotel hotel)
        {
            return _hotelRepository.CreateHotel(hotel); // bir alt katman olan dataAccess katmanındaki metodu kullanıyoruz. yani veritabanı işlemlerini burada değil dataAccess katmanında yapsın diyoruz.
        }

        public void DeleteHotel(int id)
        {
            _hotelRepository.DeleteHotel(id);
        }

        public List<Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAllHotels();
        }

        public Hotel GetHotelById(int id)
        {
            if (id > 0)
            {
                return _hotelRepository.GetHotelById(id);
            }
            else
            {
                throw new Exception("id can not less than 1");
            }

        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            return _hotelRepository.UpdateHotel(hotel);
        }
    }
}
