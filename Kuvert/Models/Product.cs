using System;

namespace Kuvert.Models
{
    public class Product
    {
        /// <summary>
        ///     Initialize product with the name and link
        /// </summary>
        /// <param name="name">name of your product/service</param>
        /// <param name="link">public link to your product/service</param>
        public Product(string name, string link)
        {
            Name = name;
            Link = link;

            Copyright = $"Copyright © {DateTime.Now.Year} {Name}. All rights reserved.";
            TroubleText =
                "If you’re having trouble with the button '{ACTION}', copy and paste the URL below into your web browser.";
        }

        /// <summary>
        ///     The name of your product/service
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Public link to your product/service
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        ///     Public link to a logo. This replaces the name in the header.
        /// </summary>
        public string? Logo { get; set; }

        /// <summary>
        ///     Copyright notice at the bottom of the email
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        ///     The help text that gets shown when actions are used in the email.
        /// </summary>
        public string TroubleText { get; set; }

        /// <summary>
        ///     Signature at the end of the email
        /// </summary>
        public string Signature { get; set; } = "Thanks";
    }
}
