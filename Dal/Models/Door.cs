using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Door
{
    public int Id { get; set; }

    public string? Side { get; set; }

    public int? Width { get; set; }

    public int? Height { get; set; }

    public int? Hinges { get; set; }

    public string? PerforationTypeForShoeing { get; set; }

    public string? Skylight { get; set; }

    public string? Perforation { get; set; }

    public string? ShoeingA { get; set; }

    public string? ShoeingB { get; set; }

    public string? ShoeingC { get; set; }

    public string? Finishing { get; set; }

    public string? Type { get; set; }

    public string? Opening { get; set; }

    public string? Color { get; set; }

    public string? Leaf { get; set; }

    public int? InternalLayoutWidth { get; set; }

    public int? InternalLayoutLength { get; set; }

    public int? ExternalLayoutWidth { get; set; }

    public int? ExternalLayoutLength { get; set; }

    public string? Notes { get; set; }

    public string? TextFileForTheMachine { get; set; }

    public bool? StatusArchive { get; set; }

    public string? ImageUrl { get; set; }

    public int? Price { get; set; }
}
