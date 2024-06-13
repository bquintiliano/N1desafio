using System.Text.RegularExpressions;

namespace HelloWorld;

class Program
{
    static void Main()
    {
        bool finishOperation = false;
        
        while(!finishOperation)
        {
            Console.WriteLine("\nDigite o desafio:\n");
            Console.WriteLine("1 - Desafio 1\n2 - Desafio 2\n3 - Desafio 3\n4 - Desafio 4\n5 - Desafio 5\n6 - Desafio 6\n7 - Sair\n");
            var option = verifyIsNumber();

            if (option == 1)
                Desafio1();

            if (option == 2)
                Desafio2();

            if (option == 3)
                Desafio3();

            if (option == 4)
                Desafio4();

            if (option == 5)
                Desafio5();

            if (option == 6)
                Desafio6();

            if (option == 7)
                finishOperation = true;

            if(option < 1 || option > 7)
                Console.WriteLine("Valor digitado não permitido.\n");
        }
    }

    static void Desafio1()
    {
        Console.WriteLine("Digite seu nome abaixo:\n");

        var inputName = Console.ReadLine();

        Console.WriteLine($"\nOlá, {inputName}! Seja muito bem-vindo!");
    }

    static void Desafio2()
    {
        Console.WriteLine("Digite seu nome abaixo:\n");

        var inputName = Console.ReadLine();

        Console.WriteLine("\nDigite seu sobrenome abaixo:\n");

        var inputSurname = Console.ReadLine();

        Console.WriteLine($"\n{inputName} {inputSurname}");
    }

    static void Desafio3()
    {
        bool finishOperation = false;

        while (!finishOperation)
        {
            Console.WriteLine("Digite o número correspondente a operação:\n");
            Console.WriteLine("1 - Soma\n2 - Subtração\n3 - Multiplicação\n4 - Divisão\n5 - Média\n");
            
            var numberOption = verifyIsNumber();

            if (numberOption > 0 && numberOption < 6)
            {
                Console.WriteLine("\nDigite o primeiro número para a operação:\n");

                var firstNumber = verifyIsNumber();

                Console.WriteLine("\nDigite o segundo número para a operação:\n");

                var secondNumber = verifyIsNumber();
                    
                calc(firstNumber, secondNumber, numberOption);

                Console.WriteLine("\nDeseja fazer outra operação?\n");
                Console.WriteLine("1 - Sim\n2 - Não\n");

                var numberFinishOperation = verifyIsNumber();

                if (numberFinishOperation == 2)
                    finishOperation = true;

                if(numberFinishOperation < 1 || numberFinishOperation > 2)
                    Console.WriteLine("Valor digitado não permitido");
            }
            else
            {
                Console.WriteLine("Valor digitado não permitido");
            }
        }
    }

    private static void calc(int firstNumber, int secondNumber, int operation)
    {
        if (operation == 1)
            Console.WriteLine($"O resultado é {firstNumber + secondNumber}");

        if (operation == 2)
            Console.WriteLine($"O resultado é {firstNumber - secondNumber}");

        if (operation == 3)
            Console.WriteLine($"O resultado é {firstNumber * secondNumber}");

        if (operation == 4)
            Console.WriteLine($"O resultado é {firstNumber / secondNumber}");

        if (operation == 5)
            Console.WriteLine($"O resultado é {firstNumber % secondNumber}");
    }

    static void Desafio4()
    {
        Console.WriteLine("Digite uma frase para contabilizar quantidade de caracteres");
        var inputText = Console.ReadLine();

        Console.WriteLine($"\nO texto digitado contém {inputText.Length} caracteres");
    }

    static void Desafio5()
    {
        Console.WriteLine("Digite a placa do veículo");
        string inputText = Console.ReadLine();

        if(inputText.Length != 7)
        {
            Console.WriteLine("A placa digitada não é uma placa válida");
            return;
        }

        var firstSequence = inputText.Substring(0, 3);
        var secondSequence = inputText.Substring(3);
        
        var regexOnlyLetters = @"^[a-zA-Z]+$";
        var regexOnlyNumbers = @"^[0-9]+$";

           
        if(!Regex.IsMatch(firstSequence, regexOnlyLetters))
        {
            Console.WriteLine("A placa digitada não é uma placa válida");
            return;
        }

        if (!Regex.IsMatch(secondSequence, regexOnlyNumbers))
        {
            Console.WriteLine("A placa digitada não é uma placa válida");
            return;
        }

        Console.WriteLine("A placa digitada é uma placa válida");
    }

    static void Desafio6()
    {
        Console.WriteLine("Digite o padrão desejado de hora e data:\n");
        Console.WriteLine("1 - (dia da semana, dia do mês, mês, ano, hora, minutos, segundos)\n" +
            "2 - '01/03/2024'\n"  +
            "3 - formato de 24 horas\n" +
            "4 - A data com o mês por extenso\n");

        var option = verifyIsNumber();

        if(option > 0 && option < 5)
        {
            if (option == 1)
                Console.WriteLine(DateTime.UtcNow.ToString("F"));

            if (option == 2)
                Console.WriteLine(DateTime.UtcNow.ToString("dd/MM/yyyy"));

            if (option == 3)
                Console.WriteLine(DateTime.UtcNow.ToString("HH"));

            if (option == 4)
                Console.WriteLine(DateTime.UtcNow.ToString("dd MMMM yyyy"));
        }
        else
        {
            Console.WriteLine("Valor digitado não permitido.\n");
        }
    }

    private static int verifyIsNumber()
    {
        bool isNumber = false;
        int number = 0;
        while (!isNumber)
        {
            var option = Console.ReadLine();
            if (Int32.TryParse(option, out int result))
            {
                number = Int32.Parse(option);
                break;
            }
            Console.WriteLine("Valor digitado não permitido, digite novamente\n");
        }
        return number;
    }

}