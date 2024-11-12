using System;
using System.Collections.Generic;

public class Node
{
    public int Data;
    public Node? Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList
{
    public Node Head;

    public LinkedList()
    {
        Head = null;
    }

    // Добавление элемента в конец списка
    public void Append(int data)
    {
        var newNode = new Node(data);
        if (Head == null)
        {
            Head = newNode;
            return;
        }

        var lastNode = Head;
        while (lastNode.Next != null)
        {
            lastNode = lastNode.Next;
        }
        lastNode.Next = newNode;
    }

    // Вывод списка
    public void PrintList()
    {
        var current = Head;
        while (current != null)
        {
            Console.Write(current.Data);
            if (current.Next != null)
            {
                Console.Write(" -> ");
            }
            current = current.Next;
        }
        Console.WriteLine();
    }

    // Переворачивание списка
    public void ReverseList()
    {
        Node prev = null;
        Node current = Head;
        while (current != null)
        {
            Node next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }
        Head = prev;
    }

    // Перенос последнего элемента в начало
    public void MoveLastToFront()
    {
        if (Head == null || Head.Next == null)
            return;

        Node secondLast = Head;
        while (secondLast.Next != null && secondLast.Next.Next != null)
        {
            secondLast = secondLast.Next;
        }

        Node last = secondLast.Next;
        secondLast.Next = null;
        last.Next = Head;
        Head = last;
    }

    // Подсчет количества уникальных элементов
    public int CountUniqueElements()
    {
        var uniqueElements = new HashSet<int>();
        var current = Head;
        while (current != null)
        {
            uniqueElements.Add(current.Data);
            current = current.Next;
        }
        return uniqueElements.Count;
    }

    // Удаление неуникальных элементов
    public void RemoveNonUniqueElements()
    {
        var frequency = new Dictionary<int, int>();
        var current = Head;

        while (current != null)
        {
            if (frequency.ContainsKey(current.Data))
                frequency[current.Data]++;
            else
                frequency[current.Data] = 1;

            current = current.Next;
        }

        Node dummy = new Node(0) { Next = Head };
        Node prev = dummy;
        current = Head;

        while (current != null)
        {
            if (frequency[current.Data] > 1)
            {
                prev.Next = current.Next;
            }
            else
            {
                prev = current;
            }
            current = current.Next;
        }

        Head = dummy.Next;
    }

    // Вставка копии списка после первого вхождения числа x
    public void InsertSelfAfterX(int x)
    {
        Node current = Head;
        while (current != null)
        {
            if (current.Data == x)
            {
                LinkedList copy = new LinkedList();
                Node temp = Head;
                while (temp != null)
                {
                    copy.Append(temp.Data);
                    temp = temp.Next;
                }

                Node lastNodeOfCopy = copy.Head;
                while (lastNodeOfCopy.Next != null)
                {
                    lastNodeOfCopy = lastNodeOfCopy.Next;
                }
                lastNodeOfCopy.Next = current.Next;
                current.Next = copy.Head;
                return;
            }
            current = current.Next;
        }
    }

    // Вставка элемента в отсортированный список
    public void InsertInSortedOrder(int e)
    {
        Node newNode = new Node(e);

        if (Head == null || Head.Data >= e)
        {
            newNode.Next = Head;
            Head = newNode;
            return;
        }

        Node current = Head;
        while (current.Next != null && current.Next.Data < e)
        {
            current = current.Next;
        }
        newNode.Next = current.Next;
        current.Next = newNode;
    }

    // Удаление всех элементов E
    public void RemoveElement(int E)
    {
        while (Head != null && Head.Data == E)
        {
            Head = Head.Next;
        }

        Node current = Head;
        while (current != null && current.Next != null)
        {
            if (current.Next.Data == E)
            {
                current.Next = current.Next.Next;
            }
            else
            {
                current = current.Next;
            }
        }
    }

    // Дописывание списка E в конец списка L
    public void AppendList(LinkedList E)
    {
        if (Head == null)
        {
            Head = E.Head;
            return;
        }

        Node current = Head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = E.Head;
    }

    // Разбиение списка на два по первому вхождению числа
    public void SplitList(int x, out LinkedList first, out LinkedList second)
    {
        first = new LinkedList();
        second = new LinkedList();

        Node current = Head;
        bool found = false;

        while (current != null)
        {
            if (found)
            {
                second.Append(current.Data);
            }
            else
            {
                first.Append(current.Data);
                if (current.Data == x)
                {
                    found = true;
                }
            }
            current = current.Next;
        }
    }

    // Удвоение списка
    public void DoubleList()
    {
        if (Head == null) return;

        Node current = Head;
        LinkedList copy = new LinkedList();
        while (current != null)
        {
            copy.Append(current.Data);
            current = current.Next;
        }

        AppendList(copy);
    }

    // Замена местами двух элементов
    public void SwapNodes(int x, int y)
    {
        if (x == y) return;

        Node prevX = null, currX = Head;
        while (currX != null && currX.Data != x)
        {
            prevX = currX;
            currX = currX.Next;
        }

        Node prevY = null, currY = Head;
        while (currY != null && currY.Data != y)
        {
            prevY = currY;
            currY = currY.Next;
        }

        if (currX == null || currY == null) return;

        if (prevX != null) prevX.Next = currY;
        else Head = currY;

        if (prevY != null) prevY.Next = currX;
        else Head = currX;

        Node temp = currX.Next;
        currX.Next = currY.Next;
        currY.Next = temp;
    }
}
