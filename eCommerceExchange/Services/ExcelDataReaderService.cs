using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eCommerceExchange.Models;
using OfficeOpenXml;

namespace eCommerceExchange.Services
{
    public class ExcelDataReaderService
    {
        public List<Product> ReadProductsFromExcel(string filePath)
        {
            var products = new List<Product>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                {
                    var product = new Product
                    {
                        Name = worksheet.Cells[row, 1].Value?.ToString(),
                        Description = worksheet.Cells[row, 2].Value?.ToString(),
                        Price = Convert.ToDecimal(worksheet.Cells[row, 3].Value)
                    };
                    products.Add(product);
                }
            }
            return products;
        }
        public List<currencyExchangeRate> ReadCurrencyExchangeRatesFromExcel(string filePath)
        {
            var currencyExchangeRates = new List<currencyExchangeRate>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[1];

                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                {
                    var exchangeRate = new currencyExchangeRate
                    {
                        ExchangeRate = Convert.ToDecimal(worksheet.Cells[row, 1].Value),
                        CurrencyCode = worksheet.Cells[row, 2].Value?.ToString(),
                        ValidFromDate = Convert.ToDateTime(worksheet.Cells[row, 3].Value),
                        ValidToDate = Convert.ToDateTime(worksheet.Cells[row, 4].Value)
                    };
                    currencyExchangeRates.Add(exchangeRate);
                }
            }

            return currencyExchangeRates;
        }
        public List<country> ReadCountriesFromExcel(string filePath)
        {
            var countries = new List<country>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[2];

                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                {
                    var country = new country
                    {
                        Name = worksheet.Cells[row, 1].Value?.ToString(),
                        CountryCode = worksheet.Cells[row, 2].Value?.ToString(),
                        CurrencyCode = worksheet.Cells[row, 3].Value?.ToString()
                    };

                    countries.Add(country);
                }
            }

            return countries;
        }
    }
}
