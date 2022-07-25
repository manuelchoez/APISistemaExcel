using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Infraestructura.Entidades
{
    public class DataOne
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("campoIdentificador")]
        public string? CampoIdentificador { get; set; }
        [BsonElement("campouno")]
        public string? Campouno { get; set; }
        [BsonElement("campodos")]
        public string? Campodos { get; set; }
        [BsonElement("campook")]
        public bool Campook { get; set; }
        [BsonElement("camporechazo")]
        public bool Camporechazo { get; set; }
        [BsonElement("fechaactualizacion")]
        public string? FechaActualizacion { get; set; }
        [BsonElement("fechacarga")]
        public string? FechaCarga { get; set; }
    }
}
