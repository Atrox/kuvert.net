using System;

namespace Kuvert.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string? Logo { get; set; }
        public string Copyright { get; set; }
        public string TroubleText { get; set; }

        public string Signature { get; set; } = "Thanks";

        public Product()
        {
        }
        
        public Product(string name, string link)
        {
            Name = name;
            Link = link;

            Copyright = $"Copyright © {DateTime.Now.Year} {Name}. All rights reserved.";
            TroubleText =
                "If you’re having trouble with the button '{ACTION}', copy and paste the URL below into your web browser.";
        }
    }
}
