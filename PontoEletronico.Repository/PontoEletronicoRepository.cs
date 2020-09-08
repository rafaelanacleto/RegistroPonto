using System.Linq;
using System.Threading.Tasks;
using PontoEletronico.Domain;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System;

namespace PontoEletronico.Repository
{
    public class PontoEletronicoRepository : IPontoEletronicoRepository
    {
        private readonly PontoEletronicoContext _context;

        public PontoEletronicoRepository(PontoEletronicoContext context)
        {
            this._context = context;
            this._context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        void IPontoEletronicoRepository.Add<T>(T entity)
        {
            _context.Add(entity);
        }

        void IPontoEletronicoRepository.Delete<T>(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<PontoRegistro[]> GetAllPontoRegistroAsync()
        {
            IQueryable<PontoRegistro> query = _context.PontoRegistros;
            query = query.OrderBy(c => c.Id);
            return await query.ToArrayAsync();
        }

        public async Task<PontoRegistro> GetAllPontoAsyncById(Guid PontoID)
        {
            IQueryable<PontoRegistro> query = _context.PontoRegistros;

            query = query.OrderByDescending(c => c.Nome)
                        .Where(c => c.Id == PontoID);
            return await query.FirstOrDefaultAsync();
        }

        async Task<bool> IPontoEletronicoRepository.SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        void IPontoEletronicoRepository.Update<T>(T entity)
        {
            _context.Update(entity);
        }
    }
}