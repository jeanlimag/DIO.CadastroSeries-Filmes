using System;
using System.Collections.Generic;
using System.Text;
using CadastroDeSeries.Interface;

namespace CadastroDeSeries
{
    public class FilmeRepositorio : IRepositorioFilmes<Filmes>

    {
        private List<Filmes> listaFilmes = new List<Filmes>();
        public void AtualizaFilme(int id, Filmes objeto)
        {
            listaFilmes[id] = objeto;

        }

		public void ExcluiFilme(int id)
		{
			listaFilmes[id].Excluir();
		}

		public void InsereFilme(Filmes objeto)
		{
			listaFilmes.Add(objeto);
		}

		public List<Filmes> ListaFilmes()
		{
			return listaFilmes;
		}

		public int ProximoIdFilmes()
		{
			return listaFilmes.Count;
		}

		public Filmes RetornaPorIdFilmes(int id)
		{
			return listaFilmes[id];
		}
	}
}