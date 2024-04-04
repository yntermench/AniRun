using AniRun.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace AniRun.Application.Models.FormModels;

public class FormTitle
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TimeSpan? Duration { get; set; }
    public DateTimeOffset StartDateTitle { get; set; }
    public DateTimeOffset? EndDateTitle { get;set; }
    public IFormFile? Picture { get; set; }
    public int? LastEpisode { get; set; }
    public TypeTitle Type { get; set; }
    public StatusTitle Status { get; set; }
    public Rating Rating { get; set; }
    
    public FormStudio? Studio { get; set; }
    
    public List<FormEpisode?> Episodes { get; set; } = new List<FormEpisode?>();
    public List<FormGenre> Genres { get; set; } = new List<FormGenre>();
}