namespace BookShop.DataProcessor.ImportDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection.Metadata;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;

    [XmlType("Book")]
    public class ImportBooksDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Range(1, 3)]
        [XmlElement("Genre")]
        public int Genre { get; set; }

        [Range(0.01, (double)decimal.MaxValue)]
        [XmlElement("Price")]
        public decimal Price { get; set; }

        [Range(5, 5000)]
        [XmlElement("Pages")]
        public int Pages { get; set; }

        [Required]
        [XmlElement("PublishedOn")]
        public string PublishedOn { get; set; }

    }
}
//<Book>
//    <Name>Hairy Torchwood</Name>
//    <Genre>3</Genre>
//    <Price>41.99</Price>
//    <Pages>3013</Pages>
//    <PublishedOn>01/13/2013</PublishedOn>
//  </Book>