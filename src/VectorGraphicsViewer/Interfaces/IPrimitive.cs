using System.Collections.Generic;
using VectorGraphicsViewer.Models;

namespace VectorGraphicsViewer.Interfaces
{
    public enum PrimitiveType {Triangle = 3}

    public interface IPrimitive
    {
        Color Color { get; set; }
        bool? IsFilled { get; set; }
    }
}
