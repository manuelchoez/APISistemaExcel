using Serilog;
using SistemaExcel.Applicacion.Constantes;
using SistemaExcel.Applicacion.Mapper.Interfaces;
using SistemaExcel.Applicacion.Services.Interfaces;
using SistemaExcel.Applicacion.Util;
using SistemaExcel.Dominio.Entidades;
using SistemaExcel.Dominio.Model;
using SistemaExcel.Dominio.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Applicacion.Services
{
    public class UsersService : IUsersService
    {
        protected readonly IUsersRepository _usersRepository;
        protected readonly IMapear mapeador;
        protected readonly ILogger _log;
        protected readonly IToken _token;
        public UsersService(IUsersRepository usersRepository, IMapear mapeador, ILogger log, IToken token)
        {
            _usersRepository = usersRepository;
            this.mapeador = mapeador;
            _log = log.ForContext<UsersService>();
            _token = token;
        }



        public async Task<Response<UsersModel>> Login(UsersModel user)
        {
            try
            {
                UsersModel m = new UsersModel();
                Users  um = mapeador.mapper.Map<Users>(user);
                var resultado = await _usersRepository.Login(um);
                m = mapeador.mapper.Map<UsersModel>(resultado);
                if (resultado!=null)
                {
                    m.Token = _token.GenerarTokenJwt(m.UerName);
                }
                else
                {
                    m.Mensaje = ConstantesMensajes.MensajeLogin;
                }

                return Response<UsersModel>.Ok(m, m.Mensaje);
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Error Login");
                return Response<UsersModel>.Error(ex);
            }
        }
    }
}
