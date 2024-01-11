using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceExchange.Services;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceExchange.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountryController : ControllerBase
    {
        private readonly ExcelDataReaderService excelDataReaderService;

        public CountryController(ExcelDataReaderService excelDataReaderService)
        {
            this.excelDataReaderService = excelDataReaderService;
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            var filePath = "Technical-Challange-Dataset.xlsx";
            var countries = excelDataReaderService.ReadCountriesFromExcel(filePath);
            return Ok(countries);
        }
    }
}
