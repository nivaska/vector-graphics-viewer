using System;
using System.Collections.Generic;
using System.Linq;
using VectorGraphicsViewer.Interfaces;

namespace VectorGraphicsViewer.Models
{
    /// <summary>
    /// Model for Polygonal Primitives
    /// Supports the type "Traingle" now, can be extended to any other Polygon
    /// </summary>
    public class PrimitivePolygon : IPrimitivePolygon
    {
        private readonly PrimitiveType _primitiveType;
        private bool? _isFilled;
        private Color _color;
        private List<Coordinate> _coordinates;

        public PrimitivePolygon(PrimitiveType primitiveType, List<Coordinate> coordinates, bool? isFilled, Color color)
        {
            this._primitiveType = primitiveType;
            this._isFilled = isFilled;
            this._color = color;
            this.Coordinates = coordinates;
        }

        public PrimitiveType Type => this._primitiveType;
        public Color Color { get => this._color; set => this._color = value; }
        public bool? IsFilled { get => this._isFilled; set => this._isFilled = value; }
        public List<Coordinate> Coordinates
        {
            get => this._coordinates;
            set
            {
                if (this.IsCoordinatesValid(value))
                    this._coordinates = value;
                else
                    throw new Exception($"Invalid coordinate value for the type {this._primitiveType}");
            }
        }

        public string CoordinatesList
        {
            get => String.Join(" ", this._coordinates.Select(c => c.ToString()));
        }

        private bool IsCoordinatesValid(List<Coordinate> value)
        {
            if (value?.Count > 2 && value?.Count == (int)this._primitiveType)
                return true;
            
            return false;
        }

        public override string ToString()
        {
            return $"{this._primitiveType} - [{this.CoordinatesList}]";
        }
    }
}
