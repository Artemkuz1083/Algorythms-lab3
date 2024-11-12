using NPOI.HPSF;
using System.Diagnostics;


namespace Queue1
    {
        public class QueueList<T>
        {
            private List<T> _queue;

            public QueueList()
            {
                _queue = new List<T>();
            }

            // Вставка элемента в очередь
            public void Insert(T element)
            {
                _queue.Add(element);
            }

            // Удаление первого элемента из очереди
            public void Delete()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Очередь пуста");
                }
                else
                {
                    _queue.RemoveAt(0);
                }
            }

            // Просмотр первого элемента очереди
            public T Peek()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Очередь пуста");
                    return default(T);
                }
                return _queue[0];
            }

            // Проверка на пустоту
            public bool IsEmpty()
            {
                return _queue.Count == 0;
            }

            // Печать всех элементов очереди
            public void PrintQueue()
            {
                Console.WriteLine("Очередь: " + string.Join(", ", _queue));
            }
        }

        public class QueueQueue<T>
        {
            private Queue<T> _queue;

            public QueueQueue()
            {
                _queue = new Queue<T>();
            }

            // Вставка элемента в очередь
            public void Insert(T element)
            {
                _queue.Enqueue(element);
            }

            // Удаление первого элемента из очереди
            public void Delete()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Очередь пуста");
                }
                else
                {
                    _queue.Dequeue();
                }
            }

            // Просмотр первого элемента очереди
            public T Peek()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Очередь пуста");
                    return default(T);
                }
                return _queue.Peek();
            }

            // Проверка на пустоту
            public bool IsEmpty()
            {
                return _queue.Count == 0;
            }

            // Печать всех элементов очереди
            public void PrintQueue()
            {
                Console.WriteLine("Очередь: " + string.Join(", ", _queue));
            }

            // Обработка команд
            public static void ExecuteOperations(dynamic queue, string inputFile)
            {

                var operations = File.ReadAllText(inputFile).Split(' ');

                foreach (var operation in operations)
                {
                    switch (operation[0])
                    {
                        case '1': // Вставка
                            queue.Insert(operation.Split(',')[1]);
                            break;
                        case '2': // Удаление
                            queue.Delete();
                            break;
                        case '3': // Просмотр первого элемента
                            Console.WriteLine(queue.Peek());
                            break;
                        case '4': // Проверка на пустоту
                            Console.WriteLine(queue.IsEmpty() ? "Пусто" : "Не пусто");
                            break;
                        case '5': // Печать очереди
                            queue.PrintQueue();
                            break;
                    }
                }
            }


            // Запуск теста и замер времени
            public static void RunTest(dynamic queue, string inputFile)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                ExecuteOperations(queue, inputFile);
                stopwatch.Stop();
                Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
            }

            // Основной метод для запуска теста
            public void Run()
            {
                string inputFile = "input.txt";

                // Тест с использованием списка
                Console.WriteLine("Тест с использованием списка:");
                var listQueue = new QueueList<string>();
                RunTest(listQueue, inputFile);

                Console.WriteLine("\nТест с использованием Queue:");
                var queueQueue = new QueueQueue<string>();
                RunTest(queueQueue, inputFile);
            }
        }
    }
