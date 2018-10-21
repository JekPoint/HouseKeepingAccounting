using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseData;
using HouseData.Interfaces;
using HouseData.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseServices
{
    public class HouseService : IHouseAssets
    {
        private readonly HouseContext _context;

        public HouseService(HouseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получение списка всех домов
        /// </summary>
        /// <returns>Список домов</returns>
        public IEnumerable<House> GetAll()
        {
            if (!_context.Houses.Any())
                return null;

            return _context.Houses
            .Include(house => house.Counter)
            .Include(house => house.Counter.Indications);
        }

        /// <summary>
        /// Получение дома по его ID
        /// </summary>
        /// <param name="id">ID дома</param>
        /// <returns>Дом</returns>
        public House GetHousesById(int id)
        {
            return GetAll()?.FirstOrDefault(house => house.Id == id);
        }

        /// <summary>
        /// Получение всех домов в городе
        /// </summary>
        /// <param name="city">Город</param>
        /// <returns>Список домов</returns>
        public IEnumerable<House> GetHousesByCity(string city)
        {
            return GetAll()?.Where(house => house.City == city);
        }

        /// <summary>
        /// Получение списка домов по Городу и улице
        /// </summary>
        /// <param name="city">Город</param>
        /// <param name="street">Улица</param>
        /// <returns>Список домов</returns>
        public IEnumerable<House> GetHousesByCityAndStreet(string city, string street)
        {
            return GetHousesByCity(city)?.Where(house => house.Street == street);
        }

        /// <summary>
        /// Получение 1-го дома по его плному адресу
        /// </summary>
        /// <param name="city">Город</param>
        /// <param name="street">Улица</param>
        /// <param name="number">Номер дома</param>
        /// <returns>Дом</returns>
        public House GetHouseByCityAndStreetAndNumber(string city, string street, string number)
        {
            return GetHousesByCityAndStreet(city, street)?.FirstOrDefault(house => house.Number == number);
        }

        /// <summary>
        /// Добавление нового дома
        /// </summary>
        /// <param name="city">Город</param>
        /// <param name="street">Улица</param>
        /// <param name="number">Номер</param>
        /// <returns>Результат добавления дома</returns>
        public async Task<string> AddHouse(string city, string street, string number)
        {
            if (GetHouseByCityAndStreetAndNumber(city,street,number) != null)
                return "Not add. House Present.";

            var counter = new Counter()
            {
                FactoryNumber = "None",
                VerificationTimeOver = DateTime.Now,
                Indications = new List<Indication>()
                {
                    new Indication()
                    {
                        CurrentIndication = 0,
                        FillingTime = DateTime.Now,
                        PreviousIndication = 0
                    }
                }
            };

            var house = new House() {City = city, Street = street, Number = number, Counter = counter};

            _context.Add(counter);
            _context.Add(house);
            await _context.SaveChangesAsync();

            return "OK";
        }

        /// <summary>
        /// Удаление дома
        /// </summary>
        /// <param name="id">ID дома</param>
        /// <returns>Результат удаления дома.</returns>
        public string RemoveHouseById(int id)
        {
            var house = GetHousesById(id);
            if (house == null)
                return "House Not Fount.";

            _context.Houses.Remove(house);
            _context.SaveChanges();
            return "OK";
        }

        /// <summary>
        /// Замена счётчика на новый 
        /// </summary>
        /// <param name="houseId">ID дома</param>
        /// <param name="counter">Новый счётчик</param>
        /// <returns>Результат выполнения</returns>
        public string AddCounterToHouse(int houseId, Counter counter)
        {
            var house = GetHousesById(houseId);
            if (house == null)
                return "House Not Found";

            house.Counter = counter;
            _context.SaveChanges();
            return "OK";
        }



        /// <summary>
        /// Замена счётчика на новый
        /// </summary>
        /// <param name="houseId"></param>
        /// <param name="factoryNumber"></param>
        /// <param name="verificationTimeOver"></param>
        public void CounterInfoChange(int houseId, string factoryNumber, DateTime verificationTimeOver)
        {
            if (GetCounterByNumberAndverification(factoryNumber, verificationTimeOver) != null)
                return;

            var house = GetHousesById(houseId);
            if (house == null)
                return;

            var counter = new Counter()
            {
                FactoryNumber = factoryNumber,
                VerificationTimeOver = verificationTimeOver,
                Indications = new List<Indication>()
                {
                    new Indication()
                    {
                        CurrentIndication = 0,
                        FillingTime = DateTime.Now,
                        PreviousIndication = 0
                    }
                }
            };
            _context.Add(counter);
            house.Counter = counter;
            _context.SaveChanges();
        }

        public void IndicationAdd(int houseId, DateTime dateIndication, int newIndication)
        {
            var house = GetHousesById(houseId);
            if (house == null)
                return;
            var indication = new Indication
            {
                CurrentIndication = newIndication,
                FillingTime = dateIndication
            };

            if (house.Counter.Indications.Any())
                indication.PreviousIndication = house.Counter.Indications.Last().CurrentIndication;                  
            else
                indication.PreviousIndication = 0;

            _context.Add(indication);
            house.Counter.Indications.Add(indication);
            _context.SaveChanges();
        }

        private Counter GetCounterByNumberAndverification(string factoryNumber, DateTime verificationTimeOver)
        {
            return _context.Counters.FirstOrDefault(countering =>
                countering.FactoryNumber == factoryNumber && 
                countering.VerificationTimeOver == verificationTimeOver);
        }
    }
}
