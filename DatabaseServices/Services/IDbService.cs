using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Database.Services
{
    public interface IDbService<Entidade>
    {
        Entidade Criar(Entidade entidade);
        Entidade Atualizar(Entidade entidade);
        void Deletar(Entidade entidade);

        IEnumerable<Entidade> Buscar(Expression<Func<Entidade, bool>> expression);
        Entidade BuscarUm(Expression<Func<Entidade, bool>> expression);
    }
}
