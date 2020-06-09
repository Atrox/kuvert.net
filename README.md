# Kuvert

Kuvert is a library that generates clean, responsive HTML & plain-text for sending transactional emails.

## Samples
TODO: images

## Installation

### Dependency Injection

You can configure Kuvert in `Startup.cs`. Now `IKuvert` will be correctly injected.
```csharp
services.AddKuvert(options =>
{
    options.Product = new Product("my product", "https://example.com"));
}).AddDefaultTemplate();
```

## Usage
TODO: usage

```csharp

var (html, text) = await kuvert.Generate(
    new Email()
    {
        PreHeader = "Pre header text...",
        Header = new Header()
        {
            Greeting = "Hey",
            Name = "Test User",
        },
        Intros = new List<string>()
        {
            "Test Intro 1",
            "Test Intro 2"
        },
        Dictionary = new List<(string, string)>()
        {
            ("key", "value"),
            ("key2", "value2"),
        },
        Actions = new List<EmailAction>()
        {
            new EmailAction()
            {
                Instructions = "Test Instruction",
                Button = new EmailButton()
                {
                    Text = "Test Button",
                    Link = "https://example.com/testbutton"
                }
            }
        },
        Outros = new List<string>()
        {
            "Test Outro 1",
            "Test Outro 2"
        },
    }
);

```
