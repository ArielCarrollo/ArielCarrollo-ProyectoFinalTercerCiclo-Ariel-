using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaInventadaPropia<T>
{
    public class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node(T value)
        {
            this.Value = value;
            Next = null;
        }
    }

    private Node Head;
    public int Length { get; private set; } = 0;

    public ListaInventadaPropia()
    {
        Head = null;
        Length = 0;
    }

    public void InsertNodeAtStart(T value)
    {
        Node newNode = new Node(value);
        newNode.Next = Head;
        Head = newNode;
        Length++;
    }

    public void InsertNodeAtEnd(T value)
    {
        if (Head == null)
        {
            InsertNodeAtStart(value);
        }
        else
        {
            Node last = Head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            last.Next = new Node(value);
            Length++;
        }
    }

    public void InsertNodeAtPosition(T value, int position)
    {
        if (position == 0)
        {
            InsertNodeAtStart(value);
        }
        else if (position == Length)
        {
            InsertNodeAtEnd(value);
        }
        else if (position > Length)
        {
            Debug.Log("No existe esa posición.");
        }
        else
        {
            Node previous = Head;
            for (int i = 0; i < position - 1; i++)
            {
                previous = previous.Next;
            }
            Node newNode = new Node(value);
            newNode.Next = previous.Next;
            previous.Next = newNode;
            Length++;
        }
    }

    public void ModifyAtStart(T value)
    {
        if (Head == null)
        {
            Debug.Log("No se puede modificar el inicio, la lista está vacía.");
        }
        else
        {
            Head.Value = value;
        }
    }

    public void ModifyAtEnd(T value)
    {
        if (Head == null)
        {
            ModifyAtStart(value);
        }
        else
        {
            Node last = Head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            last.Value = value;
        }
    }

    public void ModifyAtPosition(T value, int position)
    {
        if (position == 0)
        {
            ModifyAtStart(value);
        }
        else if (position == Length)
        {
            ModifyAtEnd(value);
        }
        else if (position >= Length)
        {
            Debug.Log("No existe esa posición.");
        }
        else
        {
            Node nodePosition = Head;
            for (int i = 0; i < position; i++)
            {
                nodePosition = nodePosition.Next;
            }
            nodePosition.Value = value;
        }
    }

    public T ObtainNodeAtStart()
    {
        if (Head == null)
        {
            throw new Exception("La lista está vacía.");
        }
        else
        {
            return Head.Value;
        }
    }

    public T ObtainNodeAtEnd()
    {
        if (Head == null)
        {
            return ObtainNodeAtStart();
        }
        else
        {
            Node last = Head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            return last.Value;
        }
    }

    public T ObtainNodeAtPosition(int position)
    {
        if (position == 0)
        {
            return ObtainNodeAtStart();
        }
        else if (position == Length - 1)
        {
            return ObtainNodeAtEnd();
        }
        else if (position >= Length)
        {
            throw new Exception("No existe ese nodo en la lista.");
        }
        else
        {
            Node nodePosition = Head;
            for (int i = 0; i < position; i++)
            {
                nodePosition = nodePosition.Next;
            }
            return nodePosition.Value;
        }
    }

    public void DeleteAtStart()
    {
        if (Head == null)
        {
            throw new Exception("La lista está vacía.");
        }
        else
        {
            Head = Head.Next;
            Length--;
        }
    }

    public void DeleteAtEnd()
    {
        if (Head == null)
        {
            DeleteAtStart();
        }
        else if (Head.Next == null)
        {
            Head = null;
            Length--;
        }
        else
        {
            Node previousLastNode = Head;
            while (previousLastNode.Next.Next != null)
            {
                previousLastNode = previousLastNode.Next;
            }
            previousLastNode.Next = null;
            Length--;
        }
    }

    public void DeleteNodeAtPosition(int position)
    {
        if (position == 0)
        {
            DeleteAtStart();
        }
        else if (position == Length - 1)
        {
            DeleteAtEnd();
        }
        else if (position >= Length)
        {
            Debug.Log("No existe ese nodo en la lista.");
        }
        else
        {
            Node previous = Head;
            for (int i = 0; i < position - 1; i++)
            {
                previous = previous.Next;
            }
            previous.Next = previous.Next.Next;
            Length--;
        }
    }
    public void Clear()
    {
        Head = null;
        Length = 0;
    }
    public void PrintAllNodes()
    {
        Node tmp = Head;
        while (tmp != null)
        {
            Debug.Log(tmp.Value + ", ");
            tmp = tmp.Next;
        }
        Debug.Log("");
    }
}
