using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SistemaExcel.Applicacion.Constantes;
using SistemaExcel.Dominio.Entidades;
using SistemaExcel.Dominio.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Infraestructura.Data
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConfiguration _configuration;


        public UsersRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IMongoCollection<Users> Collection()
        {

            IMongoDatabase database = Conexion.GetDatabase(_configuration);
            IMongoCollection<Users> collections = database.GetCollection<Users>(_configuration.GetSection(ConstantesConexion.CollectionU).Value);
            return collections;
        }
        public async Task<Users> Login(Users users)
        {
            Users u = new Users();
            if (users!=null)
            {
                if (!string.IsNullOrEmpty(users.UerName) && !string.IsNullOrEmpty(users.Password))
                {
                    var x = await Collection().FindAsync(x=> true).Result.ToListAsync();
                    u = await Collection().FindAsync(x => x.UerName == users.UerName && x.Password == users.Password).Result.FirstOrDefaultAsync();
                }
            }
            return u;
        }        
    }
}
