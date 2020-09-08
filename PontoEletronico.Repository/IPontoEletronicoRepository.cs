using System;
using System.Threading.Tasks;
using PontoEletronico.Domain;

namespace PontoEletronico.Repository
{
    public interface IPontoEletronicoRepository
    {
        //GERAL
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveChangesAsync();

         //PontoEletronico
         Task<PontoRegistro[]> GetAllPontoRegistroAsync();
         Task<PontoRegistro> GetAllPontoAsyncById(Guid PontoID);
    }
}