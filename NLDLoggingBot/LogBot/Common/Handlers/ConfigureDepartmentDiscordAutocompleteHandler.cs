using Application.Common.Interfaces;
using Discord.Interactions;
using Discord;
using Microsoft.EntityFrameworkCore;

namespace LogBot.Common.Handlers;

public class ConfigureDepartmentDiscordAutocompleteHandler : AutocompleteHandler
{
    private readonly IApplicationDbContext _context;

    public ConfigureDepartmentDiscordAutocompleteHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public override async Task<AutocompletionResult> GenerateSuggestionsAsync(IInteractionContext context, IAutocompleteInteraction autocompleteInteraction, IParameterInfo parameter, IServiceProvider services)
    {
        var departments = await _context.Department.ToListAsync();
        var results = departments.Select(department => 
            new AutocompleteResult($"{department.Name}", $"{department.Id}"));

        return AutocompletionResult.FromSuccess(results.Take(25));
    }
}
