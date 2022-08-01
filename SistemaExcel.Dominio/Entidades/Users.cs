using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Dominio.Entidades
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("id")]
        public string? Id { get; set; }
        [BsonElement("username")]
        public string? UserName { get; set; }
        [BsonElement("password")]
        public string? Password { get; set; }
        [BsonElement("perfil")]
        public string? Perfil { get; set; }
    }
}
