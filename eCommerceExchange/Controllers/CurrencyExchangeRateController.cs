using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceExchange.Services;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceExchange.Controllers
{
        [ApiController]
        [Route("api/currencyexchangerates")]
        public class CurrencyExchangeRateController : ControllerBase
        {
            private readonly ExcelDataReaderService excelDataReaderService;

            public CurrencyExchangeRateController(ExcelDataReaderService excelDataReaderService)
            {
                this.excelDataReaderService = excelDataReaderService;
            }

            [HttpGet]
            public IActionResult GetCurrencyExchangeRates()
            {
                var filePath = "Technical-Challange-Dataset.xlsx";
                var currencyExchangeRates = excelDataReaderService.ReadCurrencyExchangeRatesFromExcel(filePath);
                return Ok(currencyExchangeRates);
            }
        }
}
