using System.Collections.Generic;

namespace VectorGraphicsViewer.Interfaces
{
    public interface IInputReader
    {
        List<IPrimitive> GetAllPrimitives(string filePath);
    }
}
