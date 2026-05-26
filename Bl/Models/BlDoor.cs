using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Bl.Models;

public class BlDoor
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

    public String? TextFileForTheMachine { get; set; }

    public int? Price { get; set; }

    public bool? StatusArchive { get; set; }
    public string? ImageUrl { get; set; }


    public bool Equals(BlDoor d)
    {
        return Side.Equals(d.Side) &&
            Width.Equals(d.Width) &&
            Height.Equals(d.Height) &&
            Hinges.Equals(d.Hinges) &&
            PerforationTypeForShoeing.Equals(d.PerforationTypeForShoeing) &&
            Skylight.Equals(d.Skylight) &&
            Perforation.Equals(d.Perforation) &&
            ShoeingA.Equals(d.ShoeingA) &&
            ShoeingB.Equals(d.ShoeingB) &&
            ShoeingC.Equals(d.ShoeingC) &&
            Finishing.Equals(d.Finishing) &&
            Type.Equals(d.Type) &&
            Opening.Equals(d.Opening) &&
            Color.Equals(d.Color) &&
            Leaf.Equals(d.Leaf) &&
            InternalLayoutWidth.Equals(d.InternalLayoutWidth) &&
            InternalLayoutLength.Equals(d.InternalLayoutLength) &&
            ExternalLayoutWidth.Equals(d.ExternalLayoutWidth) &&
            ExternalLayoutLength.Equals(d.ExternalLayoutLength);

    }
}
