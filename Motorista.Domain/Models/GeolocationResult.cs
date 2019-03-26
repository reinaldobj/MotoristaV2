using System.Collections.Generic;
using Newtonsoft.Json;

namespace Motorista.Domain.Models
{
    public class GeolocationResult
    {
        public class Root
        {
            [JsonProperty(PropertyName = "results")]
            public List<CoordenadasResultado> Resultados { get; set; }
        }

        public class CoordenadasResultado
        {
            [JsonProperty(PropertyName = "geometry")]
            public Coordenadas Coordenadas { get; set; }
        }

        public class Coordenadas
        {
            [JsonProperty(PropertyName = "location")]
            public Localizacao Localizacao { get; set; }
        }

        public class Localizacao
        {
            [JsonProperty(PropertyName = "lat")]
            public double Latitude { get; set; }

            [JsonProperty(PropertyName = "lng")]
            public double Longitude { get; set; }
        }
    }
}
