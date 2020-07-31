namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using CarDealer.XMLHelper;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,

                    Books = a.AuthorsBooks
                    .Select(b => b.Book)
                    .OrderByDescending(b => b.Price)
                    .Select(b => new
                    {
                        BookName = b.Name,
                        BookPrice = $"{b.Price:F2}"
                    })
                    .ToArray()
                })
                .ToArray()
                .OrderByDescending(a => a.Books.Count())
                .ThenBy(a => a.AuthorName)
                .ToArray();

            string jsonResult = JsonConvert.SerializeObject(authors, Formatting.Indented);

            return jsonResult;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            const string rootElement = "Books";

            var oldestBooks = context.Books
                .Where(b => b.PublishedOn < date && (int)b.Genre == 3)
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Select(b => new ExportBooksDto
                {
                    Name = b.Name,
                    Date = b.PublishedOn.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    Pages = b.Pages
                })
                .Take(10)
                .ToArray();


            var xmlResult = XMLConverter.Serialize(oldestBooks, rootElement);

            return xmlResult;
        }
    }
}