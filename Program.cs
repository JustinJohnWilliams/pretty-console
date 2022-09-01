using Spectre.Console;

var rule = new Rule("[underline red]Hello[/], World!");
rule.AsciiBorder();
AnsiConsole.Write(rule);

AnsiConsole.Write(
    new FigletText($"Hello, World!")
        .LeftAligned()
        .Color(Color.Aquamarine1));

var name = AnsiConsole.Ask<string>("What's your [green]name[/]?");

AnsiConsole.WriteLine($"Hello {name}");

var fruits = AnsiConsole.Prompt(
    new MultiSelectionPrompt<string>()
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
        .InstructionsText("[grey](Press [blue](space)[/] to toggle a fruit, [green](enter)[/] to accept)[/]")
        .AddChoiceGroup("Berries", new[]
        {
            "Blackcurrant", "Blueberry", "Cloudberry",
            "Elderberry", "Honeyberry", "Mulberry"
        })
        .AddChoices(new[]
        {
            "Apple", "Apricot", "Avocado", "Banana",
            "Cherry", "Cocunut", "Date", "Dragonfruit", "Durian",
            "Egg plant",  "Fig", "Grape", "Guava",
            "Jackfruit", "Jambul", "Kiwano", "Kiwifruit", "Lime", "Lylo",
            "Lychee", "Melon", "Nectarine", "Orange", "Olive"
        }));


var age = AnsiConsole.Prompt(
    new TextPrompt<int>("How [green]old[/] are you?")
        .PromptStyle("green")
        .ValidationErrorMessage("[red]That's not a valid age[/]")
        .Validate(age =>
        {
            return age switch
            {
                <= 0 => ValidationResult.Error("[red]You must at least be 1 years old[/]"),
                >= 123 => ValidationResult.Error("[red]You must be younger than the oldest person alive[/]"),
                _ => ValidationResult.Success(),
            };
        }));

AnsiConsole.WriteLine($"{name} is {age} years old and likes {string.Join(", ", fruits)}");

try
{
    throw new ArgumentNullException("foo");
}
catch(Exception ex)
{
    AnsiConsole.WriteException(ex, ExceptionFormats.ShowLinks);
}