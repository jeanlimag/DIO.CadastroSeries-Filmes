using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroDeSeries.Interface
{
    public interface IRepositorio<T>
    {

        List<T> Lista();

        T RetornaPorId(int id);

        void Insere(T entidade);

        void Exclui(int id);

        void Atualiza(int id, T entidade);

        int ProximoId();

    }

    public interface IRepositorioFilmes<T>
    {
        List<T> ListaFilmes();

        T RetornaPorIdFilmes(int id);

        void InsereFilme(T entidade);

        void ExcluiFilme(int id);

        void AtualizaFilme(int id, T entidade);

        int ProximoIdFilmes();

    }
}
