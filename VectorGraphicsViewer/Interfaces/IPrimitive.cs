using System.Collections.Generic;
using VectorGraphicsViewer.Models;

namespace VectorGraphicsViewer.Interfaces
{
    public enum PrimitiveType { Line = 2, Circle = 0, Triangle = 3}

    public interface IPrimitive
    {
        PrimitiveType Type { get; }
        Color Color { get; set; }
        bool? IsFilled { get; set; }
    }
}
