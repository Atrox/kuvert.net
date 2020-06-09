using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kuvert.Models;
using Kuvert.Templates;
using Xunit;

namespace Kuvert.Tests
{
    public class KuvertTest
    {
        [Fact]
        public async Task TestGeneralFunctionality()
        {
            var kuvert = new KuvertService(new RazorRenderer(), new KuvertDefaultTemplate(),
                new Product("Test Product", "https://example.com/product"));

            var (html, text) = await kuvert.Generate(new Email
            {
                PreHeader = "Pre header text...",
                Header = new Header
                {
                    Greeting = "Yo",
                    Name = "Test User"
                },
                Intros = new List<string>
                {
                    "Test Intro 1",
                    "Test Intro 2"
                },
                Dictionary = new List<(string, string)>
                {
                    ("key", "value"),
                    ("key2", "value2")
                },
                Actions = new List<EmailAction>
                {
                    new EmailAction
                    {
                        Instructions = "Test Instruction",
                        Button = new EmailButton
                        {
                            Text = "Test Button",
                            Link = "https://example.com/testbutton"
                        }
                    }
                },
                Outros = new List<string>
                {
                    "Test Outro 1",
                    "Test Outro 2"
                }
            });

            // product
            Assert.Contains("<a href=\"https://example.com/product\"", html);
            Assert.Contains("Test Product", html);
            Assert.Contains($"Copyright © {DateTime.Now.Year} Test Product. All rights reserved.", html);
            Assert.Contains("Thanks,", html);

            // preheader
            Assert.Contains("Pre header text...", html);

            // header
            Assert.Contains("<span>Yo Test User,</span>", html);

            // intros
            Assert.Contains("Test Intro 1", html);
            Assert.Contains("Test Intro 2", html);

            // dictionary
            Assert.Contains("<strong>key:</strong> value", html);
            Assert.Contains("<strong>key2:</strong> value2", html);

            // actions
            Assert.Contains("Test Instruction", html);
            Assert.Contains("Test Button", html);
            Assert.Contains("<a href=\"https://example.com/testbutton\"", html);

            // actions trouble links
            Assert.Contains(
                "If you’re having trouble with the button 'Test Button', copy and paste the URL below into your web browser.",
                html);

            // outros
            Assert.Contains("Test Outro 1", html);
            Assert.Contains("Test Outro 2", html);
        }
    }
}
