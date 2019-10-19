using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public static class ExtensionMethods
    {
        public static string Speak(object actor) =>

            actor switch
            {
                Raj { WomenArePresent: false } => "My name is Raj",
                Raj r => "*mumble",
                Sheldon s => "My name is Sheldon",
                Penny p => "My name is Penny",


                { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(actor)),
                _ => throw new ArgumentNullException(nameof(actor))
            };
        
    }
}
