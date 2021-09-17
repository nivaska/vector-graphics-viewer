using VectorGraphicsViewer.Interfaces;

namespace VectorGraphicsViewer.Models
{
    /// <summary>
    /// Model for Line Primitive
    /// </summary>
    public class PrimitiveLine : IPrimitiveLine
    {
        private Color _color;
        private Coordinate _start;
        private Coordinate _end;

        public PrimitiveLine(Coordinate start, Coordinate end, Color color)
        {
            this._color = color;
            this._start = start;
            this._end = end;
        }

        public Coordinate Start { get => this._start; set => this._start = value; }
        public Coordinate End { get => this._end; set => this._end = value; }

        public PrimitiveType Type => PrimitiveType.Line;
        public Color Color { get => this._color; set => this._color = value; }
        public bool? IsFilled { get => null; set {} }
    }
}
