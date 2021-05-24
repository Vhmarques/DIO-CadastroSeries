using dio_cadastroSeries.Classes;
using System;
using dio_cadastroSeries.Enum;
using dio_cadastroSeries.Interfaces;

namespace dio_cadastroSeries
{
	class Program
	{
		static SerieRepositorio repositorio = new SerieRepositorio();
		static void Main(string[] args)
		{
			int opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario != 6)
			{
				switch (opcaoUsuario)
				{
					case 1:
						ListarSeries();
						break;
					case 2:
						InserirSerie();
						break;
					case 3:
						AtualizarSerie();
						break;
					case 4:
						ExcluirSerie();
						break;
					case 5:
						VisualizarSerie();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void ExcluirSerie()
		{
			Console.Write("═══════════════  4 EXCLUIR SERIE  ════════════════  \n\n\n");
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
			Console.WriteLine("\n\nOperação realizada com sucesso!!!\n\nPressione enter para continuar...");
			Console.ReadLine();
			Console.Clear();
		}

		private static void VisualizarSerie()
		{
			Console.Write("═══════════════  5 VISUALIZAR SERIE  ════════════════  \n\n\n");
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
			Console.WriteLine("\n\nPressione enter para continuar...");
			Console.ReadLine();
			Console.Clear();

		}

		private static void AtualizarSerie()
		{
			Console.Write("═══════════════  3 ATUALIZAR SERIE   ════════════════  \n\n\n");
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
			
			foreach (int i in System.Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
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
			Console.WriteLine("\n\nOperação realizada com sucesso!!!\n\nPressione enter para continuar...");
			Console.ReadLine();
			Console.Clear();
		}
		private static void ListarSeries()
		{
			Console.Write("═══════════════  1 CONSULTAR SERIES   ════════════════  \n\n");			

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
				var excluido = serie.retornaExcluido();

				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
			Console.WriteLine("\n\nPressione enter para continuar...");
			Console.ReadLine();
			Console.Clear();
		}

		private static void InserirSerie()
		{
			int Opcao;

			do
			{
				Console.Write("═══════════════  2 CADASTRAR SERIE   ════════════════  \n\n\n");
			Console.WriteLine("Inserir nova série");

			foreach (int i in System.Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
			}
			Console.Write("\nDigite o gênero entre as opções acima: ");
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
				Console.WriteLine("\n\nOperação realizada com sucesso!!!\n\nDigite 1 para novo cadastro ou 2 para retornar ao menu");
				Opcao = int.Parse(Console.ReadLine());
				Console.Clear();
			} while (Opcao != 2);
		}

		private static int ObterOpcaoUsuario()
		{			
				Console.WriteLine();
				Console.WriteLine("═════════════DIO Séries a seu dispor!!!════════════");
				Console.WriteLine("");
				Console.WriteLine("╔═══════════════ MENU DE OPÇÕES ════════════════╗    ");
				Console.WriteLine("║            1 CONSULTAR SERIES                 ║    ");
				Console.WriteLine("║                                               ║    ");
				Console.WriteLine("║            2 CADASTRAR SERIE                  ║    ");
				Console.WriteLine("║                                               ║    ");
				Console.WriteLine("║            3 ATUALIZAR SERIE                  ║    ");
				Console.WriteLine("║                                               ║    ");
				Console.WriteLine("║            4 EXCLUIR SERIE                    ║    ");
				Console.WriteLine("║                                               ║    ");
				Console.WriteLine("║            5 VISUALIZAR SERIE                 ║    ");
				Console.WriteLine("║                                               ║    ");
				Console.WriteLine("║            6 SAIR                             ║    ");
				Console.WriteLine("╚═══════════════════════════════════════════════╝    ");
				Console.WriteLine(" ");

				Console.Write("DIGITE UMA OPÇÃO : ");
				int Option = int.Parse(Console.ReadLine());
				Console.WriteLine();
				Console.Clear();
				return Option;						
		}
	}
}
