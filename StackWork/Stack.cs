using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


public class StackWork
{

    private Node top;

    public StackWork()
    {
        top = null;
    }

    public bool IsEmpty()
    {
        return top == null;
    }

    public void Push(int elem)
    {
        Node newNode = new Node(elem);
        newNode.Next = top;
        top = newNode;
    }

    public int Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Pop from empty stack");
        }
        int poppedData = top.Data;
        top = top.Next;
        return poppedData;
    }

    public int Top()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Top from empty stack");
        }
        return top.Data;
    }

    public void Print()
    {
        Node current = top;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}

