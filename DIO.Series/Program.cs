// See https://aka.ms/new-console-template for more information

using DIO.Series.Classes;
using DIO.Series.Enum;

namespace DIO.Series
{
    public class Program
    {
        static SerieRepository repository = new SerieRepository();
        private static void ListSeries()
        {
            Console.WriteLine("Listar séries");

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach( var serie in list)
            {
                var deleted = serie.getDeleted();
                Console.WriteLine($"#ID {serie.Id}: - {serie.Title} {(deleted ? "* Excluido *" : "")}");
            }
        }

        private static void AddSerie()
        {
            foreach(int i in System.Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {System.Enum.GetName(typeof(Genre), i)}");
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repository.nextId(),
                genre: (Genre)entradaGenero,
                title: entradaTitulo,
                year: entradaAno,
                description: entradaDescricao);

            repository.Add(novaSerie);
        }

        private static void DeleteSerie()
        {
            Console.WriteLine("Digite o id da série: *");
            int indiceSerie = int.Parse(Console.ReadLine());

            repository.Delete(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repository.GetById(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void UpdateSerie()
        {
            Console.WriteLine("Digite o id da série: *");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in System.Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {System.Enum.GetName(typeof(Genre), i)}");
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie updateSerie = new Serie(id: repository.nextId(),
                genre: (Genre)entradaGenero,
                title: entradaTitulo,
                year: entradaAno,
                description: entradaDescricao);

            repository.Update(indiceSerie, updateSerie);
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor !!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }

        static void Main(string[] args)
        {
            string userOption = "";
            while (userOption.ToUpper() != "X")
            {
                userOption = GetUserOption();
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        AddSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}