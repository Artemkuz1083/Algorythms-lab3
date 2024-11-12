using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queue1;
using Rpn.Logic;

namespace AlgorythmsLab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Список заданий:\n" +
                "Stack-1\n" +
                "Queue-2\n" +
                "Lists-3\n");
            Console.Write("Выберите задание:");
            int input = Convert.ToInt32(Console.ReadLine());

            if (input == 1)
            {
                StackMenu();
            }
            else if (input == 2)
            {
                //Queue1.Run();
            }
            else if (input == 3)
            {
                LinkedList list = new LinkedList();
                list.Append(3);
                list.Append(7);
                list.Append(3);
                list.Append(9);
                list.Append(5);
                list.Append(7);

                Console.WriteLine("Исходный список:");
                list.PrintList();

                // 1. Переворачивание списка
                list.ReverseList();
                Console.WriteLine("Список после переворота:");
                list.PrintList();

                // 2. Перенос последнего элемента в начало
                list.MoveLastToFront();
                Console.WriteLine("Список после переноса последнего элемента в начало:");
                list.PrintList();

                // 3. Количество уникальных элементов
                Console.WriteLine("Количество уникальных элементов: " + list.CountUniqueElements());

                // 4. Удаление неуникальных элементов
                list.RemoveNonUniqueElements();
                Console.WriteLine("Список после удаления неуникальных элементов:");
                list.PrintList();

                // 5. Вставка списка после первого вхождения числа
                list.InsertSelfAfterX(3);
                Console.WriteLine("Список после вставки копии списка после первого вхождения 3:");
                list.PrintList();

                // 6. Вставка элемента в отсортированный список
                list.InsertInSortedOrder(6);
                Console.WriteLine("Список после вставки 6 в отсортированный список:");
                list.PrintList();

                // 7. Удаление всех элементов 3
                list.RemoveElement(3);
                Console.WriteLine("Список после удаления всех элементов 3:");
                list.PrintList();

                // 8. Дописывание списка
                LinkedList anotherList = new LinkedList();
                anotherList.Append(10);
                anotherList.Append(15);
                list.AppendList(anotherList);
                Console.WriteLine("Список после дописывания другого списка:");
                list.PrintList();

                // 9. Разбиение списка
                list.SplitList(9, out LinkedList firstList, out LinkedList secondList);
                Console.WriteLine("Первый список после разбиения:");
                firstList.PrintList();
                Console.WriteLine("Второй список после разбиения:");
                secondList.PrintList();

                // 10. Удвоение списка
                list.DoubleList();
                Console.WriteLine("Список после удвоения:");
                list.PrintList();

                // 11. Замена местами двух элементов
                list.SwapNodes(7, 10);
                Console.WriteLine("Список после замены местами элементов 7 и 10:");
                list.PrintList();
            }


        }

        public static void StackMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Работа со Стеком:\n");
                Console.WriteLine("1. Использовать самодельный стек.");
                Console.WriteLine("2. RPN.");
                Console.WriteLine("0. Выйти\n");
                Console.Write("Введите номер: ");

                if (!int.TryParse(Console.ReadLine(), out int stackChoice))
                {
                    Console.WriteLine("\nОшибка: введено некорректное значение. Пожалуйста, введите число.");
                    Console.WriteLine("Нажмите любую клавишу, чтобы попробовать снова...");
                    Console.ReadKey();
                    continue;
                }

                if (stackChoice == 1)
                {
                    string[] operations = File.ReadAllText("input.txt").Split(' ');
                    StackWork stack = new StackWork();
                    for (int i = 0; i < operations.Length; i++)
                    {
                        string command = operations[i];
                        switch (command[0])
                        {
                            case '1': // Push
                                if (command[1] == ',')
                                {
                                    int value = int.Parse(operations[i].Split(',')[1]); // Получаем значение после запятой
                                    stack.Push(value);
                                    Console.WriteLine($"Push: {value}");
                                }
                                else
                                {
                                    Console.WriteLine("Ошибка: отсутствует значение для Push.");
                                }
                                break;
                            case '2': // Pop
                                try
                                {
                                    int poppedValue = stack.Pop();
                                    Console.WriteLine($"Pop: {poppedValue}");
                                }
                                catch (InvalidOperationException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            case '3': // Top
                                try
                                {
                                    int topValue = stack.Top();
                                    Console.WriteLine($"Top: {topValue}");
                                }
                                catch (InvalidOperationException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            case '4': // isEmpty
                                Console.WriteLine($"IsEmpty: {stack.IsEmpty()}");
                                break;
                            case '5': // Print
                                Console.Write("Print: ");
                                stack.Print();
                                break;
                            default:
                                Console.WriteLine("Неизвестная команда: " + command);
                                break;
                        }
                    }
                    break;
                }
                else if (stackChoice == 2)
                {
                    string operations = File.ReadAllText("input.txt");
                    RpnCalculator rpnCalculator = new RpnCalculator(operations, 0);
                    Console.WriteLine(rpnCalculator.result);
                    break;
                }

            }
        }
    }
}
