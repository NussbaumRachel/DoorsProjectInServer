using System;
using System.Collections.Generic;

namespace Bl.Models;

public class BlDoorFrame
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
    public int? Price { get; set; }

    public bool Equals(BlDoorFrame d)
    {

        return Side.Equals(d.Side) &&
            Width.Equals(d.Width) &&
            Height.Equals(d.Height) &&
            WallFrameThickness.Equals(d.WallFrameThickness) &&
            Desc.Equals(d.Desc) &&
            Hinges.Equals(d.Hinges) &&
            PerforationTypeForShoeing.Equals(d.PerforationTypeForShoeing) &&
            Perforation.Equals(d.Perforation) &&
            FramesHeightWithShutter.Equals(d.FramesHeightWithShutter) &&
            Opening.Equals(d.Opening) &&
            Profile.Equals(d.Profile) &&
            Color.Equals(d.Color) &&
            Notes.Equals(d.Notes);
    }
}

