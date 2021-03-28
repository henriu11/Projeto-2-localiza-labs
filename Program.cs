using System;

namespace Localiza_labs_2
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
		static FilmeeRepositorio repositorio1 = new FilmeeRepositorio();
		
        static void Main(string[] args)
        {
			string Escolha = EscolhaRepositorio();
			while (Escolha.ToUpper() != "X")
			{
				switch (Escolha)
					{
						case "1":
							string opcaoUsuario = ObterOpcaoUsuario(Escolha);

							while (opcaoUsuario.ToUpper() != "X")
							{
								switch (opcaoUsuario)
								{
									case "1":
										Listar(Escolha);
										break;
									case "2":
										Inserir(Escolha);
										break;
									case "3":
										Atualizar(Escolha);
										break;
									case "4":
										Excluir(Escolha);
										break;
									case "5":
										Visualizar(Escolha);
										break;
									case "C":
										Console.Clear();
										break;

									default:
										throw new ArgumentOutOfRangeException();
								}

								opcaoUsuario = ObterOpcaoUsuario(Escolha);
							}
							Console.WriteLine("Retornando ao menu anterior");
							Console.ReadLine();
							break;
						case "2":
							opcaoUsuario = ObterOpcaoUsuario(Escolha);

							while (opcaoUsuario.ToUpper() != "X")
							{
								switch (opcaoUsuario)
								{
									case "1":
										Listar(Escolha);
										break;
									case "2":
										Inserir(Escolha);
										break;
									case "3":
										Atualizar(Escolha);
										break;
									case "4":
										Excluir(Escolha);
										break;
									case "5":
										Visualizar(Escolha);
										break;
									case "C":
										Console.Clear();
										break;

									default:
										throw new ArgumentOutOfRangeException();
								}

								opcaoUsuario = ObterOpcaoUsuario(Escolha);
							}
							Console.WriteLine("Retornando ao menu anterior");
							Console.ReadLine();
							break;
						case "C":
							Console.Clear();
							break;
						default:
						throw new ArgumentOutOfRangeException();
					}
				Escolha = EscolhaRepositorio();
			}
			Console.WriteLine("saindo do programa");
			Console.ReadLine();
		}
			  
		
	    private static void Excluir(string Escolha)
		{
			if (Escolha=="1"){
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.Write("Tem certeza que quer excluir serie {0} S/N:",serie.retornaTitulo());
            var confirmacao = (Console.ReadLine());
            if (confirmacao.ToUpper()== "S")
			{
                repositorio.Exclui(indiceSerie);

            }
			}
			else{
			Console.Write("Digite o id do Filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());
            var Filme = repositorio1.RetornaPorId(indiceFilme);
            Console.Write("Tem certeza que quer excluir Filme {0} S/N:",Filme.retornaTitulo());
            var confirmacao = (Console.ReadLine());
            if (confirmacao.ToUpper()== "S")
			{
                repositorio1.Exclui(indiceFilme);
			}
			}
		}

        private static void Visualizar(string Escolha)
		{
			
			if (Escolha=="1"){
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
			}
			else
			{Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio1.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
			}
		}

        private static void Atualizar(string Escolha)
		{
			if (Escolha=="1"){
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
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

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
			}
			else{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
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

			Filme atualizaSerie = new Filme(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio1.Atualiza(indiceSerie, atualizaSerie);
			}
		}

        private static void Inserir(string Escolha)
		{
			if (Escolha=="1")
			{
				int indiceSerie=repositorio.ProximoId();
				Console.WriteLine("Inserir novo Título");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
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

				Serie novaSerie = new Serie(id: repositorio.ProximoId(),
											genero: (Genero)entradaGenero,
											titulo: entradaTitulo,
											ano: entradaAno,
											descricao: entradaDescricao);

				repositorio.Insere(novaSerie);
				}
			else
			{
				int indiceSerie=repositorio.ProximoId();
				Console.WriteLine("Inserir nova série");

				// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
				// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
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

				Filme novaSerie = new Filme(id: repositorio1.ProximoId(),
											genero: (Genero)entradaGenero,
											titulo: entradaTitulo,
											ano: entradaAno,
											descricao: entradaDescricao);

				repositorio1.Insere(novaSerie);
			}
		}

        private static void Listar(string Escolha)
		{
			if (Escolha=="1")
			{
				Console.WriteLine("Listar séries");

				var lista = repositorio.Lista();

				if (lista.Count == 0)
				{
					Console.WriteLine("Nenhuma série cadastrada.");
						return;
				}

				foreach (var serie in lista)
				{
           	     var excluido = serie.retornaExcluido();
                
					Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido?"Excluido" : ""));
				}
			}
			else
			{
				Console.WriteLine("Listar séries");

				var lista = repositorio1.Lista();

				if (lista.Count == 0)
				{
					Console.WriteLine("Nenhuma série cadastrada.");
						return;
				}

				foreach (var Filme in lista)
				{
           	     var excluido = Filme.retornaExcluido();
                
					Console.WriteLine("#ID {0}: - {1} {2}", Filme.retornaId(), Filme.retornaTitulo(), (excluido?"Excluido" : ""));
				}
			}
		}
         private static string ObterOpcaoUsuario(string Escolha)
		{
			if (Escolha=="1"){
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Voltar ao menu anterior");
			Console.WriteLine();
			}
			else{
				Console.WriteLine();
			Console.WriteLine("DIO Filmes a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Filmes");
			Console.WriteLine("2- Inserir nova Filme");
			Console.WriteLine("3- Atualizar Filme");
			Console.WriteLine("4- Excluir Filme");
			Console.WriteLine("5- Visualizar Filme");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Voltar ao menu anterior");
			Console.WriteLine();
			}
			

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
		private static string EscolhaRepositorio()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries ou Filmes a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Se quer manipular lista de Séries.");
			Console.WriteLine("2- Se quer manipular lista de Filmes.");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();
			string repositorio = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return repositorio;
		}
    }
}
