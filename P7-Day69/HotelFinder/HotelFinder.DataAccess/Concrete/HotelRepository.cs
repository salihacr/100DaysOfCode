using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public Hotel CreateHotel(Hotel hotel)
        {
            using (var dbContext = new HotelDbContext())
            {
                dbContext.Hotels.Add(hotel);
                dbContext.SaveChanges();
                return hotel;
            }
        }

        public void DeleteHotel(int id)
        {
            using (var dbContext = new HotelDbContext())
            {
                var deletedHotel = GetHotelById(id);
                dbContext.Hotels.Remove(deletedHotel);
                dbContext.SaveChanges();
            }
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            using (var dbContext = new HotelDbContext())
            {
                return await dbContext.Hotels.ToListAsync();
            }
        }

        public Hotel GetHotelById(int id)
        {
            using (var dbContext = new HotelDbContext())
            {
                return dbContext.Hotels.Find(id);
            }
        }

        public Hotel GetHotelByName(string name)
        {
            using (var dbContext = new HotelDbContext())
            {
                return dbContext.Hotels.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
            }
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            using (var dbContext = new HotelDbContext())
            {
                dbContext.Hotels.Update(hotel);
                dbContext.SaveChanges();
                return hotel;
            }
        }
    }
}
