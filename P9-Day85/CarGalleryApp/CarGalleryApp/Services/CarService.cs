using CarGalleryApp.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CarGalleryApp.Services
{
    public class CarService
    {
        private readonly IMongoCollection<Car> cars;
        public CarService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("CarGalleryDb"));
            IMongoDatabase database = client.GetDatabase("CarGalleryDb");
            cars = database.GetCollection<Car>("Cars");
        }
        public List<Car> Get() => cars.Find(car => true).ToList();
        public Car Get(string id) => cars.Find(car => car.Id == id).FirstOrDefault();
        public Car Create(Car car)
        {
            cars.InsertOne(car);
            return car;
        }
        public void Update(string id, Car car) => cars.ReplaceOne(car => car.Id == id, car);
        public void Remove(Car removedCar) => cars.DeleteOne(car => car.Id == removedCar.Id);
        public void Remove(string id) => cars.DeleteOne(car => car.Id == id);
    }
}
