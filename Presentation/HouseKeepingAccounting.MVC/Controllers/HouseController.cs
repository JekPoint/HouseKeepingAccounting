using System;
using System.Collections.Generic;
using System.Linq;
using HouseKeepingAccounting.MVC.HouseData.Interfaces;
using HouseKeepingAccounting.MVC.Models.Catalog;
using Microsoft.AspNetCore.Mvc;

namespace HouseKeepingAccounting.MVC.Controllers
{
    public class HouseController : Controller
    {
        private readonly IHouseAssets _houseAssets;

        public HouseController(IHouseAssets houseAssets)
        {
            _houseAssets = houseAssets;
        }

        public IActionResult Index()
        {
            var houseAssetModels = _houseAssets.GetAll();
            
            if (houseAssetModels == null)
                return View(CreateDefaultLstingModel());

            var listingResult = houseAssetModels
                .Select(result => new AssetIndexListingModel
                {
                    Id = result.Id,
                    HouseAddress = $"{result.City}, {result.Street}, {result.Number}",
                    HouseCounterFactorNumber = result.Counter.FactoryNumber.ToString(),
                    HouseCounterLastIndication = result.Counter.Indications.LastOrDefault()?.CurrentIndication.ToString(),
                    HouseCounterLastIndicationDate = result.Counter.Indications.LastOrDefault()?.FillingTime.ToLongDateString(),
                    HouseCounterVerificationTimeOver =  result.Counter.VerificationTimeOver.ToLongDateString() 
                });

            var model = new AssetIndexModel()
            {
                Status = "AddHouse",
                Assets = listingResult
            };
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var house = _houseAssets.GetHousesById(id);
            if (house == null)
                return View();

            var listingResult = house.Counter.Indications
                .Select(indications => new AssetDetailListingModel()
                {
                    Id = indications.Id,
                    FullAdress = $"{house.City}, {house.Street}, {house.Number}",
                    Indication = indications.CurrentIndication.ToString(),
                    IndicationDate = indications.FillingTime.ToLongDateString()
                });

            var model = new AssetDetailModel()
            {
                FullAdress = $"{house.City}, {house.Street}, {house.Number}",
                VerificationTimeOver = house.Counter.VerificationTimeOver,
                FactoryNumder = house.Counter.FactoryNumber,
                HouseId = house.Id,
                HouseCity = house.City,
                HouseNumber = house.Number,
                HousePlace = house.Street,
                CurrentDate = DateTime.Now,
                LastIndication = house.Counter.Indications.Last().CurrentIndication,
                Asset = listingResult
            };

            return View(model);
        }

        public IActionResult RemoveHouse(int id)
        {
            _houseAssets.RemoveHouseById(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult PlaceNewHouse(string newHouseCity, string newHouseStreet, string newHouseNumber)
        {
            if (string.IsNullOrEmpty(newHouseCity) ||
                string.IsNullOrEmpty(newHouseStreet) ||
                string.IsNullOrEmpty(newHouseNumber))
                return RedirectToAction("Index");

            _houseAssets.AddHouse(newHouseCity, newHouseStreet, newHouseNumber);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CounterInfoChange(string factoryNumder, DateTime verificationTimeOver, int houseId)
        {
            _houseAssets.CounterInfoChange(houseId, factoryNumder, verificationTimeOver);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult IndicationAdd(int lastIndication, int newIndication, int houseId)
        {
            if(newIndication < lastIndication)
                return RedirectToAction("Index");

            _houseAssets.IndicationAdd(houseId, DateTime.Now, newIndication);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult HouseInfoEdit(string houseCity, string housePlace, string HouseNumber, int houseId)
        {
            if (string.IsNullOrEmpty(houseCity) ||
                string.IsNullOrEmpty(housePlace) ||
                string.IsNullOrEmpty(HouseNumber))
                return RedirectToAction("Index");

            _houseAssets.HouseInfoChange(houseId, houseCity, housePlace, HouseNumber);
            return RedirectToAction("Index");
        }

        private AssetIndexModel CreateDefaultLstingModel()
        {
            var listAssetIndexModel = new List<AssetIndexListingModel>()
            {
                new AssetIndexListingModel()
                {
                    Id = 0,
                    HouseAddress = "",
                    HouseCounterFactorNumber = "",
                    HouseCounterLastIndication = "",
                    HouseCounterLastIndicationDate = ""
                }
            };
            return new AssetIndexModel() {Assets =  listAssetIndexModel };
        }
    }
}
 