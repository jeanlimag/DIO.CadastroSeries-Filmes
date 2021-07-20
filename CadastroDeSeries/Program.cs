using System;

namespace CadastroDeSeries
{
    class Program
    {
        static FilmeRepositorio repositoriofilmes = new FilmeRepositorio();
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "6":
                        MenuFilmes();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por usar nossos serviços.");
            Console.WriteLine();
        }


        private static void ExcluirSerie()
        {
            string SimName = SerieDelete();
            {
                while (SimName == "1")
                {
                    Console.Write("Digite o Id da Serie: ");
                    int indiceSerie = int.Parse(Console.ReadLine());
                    repositorio.Exclui(indiceSerie);
                    Console.WriteLine("Obrigado por usar nossos serviços.");
                    Console.WriteLine();
                    break;

                }
            }
        }
        private static string SerieDelete()
        {
            Console.WriteLine();
            Console.WriteLine("Tem certeza que desejar excluir ?");
            Console.WriteLine("1- Sim");
            Console.WriteLine("2- Não");
            string EscolhaUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return EscolhaUsuario;
        }

        public static void VisualizarSerie()
        {

            Console.WriteLine("Digite o Id da Serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);

        }


        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o Id da Serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string EntradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(
                id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: EntradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Lista Series");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Serie Cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: . {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Exlcuido" : ""));
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Nova Serie: ");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(
                id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);


            repositorio.Insere(novaSerie);


        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu dispor !!!");
            Console.WriteLine("Informe a opção desejada:");


            Console.WriteLine("1- Listar series");
            Console.WriteLine("2- Inserir Nova serie");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- Visualizar serie");
            Console.WriteLine("6- Menu de Filmes");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();


            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }


        private static void MenuFilmes()
        {

            string EscolhaUsuario = ObterEscolhaUsuario();
            while (EscolhaUsuario.ToUpper() != "X")
            {
                switch (EscolhaUsuario)
                {
                    case "1":
                        ListarFilmes();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                EscolhaUsuario = ObterEscolhaUsuario();
            }
            Console.WriteLine("Obrigado por usar nossos serviços.");
            Console.WriteLine();
        }

        private static void ListarFilmes()
        {
            Console.WriteLine("Lista Filmes");
            var lista = repositoriofilmes.ListaFilmes();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum Filme Encontrado.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: . {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Exlcuido" : ""));



            }




        }
        public static void VisualizarFilme()
        {
            Console.WriteLine("Digite o Id do Filme");
            int indiceFilme = int.Parse(Console.ReadLine());
            var filme = repositoriofilmes.RetornaPorIdFilmes(indiceFilme);
            Console.WriteLine(filme);

        }
        private static void InserirFilme()
        {
            Console.WriteLine("Inserir Novo Filme: ");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme : ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filmes novoFilme = new Filmes(
              id: repositoriofilmes.ProximoIdFilmes(),
              genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositoriofilmes.InsereFilme(novoFilme);


        }
        private static void AtualizarFilme()
        {
            Console.WriteLine("Digite o Id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string EntradaDescricao = Console.ReadLine();

            Filmes atualizarFilmes = new Filmes(
                id: indiceFilme,
                genero: (Genero)entradaGenero,
                 titulo: entradaTitulo,
                ano: entradaAno,
                descricao: EntradaDescricao);
            repositoriofilmes.AtualizaFilme(indiceFilme, atualizarFilmes);


        }



        private static string ObterEscolhaUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu dispor !!!");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar Filmes");
            Console.WriteLine("2- Inserir Novo Filme");
            Console.WriteLine("3- Atualizar Filme");
            Console.WriteLine("4- Excluir Filme");
            Console.WriteLine("5- Visualizar Filme");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();


            string EscolhaUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return EscolhaUsuario;

        }

        public static void ExcluirFilme()
        {
            string colName = ExcluiOpcao();


            {
                while (colName == "1")

                {
                    Console.Write("Digite o Id ");
                    int indiceFilme = int.Parse(Console.ReadLine());
                    repositoriofilmes.ExcluiFilme(indiceFilme);
                    Console.WriteLine("Obrigado por usar nossos serviços.");
                    Console.WriteLine();
                    break;


                }
            }

        }

        private static string ExcluiOpcao()
        {
            Console.WriteLine();
            Console.WriteLine("Tem certeza que desejar excluir ?");
            Console.WriteLine("1- Sim");
            Console.WriteLine("2- Não");
            string EscolhaUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return EscolhaUsuario;
        }
    }
}

