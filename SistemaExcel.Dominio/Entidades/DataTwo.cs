using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Dominio.Entidades
{
    public class DataTwo
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("id")]
        public string? Id { get; set; }
        [BsonElement("codigobddconsulting")]
        public int CodigoBddConsulting { get; set; }
        [BsonElement("unificacion")]
        public string? Unificacion { get; set; }
        [BsonElement("codtotal")]
        public string? CodTotal { get; set; }
        [BsonElement("nombreequipo")]
        public string? NombreEquipo { get; set; }
        [BsonElement("especificacionmodelo")]
        public string? EspecificacionModelo { get; set; }
        [BsonElement("fabricanteproduccion")]
        public string? FabricanteProduccion { get; set; }
        [BsonElement("lugaralmacenamiento")]
        public string? LugarAlmacenamiento { get; set; }       

    }
}
