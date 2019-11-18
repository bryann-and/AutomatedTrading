using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DatabaseServices.Generics
{
    public class DbService<Entidade> where Entidade : class
    {
        protected Func<DbContext> DbContext { get; set; }

        public DbService(Func<DbContext> contexto)
        {
            DbContext = contexto;
        }

        protected virtual Entidade Criar(Entidade entidade)
        {
            using (DbContext contexto = DbContext.Invoke())
            {
                contexto.Set<Entidade>().Add(entidade);
                contexto.SaveChanges();
                return entidade;
            }
        }

        protected virtual Entidade Atualizar(Entidade entidade)
        {
            using (DbContext contexto = DbContext.Invoke())
            {
                contexto.Set<Entidade>().Update(entidade);
                contexto.SaveChanges();
                return entidade;
            }
        }        

        protected virtual void Deletar(Entidade entidade)
        {
            using (DbContext contexto = DbContext.Invoke())
            {
                contexto.Set<Entidade>().Remove(entidade);
                contexto.SaveChanges();
            }
        }

        protected virtual IEnumerable<Entidade> Buscar(Expression<Func<Entidade, bool>> expression)
        {
            using (DbContext contexto = DbContext.Invoke())
            {
                return contexto.Set<Entidade>().AsNoTracking().Where(expression);
            }
        }

        protected virtual Entidade BuscarUm(Expression<Func<Entidade, bool>> expression)
        {
            using (DbContext contexto = DbContext.Invoke())
            {
                return contexto.Set<Entidade>().AsNoTracking().Where(expression).FirstOrDefault();
            }
        }
    }
}
