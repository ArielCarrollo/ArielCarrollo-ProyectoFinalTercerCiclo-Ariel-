using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MiCola<T>
{
    public class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public Node(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
    public Node Head { get; set; }
    public Node Tail { get; set; }
    public int length = 0;

    public void Enqueue(T value)
    {
        if (Head == null)
        {
            Node newNode = new Node(value);
            Head = newNode;
            Tail = newNode;
            Head.Next = newNode;
            length = length + 1;
        }
        else
        {
            Node newNode = new Node(value);
            newNode.Previous = Tail;
            Tail.Next = newNode;
            Tail = newNode;
            length = length + 1;
        }
    }

    public void Dequeue()
    {
        if (Head == null)
        {
            throw new ("Esta vacio chico");
        }
        else
        {
            Node oldHead = Head;
            Node newHead = Head.Next;
            Head.Next = null;
            newHead.Previous = null;
            Head = newHead;
            oldHead = null;
            length = length - 1;
        }
    }
    public void PrintAllNodes()
    {
        Node tmp = Head;
        while (tmp != null)
        {
            Debug.Log(tmp.Value + " ");
            tmp = tmp.Next;
        }
        Debug.Log("");
    }
}

