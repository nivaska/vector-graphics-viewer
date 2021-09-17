using VectorGraphicsViewer.Interfaces;

namespace VectorGraphicsViewer.Models
{
    public class PrimitiveCircle : IPrimitiveCircle
    {
        private bool? _isFilled;
        private Color _color;
        private Coordinate _center;
        private float _radius;

        public PrimitiveCircle(Coordinate center, float radius, bool isFilled, Color color)
        {
            this._center = center;
            this._radius = radius;
            this._isFilled = isFilled;
            this._color = color;
        }

        public PrimitiveType Type => PrimitiveType.Circle;
        public Color Color { get => this._color; set => this._color = value; }
        public bool? IsFilled { get => this._isFilled; set => this._isFilled = value; }
        public Coordinate Center { get => this._center; set => this._center = value; }
        public float Radius { get => this._radius; set => this._radius = value; }


        #region Properties required for binding in XAML 

        public float Diameter => this._radius * 2;
        public float XPos => this._center.X - this._radius;
        public float YPos => this._center.Y - this._radius;
        
        #endregion

        public override string ToString()
        {
            return this.Type.ToString();
        }
    }
}
