using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphicsViewer.Interfaces;
using VectorGraphicsViewer.Models;

namespace VectorGraphicsViewer.Services
{
    /// <summary>
    /// Reads the input JSON file and returns a list of Primitives defined in it
    /// </summary>
    public class JsonInputReader : IInputReader
    {
        public List<IPrimitive> GetAllPrimitives(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                throw new Exception("Invalid input file path.");

            var inputPrimitives = this.DeserializeInput(filePath);
            if (inputPrimitives == null)
                throw new Exception("Unable to read the input file.");

            // Maps the deserialized "PrimitiveInputModel" types to "IPrimitive" types
            return inputPrimitives.Select(i => i.MapToIPrimitive()).ToList();
        }

        private List<PrimitiveInputModel> DeserializeInput(string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                try
                {
                    var reader = new JsonTextReader(sr);
                    JsonSerializer se = new JsonSerializer();
                    return se.Deserialize<List<PrimitiveInputModel>>(reader);
                }
                catch (Exception ex)
                {
                    // log error
                    return null;
                }
            }
        }
    }


    /// <summary>
    /// Model created to help with the deserialisation of input JSON
    /// </summary>
    public class PrimitiveInputModel
    {
        public string type { get; set; }
        public string center { get; set; }
        public string radius { get; set; }
        public string filled { get; set; }
        public string color { get; set; }
        public string a { get; set; }
        public string b { get; set; }
        public string c { get; set; }

        public IPrimitive MapToIPrimitive()
        {
            switch (this.type)
            {

                case "line":
                    return new PrimitiveLine(
                        new Coordinate(this.a),
                        new Coordinate(this.b),
                        new Color(this.color)
                        );
                case "circle":
                    return new PrimitiveCircle(
                        new Coordinate(this.center),
                        float.Parse(this.radius),
                        this.filled == "true",
                        new Color(this.color)
                        );

                case "triangle":
                    return new PrimitivePolygon(
                        PrimitiveType.Triangle,
                        new List<Coordinate>() {
                                new Coordinate(this.a),
                                new Coordinate(this.b),
                                new Coordinate(this.c),
                        },
                        this.filled == "true",
                        new Color(this.color)
                        );

                default: return null;
            }
        }

    }
}
