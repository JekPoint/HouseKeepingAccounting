using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HouseKeepingAccounting.MVC.HouseData.Models;

namespace HouseKeepingAccounting.MVC.HouseData.Interfaces
{
    public interface IHouseAssets
    {
        /// <summary>
        /// Получение списка всех домов
        /// </summary>
        /// <returns>Список домов</returns>
        IEnumerable<House> GetAll();
        
        /// <summary>
        /// Получить дом по его ID  
        /// </summary>
        /// <param name="id">ID дома</param>
        /// <returns>Дом</returns>
        House GetHousesById(int id);
       
        /// <summary>
        /// Получить список всех домов, по городу
        /// </summary>
        /// <param name="city">Город</param>
        /// <returns>Список домов</returns>
        IEnumerable<House> GetHousesByCity(string city);

        /// <summary>
        /// Получить списов всех домов по Городу и улице
        /// </summary>
        /// <param name="city">Город</param>
        /// <param name="street">Улица</param>
        /// <returns>Список домов</returns>
        IEnumerable<House> GetHousesByCityAndStreet(string city, string street);

        /// <summary>
        /// Получить дом по городу, улице и номеру дома
        /// </summary>
        /// <param name="city">Город</param>
        /// <param name="street">Улица</param>
        /// <param name="number">Номер дома</param>
        /// <returns>Дом по адресу</returns>
        House GetHouseByCityAndStreetAndNumber(string city, string street, string number);

        /// <summary>
        /// Добавить дом.
        /// </summary>
        /// <param name="city">Город</param>
        /// <param name="street">Улица</param>
        /// <param name="number">Номер дома</param>
        /// <returns>Результат добавления дома.</returns>
        Task<string> AddHouse(string city, string street, string number);

        /// <summary>
        /// Добавление счётчика
        /// </summary>
        /// <param name="houseId">ID дома</param>
        /// <param name="counter">Новый Экземпляр счётчика</param>
        /// <returns>Результат добавления счётчика</returns>
        string AddCounterToHouse(int houseId, Counter counter);

        /// <summary>
        /// удаление дома по его id
        /// </summary>
        /// <param name="id">ID дома</param>
        /// <returns>Результат удаления дома.</returns>
        string RemoveHouseById(int id);

        /// <summary>
        /// Изменение параметров счётчиков
        /// </summary>
        /// <param name="houseId">ID счётчика</param>
        /// <param name="factoryNumber">Серийный номер счётчика</param>
        /// <param name="verificationTimeOver">Дата окончания поверки</param>
        void CounterInfoChange(int houseId, string factoryNumber, DateTime verificationTimeOver);

        /// <summary>
        /// Изменение информации о доме
        /// </summary>
        /// <param name="houseId">ID дома</param>
        /// <param name="city">Город</param>
        /// <param name="street">Улица</param>
        /// <param name="number">Номер дома</param>
        /// <returns></returns>
        Task<string> HouseInfoChange(int houseId, string city, string street, string number);


        /// <summary>
        /// Добавление показаний счёцика
        /// </summary>
        /// <param name="houseId">ID дома</param>
        /// <param name="dateIndication">Дата подачи показаний</param>
        /// <param name="newIndication">Новые показания счётчика</param>
        void IndicationAdd(int houseId, DateTime dateIndication, int newIndication);
    }
}
