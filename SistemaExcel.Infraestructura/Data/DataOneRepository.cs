
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SistemaExcel.Applicacion.Constantes;
using SistemaExcel.Dominio.Model;
using SistemaExcel.Dominio.Repository;
using SistemaExcel.Infraestructura.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Infraestructura.Data
{
    public class DataOneRepository: IDataOneRepository
    {        
        private readonly IConfiguration _configuration;

        public DataOneRepository(IConfiguration configuration)
        {            
            _configuration = configuration;
        }

        public async Task<bool> ActualizarDataOne(List<DataOneModel> model)
        {
            bool resultado = true;
            DataOne dataModel = new DataOne();                       
            if (model.Count()>0)
            {
                foreach (var item in model)
                {
                    dataModel = await Collection().Find(x=> x.Id == item.Id).FirstOrDefaultAsync();                                      
                    dataModel.Campook = item.Campook;
                    dataModel.Camporechazo = item.Camporechazo;
                    dataModel.FechaActualizacion = DateTime.Now.Date.ToShortDateString();                    
                    await Collection().ReplaceOneAsync(data => data.Id == item.Id, dataModel);
                }
            }
            return resultado;
        }

        public async Task<bool> CargarDataOne(List<DataOneModel> model)
        {
            bool resultado = true;
            DataOne dataModel = new DataOne();
            DataOne dataModelNew = new DataOne();
            if (model.Count() > 0)
            {
                foreach (var item in model)
                {
                    dataModel = await Collection().Find(x => x.CampoIdentificador == item.CampoIdentificador).FirstOrDefaultAsync();
                    if (dataModel!= null)
                    {
                        if (string.IsNullOrEmpty(dataModel.FechaActualizacion))
                        {
                            dataModel.FechaCarga = DateTime.Now.Date.ToShortDateString();
                            await Collection().ReplaceOneAsync(data => data.Id == item.Id, dataModel);
                        }
                    }
                    else
                    {
                        dataModelNew.Campodos = item.Campodos;
                        dataModelNew.CampoIdentificador = item.CampoIdentificador;
                        dataModelNew.Campouno = item.Campouno;
                        dataModelNew.Campook = item.Campook;
                        dataModelNew.Camporechazo = item.Camporechazo;
                        dataModelNew.FechaActualizacion = null;
                        dataModelNew.FechaCarga = DateTime.Now.Date.ToShortDateString();
                        await Collection().InsertOneAsync(dataModelNew);
                    }               
                }
            }
            return resultado;
        }

        public IMongoCollection<DataOne> Collection()
        {
            MongoClient cliente = new MongoClient(_configuration.GetSection(ConstantesConexion.Server).Value);
            IMongoDatabase database = cliente.GetDatabase(_configuration.GetSection(ConstantesConexion.Database).Value);
            IMongoCollection<DataOne> collections = database.GetCollection<DataOne>(_configuration.GetSection(ConstantesConexion.Collection).Value);
            return collections;
        }            

        public async Task<List<DataOneModel>> ConsultarDataOne()
        {
            List<DataOneModel> listaRetorno = new List<DataOneModel>() ;            
            var data  = await Collection().FindAsync(x => true).Result.ToListAsync();
            if (data.Count() > 0)
            {
                foreach (var item in data)
                {
                    listaRetorno.Add(new DataOneModel { Campodos = item.Campodos, CampoIdentificador = item.CampoIdentificador, Campook = item.Campook, Camporechazo = item.Camporechazo, Campouno = item.Campouno, FechaActualizacion = item.FechaActualizacion, Id = item.Id, FechaCarga = item.FechaCarga });
                }
            }
            return listaRetorno;
        }        

        
    }
}
