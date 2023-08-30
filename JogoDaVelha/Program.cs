namespace JogoDaVelha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] grade = new string[3, 3];
            preencherMatriz(grade);
            listarMatriz(grade);

            //Jogar
            bool temVencedor = false;
            int jogador = 1;
            string vencedor = " ";
            while (!temVencedor)
            {
                if (jogador % 2 != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Jogador 'X' informe linha: ");
                    int linha = int.Parse(Console.ReadLine());
                    Console.WriteLine("Jogador 'X' informe coluna: ");
                    int coluna = int.Parse(Console.ReadLine());
                    //Testa se a posição escolhida já está marcada
                    if (grade[linha, coluna] == " ")
                    {
                        grade[linha, coluna] = "X";
                        vencedor = grade[linha, coluna];
                    }
                    else
                    {
                        while (grade[linha, coluna] != " ")
                        {
                            Console.Clear();
                            listarMatriz(grade);
                            Console.WriteLine();
                            Console.WriteLine("Já tem uma jogada nessa posição!");
                            Console.WriteLine("Jogador 'X' informe linha: ");
                            linha = int.Parse(Console.ReadLine());
                            Console.WriteLine("Jogador 'X' informe coluna: ");
                            coluna = int.Parse(Console.ReadLine());
                        }
                        grade[linha, coluna] = "X";
                        vencedor = grade[linha, coluna];
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Jogador 'O' informe linha: ");
                    int linha = int.Parse(Console.ReadLine());
                    Console.WriteLine("Jogador 'O' informe coluna: ");
                    int coluna = int.Parse(Console.ReadLine());
                    //Testa se a posição escolhida já está marcada
                    if (grade[linha, coluna] == " ")
                    {
                        grade[linha, coluna] = "O";
                        vencedor = grade[linha, coluna];
                    }
                    else
                    {
                        while (grade[linha, coluna] != " ")
                        {
                            Console.Clear();
                            listarMatriz(grade);
                            Console.WriteLine();
                            Console.WriteLine("Já tem uma jogada nessa posição!");
                            Console.WriteLine("Jogador 'O' informe linha: ");
                            linha = int.Parse(Console.ReadLine());
                            Console.WriteLine("Jogador 'O' informe coluna: ");
                            coluna = int.Parse(Console.ReadLine());
                        }
                        grade[linha, coluna] = "O";
                        vencedor = grade[linha, coluna];
                    }
                }
                jogador++;

                Console.Clear();
                listarMatriz(grade);
                temVencedor = verificaVencedor(grade);
            }
            Console.WriteLine();
            Console.WriteLine($"O jogador '{vencedor}' é o vencedor!");
            Console.ReadKey();
        }
        //Testa se há vencedor
        static bool verificaVencedor(string[,] matriz)
        {
            //Testa na horizontal            
            for (int linha = 0; linha < matriz.GetLength(0); linha++)
            {
                string a = " ";
                string b = " ";
                string c = " ";
                int cont = 1;
                for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                {
                    if (cont == 1)
                        a = matriz[linha, coluna];
                    else if (cont == 2)
                        b = matriz[linha, coluna];
                    else
                        c = matriz[linha, coluna];

                    cont++;
                }
                if ((a == b) && (b == c) && (a != " "))
                {
                    return true;
                }
            }

            //Testa as duas diagonais
            if ((matriz[0, 0] == matriz[1, 1]) && (matriz[1, 1] == matriz[2, 2]) && (matriz[0, 0] != " "))
            {
                return true;
            }
            else if ((matriz[2, 0] == matriz[1, 1]) && (matriz[1, 1] == matriz[0, 2]) && (matriz[2, 0] != " "))
            {
                return true;
            }

            //Testa na vertical
            if ((matriz[0, 0] == matriz[1, 0]) && (matriz[1, 0] == matriz[2, 0]) && (matriz[0, 0] != " "))
            {
                return true;
            }
            else if ((matriz[0, 1] == matriz[1, 1]) && (matriz[1, 1] == matriz[2, 1]) && (matriz[0, 1] != " "))
            {
                return true;
            }
            else if ((matriz[0, 2] == matriz[1, 2]) && (matriz[1, 2] == matriz[2, 2]) && (matriz[0, 2] != " "))
            {
                return true;
            }

            return false;
        }
        //Método para preencher a matriz
        static void preencherMatriz(string[,] matriz)
        {
            for (int linha = 0; linha < matriz.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                {
                    matriz[linha, coluna] = " ";
                }
            }
        }
        //Método para listar a matriz
        static void listarMatriz(string[,] matriz)
        {
            for (int linha = 0; linha < matriz.GetLength(0); linha++)
            {
                if ((linha == 1) || (linha == 2))
                {
                    Console.WriteLine("==========");
                }
                for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                {
                    if (coluna < 2)
                        Console.Write(matriz[linha, coluna] + " ||");
                    else
                        Console.Write(matriz[linha, coluna]);
                }
                Console.WriteLine();
            }
        }
    }
}