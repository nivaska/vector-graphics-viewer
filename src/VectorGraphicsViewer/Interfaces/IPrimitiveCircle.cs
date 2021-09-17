using VectorGraphicsViewer.Models;

namespace VectorGraphicsViewer.Interfaces
{
    public interface IPrimitiveCircle : IPrimitive
    {
        Coordinate Center { get; set; }

        float Radius { get; set; }
        float Diameter { get; }

    }
}
