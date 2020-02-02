using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace Database.Services
{
    public class DbService<Entidade> where Entidade : class
    {
        protected Func<DbContext> DbContext { get; set; }

        public DbService(Func<DbContext> contexto)
        {
            DbContext = contexto;
        }

        public virtual Entidade Criar(Entidade entidade)
        {
            using (DbContext contexto = DbContext.Invoke())
            {
                contexto.Set<Entidade>().Add(entidade);
                contexto.SaveChanges();
                return entidade;
            }
        }

        public virtual Entidade Atualizar(Entidade entidade)
        {
            using (DbContext contexto = DbContext.Invoke())
            {
                contexto.Set<Entidade>().Update(entidade);
                contexto.SaveChanges();
                return entidade;
            }
        }

        public virtual void Deletar(Entidade entidade)
        {
            using (DbContext contexto = DbContext.Invoke())
            {
                contexto.Set<Entidade>().Remove(entidade);
                contexto.SaveChanges();
            }
        }

        public virtual IEnumerable<Entidade> Buscar(Expression<Func<Entidade, bool>> expression)
        {
            using (DbContext contexto = DbContext.Invoke())
            {
                return contexto.Set<Entidade>().AsNoTracking().Where(expression);
            }
        }

        public virtual Entidade BuscarUm(Expression<Func<Entidade, bool>> expression)
        {
            using (DbContext contexto = DbContext.Invoke())
            {
                return contexto.Set<Entidade>().AsNoTracking().Where(expression).FirstOrDefault();
            }
        }
    }
}
