using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        private HotelDbContext _hotelDbContext;
        public HotelRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public List<Hotel> GetAllHotels()
        {
            //using (var hotelDbContext = new HotelDbContext())
            //{
            //    return hotelDbContext.Hotels.ToList();
            //}

            return _hotelDbContext.Hotels.ToList();
        }

        public Hotel GetHotelById(int id)
        {
            return _hotelDbContext.Hotels.Where(x => x.Id == id).SingleOrDefault();

        }

        public Hotel CreateHotel(Hotel hotel)
        {
            _hotelDbContext.Hotels.Add(hotel);
            _hotelDbContext.SaveChanges();
            return hotel;
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            _hotelDbContext.Hotels.Update(hotel);
            _hotelDbContext.SaveChanges();
            return hotel;
        }

        public void DeleteHotel(int id)
        {
            _hotelDbContext.Hotels.Remove(GetHotelById(id));
            _hotelDbContext.SaveChanges();

        }
    }
}
