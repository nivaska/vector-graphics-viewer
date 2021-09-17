using VectorGraphicsViewer.Models;

namespace VectorGraphicsViewer.Interfaces
{
    public interface IPrimitiveLine: IPrimitive
    {
        Coordinate Start { get; set; }
        Coordinate End { get; set; }

    }
}
