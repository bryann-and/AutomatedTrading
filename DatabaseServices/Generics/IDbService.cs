using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DatabaseServices.Generics
{
    public interface IDbService<Entidade>
    {
        Entidade Criar(Entidade entidade);
        Entidade Atualizar(Entidade entidade);
        Entidade Deletar(Entidade entidade);

        IEnumerable<Entidade> Buscar(Expression<Func<Entidade, bool>> expression);
        IEnumerable<Entidade> BuscarUm(Expression<Func<Entidade, bool>> expression);
    }
}
