using System;
using System.Globalization;

namespace VectorGraphicsViewer.Models
{
    public class Coordinate
    {
        private float _x;
        private float _y;

        public Coordinate(float x, float y)
        {
            this._x = x;
            this._y = y;
        }

        /// <summary>
        /// Constructor to initialize Coordinate by passing coordinate values as a string in the format "x;y"
        /// </summary>
        /// <param name="xy"></param>
        public Coordinate(string xy)
        {
            var inputSplit = xy?.Split(';');
            if (inputSplit?.Length == 2 &&
                float.TryParse(inputSplit[0], out float x) &&
                float.TryParse(inputSplit[1], out float y))
            {
                this._x = x;
                this._y = y;
            } else
            {
                throw new Exception("Invalid input values for Coordinate");
            }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public override string ToString()
        {
            return $"{_x.ToString(CultureInfo.InvariantCulture)},{_y.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
