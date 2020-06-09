# Kuvert

[![Build Status](https://img.shields.io/endpoint.svg?url=https%3A%2F%2Factions-badge.atrox.dev%2Fatrox%2Fkuvert.net%2Fbadge&style=flat-square)](https://actions-badge.atrox.dev/atrox/kuvert.net/goto)
[![Latest Version](https://img.shields.io/nuget/v/Kuvert?style=flat-square)](https://www.nuget.org/packages/Kuvert/)
[![Coverage Status](https://img.shields.io/codecov/c/github/Atrox/kuvert.net.svg?style=flat-square)](https://codecov.io/gh/Atrox/kuvert.net)

Kuvert is a library that generates clean, responsive HTML & plain-text for sending transactional emails.

## Samples
TODO: images

## Installation

```
dotnet add package Kuvert
```

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
