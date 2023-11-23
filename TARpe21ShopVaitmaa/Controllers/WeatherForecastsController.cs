using Microsoft.AspNetCore.Mvc;
using TARpe21ShopVaitmaa.Core.Dto.WeatherDtos;
using TARpe21ShopVaitmaa.Core.ServiceInterface;
using TARpe21ShopVaitmaa.Models.Weather;

namespace TARpe21ShopVaitmaa.Controllers
{
    public class WeatherForecastsController : Controller
    {
        private readonly IWeatherForecastsServices _weatherForecastServices;
        public WeatherForecastsController(IWeatherForecastsServices weatherForecastServices)
        {
            _weatherForecastServices = weatherForecastServices;
        }

        public IActionResult Index()
        {
            WeatherViewModel vm = new WeatherViewModel();
            return View(vm);
        }

        [HttpPost]
        public IActionResult ShowWeather()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecasts");
            }
            return View();
        }
        [HttpGet]
        public IActionResult City()
        {
            WeatherResultDto dto = new();
            WeatherViewModel vm = new();

            _weatherForecastServices.WeatherDetail(dto);

            vm.Date = dto.EffectiveDate;
            vm.EpochDate = dto.EffectiveEpochDate;
            vm.Severity = dto.Severity;
            vm.Text = dto.Text;
            vm.MobileLink = dto.MobileLink;
            vm.Link = dto.Link;
            vm.Category = dto.Category;

            vm.Temperature.Minimum.Value = dto.TempMinValue;
            vm.Temperature.Minimum.Unit = dto.TempMinUnit;
            vm.Temperature.Minimum.UnitType = dto.TempMinUnitType;

            vm.Temperature.Maximum.Value = dto.TempMinValue;
            vm.Temperature.Maximum.Unit = dto.TempMinUnit;
            vm.Temperature.Maximum.UnitType = dto.TempMinUnitType;

            vm.DayCycle.Icon = dto.DayIcon;
            vm.DayCycle.IconPhrase = dto.DayIconPhrase;
            vm.DayCycle.HasPrecipitation = dto.DayHasPrecipitation;
            vm.DayCycle.PrecipitationType = dto.DayPrecipitationType;
            vm.DayCycle.PrecipitationIntensity = dto.DayPrecipitationIntensity;

            vm.NightCycle.Icon = dto.NightIcon;
            vm.NightCycle.IconPhrase = dto.NightIconPhrase;
            vm.NightCycle.HasPrecipitation = dto.NightHasPrecipitation;
            vm.NightCycle.PrecipitationType = dto.NightPrecipitationType;
            vm.NightCycle.PrecipitationIntensity = dto.NightPrecipitationIntensity;

            return View(vm);

        }
    }
}
