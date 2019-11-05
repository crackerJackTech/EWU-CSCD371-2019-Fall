// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "Console.WriteLine() statements in main are used for displaying in the command prompt and are not used as variables.", Scope = "member", Target = "~M:Mailbox.Program.Main")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix", Justification = "Naming convention for class file is acceptable for current assignment", Scope = "type", Target = "~T:Mailbox.Mailboxes")]
