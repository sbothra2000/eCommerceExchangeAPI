using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using eCommerceExchange.Models;
using eCommerceExchange.Services;
using OfficeOpenXml;
using Xunit;

namespace eCommerceExchange.Tests
{
    public class ExcelDataReaderServiceTests
    {
        [Fact]
        public void ReadProductsFromExcel_ShouldReturnListOfProducts()
        {
            var excelDataReaderService = new ExcelDataReaderService();
            var filePath = "Technical-Challange-Dataset.xlsx";
            var products = excelDataReaderService.ReadProductsFromExcel(filePath);
            Assert.NotNull(products);
            Assert.NotEmpty(products);
        }

        [Fact]
        public void ReadCurrencyExchangeRatesFromExcel_ShouldReturnListOfExchangeRates()
        {
            var excelDataReaderService = new ExcelDataReaderService();
            var filePath = "Technical-Challange-Dataset.xlsx";
            var exchangeRates = excelDataReaderService.ReadCurrencyExchangeRatesFromExcel(filePath);
            Assert.NotNull(exchangeRates);
            Assert.NotEmpty(exchangeRates);
        }

        [Fact]
        public void ReadCountriesFromExcel_ShouldReturnListOfCountries()
        {
            var excelDataReaderService = new ExcelDataReaderService();
            var filePath = "Technical-Challange-Dataset.xlsx";
            var countries = excelDataReaderService.ReadCountriesFromExcel(filePath);
            Assert.NotNull(countries);
            Assert.NotEmpty(countries);
        }
    }
}
