using System;

namespace VectorGraphicsViewer.Models
{
    public class Color
    {
        private short _r;
        private short _g;
        private short _b;
        private short _a;

        public Color(short a, short r, short g, short b)
        {
            this.A = a;
            this.R = r;
            this.G = g;
            this.B = b;
        }

        /// <summary>
        /// Constructor to initialize Color by passing the argb values as a string in the format "a;r;g;b"
        /// </summary>
        /// <param name="value"></param>
        public Color(string value)
        {
            var inputSplit = value.Split(';');
            if (inputSplit.Length == 4 &&
                short.TryParse(inputSplit[0], out short a) &&
                short.TryParse(inputSplit[1], out short r) &&
                short.TryParse(inputSplit[2], out short g) &&
                short.TryParse(inputSplit[3], out short b))
            {
                this.A = a;
                this.R = r;
                this.G = g;
                this.B = b;
            }
            else
            {
                throw new Exception("Invalid input values for Color");
            }
        }

        public short R
        {
            get { return _r; }
            set
            {
                if (this.IsValidValue(value)) _r = value;
                else throw new Exception("Invalid value for Color");
            }
        }

        public short G
        {
            get { return _g; }
            set
            {
                if (this.IsValidValue(value)) _g = value;
                else throw new Exception("Invalid value for Color");
            }
        }

        public short B
        {
            get { return _b; }
            set
            {
                if (this.IsValidValue(value)) _b = value;
                else throw new Exception("Invalid value for Color");
            }
        }

        public short A
        {
            get { return _a; }
            set
            {
                if (this.IsValidValue(value)) _a = value;
                else throw new Exception("Invalid value for Color");
            }
        }

        private bool IsValidValue(int value)
        {
            return value >= 0 && value <= 255;

        }

        public string HexCode
        {
            get
            {
                return this.ToString();
            }
        }

        public override string ToString()
        {
            return $"#{_a:X2}{_r:X2}{_g:X2}{_b:X2}";
        }
    }
}
