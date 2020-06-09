using System;
using System.Collections.Generic;

namespace Kuvert.Models
{
    public class Email
    {
        /// <summary>
        /// The intro text, invisible to the user, but most mail clients use it to show a short text below the subject
        /// </summary>
        public string? PreHeader { get; set; }

        /// <summary>
        /// Header
        /// </summary>
        public Header Header { get; set; } = new Header();

        /// <summary>
        /// Intro sentences, first displayed in the email
        /// </summary>
        public IList<string> Intros { get; set; } = new List<string>();

        /// <summary>
        /// A list of key+value (useful for displaying parameters/settings/personal info)
        /// </summary>
        public IList<ValueTuple<string, string>> Dictionary { get; set; } = new List<(string, string)>();

        /// <summary>
        /// Actions that the user will be able to execute via a button click
        /// </summary>
        public IList<EmailAction> Actions { get; set; } = new List<EmailAction>();

        /// <summary>
        /// Outro sentences, last displayed in the email
        /// </summary>
        public IList<string> Outros { get; set; } = new List<string>();
    }

    public class Header
    {
        public string? Greeting { get; set; } = "Hi";
        public string? Name { get; set; }

        public string? Custom { get; set; }
    }

    public class EmailAction
    {
        public string? Instructions { get; set; }
        public EmailButton Button { get; set; }
    }

    public class EmailButton
    {
        public string Text { get; set; }
        public string Link { get; set; }
    }
}
