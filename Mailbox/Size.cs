using System;

namespace Mailbox 
{
    [Flags]
    public enum Sizes
    {
        None = 0b_0000,
        Small = 0b_0001,
        Medium = 0b_0010,
        Large = 0b_0100
    };
}
