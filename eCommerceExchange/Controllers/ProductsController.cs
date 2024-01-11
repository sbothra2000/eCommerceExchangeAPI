using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceExchange.Services;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceExchange.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ExcelDataReaderService excelDataReaderService;

        public ProductsController(ExcelDataReaderService excelDataReaderService)
        {
            this.excelDataReaderService = excelDataReaderService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var filePath = "Technical-Challange-Dataset.xlsx";
            var products = excelDataReaderService.ReadProductsFromExcel(filePath);
            return Ok(products);    
        }

    }
}



