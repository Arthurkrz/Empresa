using System;

namespace Empresa
{
    class Program
    {
        static void Main(string[] args)
        {
            bool controle = true;
            while (controle)
            {
                Console.WriteLine("Bem vindo ao sistema da NGX!\n\nQuantos funcionários deseja adicionar na lista?");
                int tamanho = int.Parse(Console.ReadLine());
                Console.Clear();
                Funcionario[] funcionarios = new Funcionario[tamanho];
                int i = 0;
                while (i < tamanho)
                {
                    Console.WriteLine("Insira, linha a linha, o nome do funcionário, " +
                    "o valor de cada hora trabalhada e quantas horas o funcionário trabalhou:");
                    string nome = Console.ReadLine();
                    double precoHora = double.Parse(Console.ReadLine());
                    int hora = int.Parse(Console.ReadLine());
                    Console.Clear();
                    if (Funcionario.Validar(nome, hora, precoHora))
                    {
                        bool terceirizado = false;
                        bool loop = true;
                        while (loop)
                        {
                            Console.WriteLine($"Funcionário {nome}, trabalhou {hora} horas por {precoHora} cada.");
                            Console.WriteLine("O funcionário é terceirizado ('s'/'n')?");
                            string escolha = Console.ReadLine().ToLower();
                            Console.Clear();
                            double despesa;
                            if (escolha == "s")
                            {
                                terceirizado = true;
                                loop = false;
                            }
                            else if (escolha == "n")
                            {
                                terceirizado = false;
                                loop = false;
                            }
                            else
                            {
                                Console.WriteLine("Resposta inválida.|");
                                Console.WriteLine(new string('-', 19));
                                Console.WriteLine("");
                            }
                        }
                        if (terceirizado)
                        {
                            FuncionarioTerceirizado ft = new FuncionarioTerceirizado(nome);
                            ft.Despesa = ft.Calculo(hora, precoHora, true);
                            funcionarios[i] = ft;
                        }
                        else
                        {
                            Funcionario f = new Funcionario(nome);
                            f.Despesa = f.Calculo(hora, precoHora, false);
                            funcionarios[i] = f;
                        }
                        i++;
                        if (i < tamanho)
                        {
                            Console.Clear();
                            Console.WriteLine("Deseja adicionar outro funcionário ('s'/'n')?");
                            string escolha2 = Console.ReadLine();
                            if (escolha2 == "n")
                            {
                                Console.Clear();
                                break;
                            }
                            else if (escolha2 == "s")
                            {
                                Console.Clear();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Resposta inválida.|");
                                Console.WriteLine(new string('-', 19));
                                Console.WriteLine("");
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ocorreu um erro.|");
                        Console.WriteLine(new string('-', 17));
                        Console.WriteLine("");
                    }
                }
                Console.WriteLine($"Tabela de despesas dos funcionários:\n");
                for (int i2 = 0; i2 < funcionarios.Length; i2++)
                {
                    Console.WriteLine(new string('-', 50));
                    Console.WriteLine($"Nome - {funcionarios[i2].Nome};\nDespesa - {funcionarios[i2].Despesa}.");
                }
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("\nObrigado por utilizar nosso serviço de funcionários!\n");
                Console.WriteLine("Pressione qualquer tecla para sair...");
                Console.ReadKey();
                Console.Clear();
                controle = false;
            }
        }
    }
}
