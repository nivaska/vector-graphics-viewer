using System.Collections.Generic;
using VectorGraphicsViewer.Models;

namespace VectorGraphicsViewer.Interfaces
{
    public interface IPrimitivePolygon: IPrimitive
    {
        List<Coordinate> Coordinates { get; set; }
    }
}
