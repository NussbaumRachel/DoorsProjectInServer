using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class DoorFrame
{
    public int Id { get; set; }

    public string? Desc { get; set; }

    public string? Side { get; set; }

    public int? Width { get; set; }

    public int? Height { get; set; }

    public int? Hinges { get; set; }

    public int? WallFrameThickness { get; set; }

    public string? PerforationTypeForShoeing { get; set; }

    public string? Perforation { get; set; }

    public string? Opening { get; set; }

    public int? FramesHeightWithShutter { get; set; }

    public string? Profile { get; set; }

    public string? Color { get; set; }

    public string? Notes { get; set; }

    public string? TextFileForTheMachine { get; set; }

    public bool? StatusArchive { get; set; }

    public string? ImageUrl { get; set; }

    public int? Price { get; set; }
}
