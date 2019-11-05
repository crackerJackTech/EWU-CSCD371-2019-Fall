using System;

namespace Mailbox
{
    public class Mailbox
    {
        public Sizes Size { get; }
        public (int, int) Location { get; }
        public Person Owner { get; }

        public Mailbox(Person owner, ValueTuple<int, int> location, Sizes size)
        {
            Owner = owner;
            Location = location;
            Size = size;
        }

        public override string? ToString()
        {
            string defaultPrint = $"{Owner.ToString()} {Location.Item1},{Location.Item2}";


            if (Size == Sizes.PremiumSmall) return defaultPrint + $" {Sizes.Small} Premium";
            if (Size == Sizes.PremiumMedium) return defaultPrint + $" {Sizes.Medium} Premium";
            if (Size == Sizes.PremiumLarge) return defaultPrint + $" {Sizes.Large} Premium";

            if (Size < Sizes.PremiumSmall && Size > 0)
                return defaultPrint + $" {Size.ToString()}";

            return defaultPrint;



        }
    }
}