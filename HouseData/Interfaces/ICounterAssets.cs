using System;
using System.Collections.Generic;
using HouseData.Models;

namespace HouseData.Interfaces
{
    public interface ICounterAssets
    {
        /// <summary>
        /// Получение списка всех счётчиков
        /// </summary>
        /// <returns>Список счётчиков</returns>
        IEnumerable<Counter> GetAll();

        /// <summary>
        /// Получение счётчика по его id
        /// </summary>
        /// <param name="id">ID счётчика</param>
        /// <returns>Ссылка на счётчик</returns>
        Counter GetById(int id);

        /// <summary>
        /// Добавление нового счётчика в юазу данных
        /// </summary>
        /// <param name="counter">Счётчик для добавления</param>
        /// <returns>Результат попытки добавления</returns>
        string Add(Counter counter);

        /// <summary>
        /// Получить заводской номер счётчика
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetFactoryNumberById(int id);

        /// <summary>
        /// Получить дом по ID счётчика 
        /// </summary>
        /// <param name="id">ID счётчика</param>
        /// <returns>Дом</returns>
        House GetHouseById(int id);
    }
}