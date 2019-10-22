using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public static class ExtensionMethods
    {
        public static string Speak(this object actor) =>

            
            actor switch
            {
                Raj { WomenArePresent: true } => new Raj().SpeakWhenWomenArePresent(),
                Raj r => r.SpeakWhenWomenAreNotPresent(),
                Sheldon s => s.Speak(),
                Penny p => p.Speak(),


                { } => throw new ArgumentException(message: "Not a known actor type", paramName: nameof(actor)),
                _ => throw new ArgumentNullException(nameof(actor))
            };
        
    }
}
