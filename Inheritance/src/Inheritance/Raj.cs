using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Raj : Actor
    {
        public bool WomenArePresent { get; set; }

        public string SpeakWhenWomenAreNotPresent()
        {
            return "My name is Raj";
        }

        public string SpeakWhenWomenArePresent()
        {
            return "*mumble*";
        }
    }
}