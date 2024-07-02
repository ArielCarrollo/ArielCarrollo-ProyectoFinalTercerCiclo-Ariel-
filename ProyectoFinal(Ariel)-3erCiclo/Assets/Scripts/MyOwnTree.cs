using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOwnTree<T> 
{
    public class Node
    {
        public T Value { get; set; }
        public ListaInventadaPropia<Node> listChilds;

        public Node(T value)
        {
            Value = value;
            listChilds = new ListaInventadaPropia<Node>();
        }

        public void AddChild(Node node)
        {
            listChilds.InsertNodeAtEnd(node);
        }
    }

    private Node root;
    private ListaInventadaPropia<Node> listAllNodes = new ListaInventadaPropia<Node>();

    public void AddNode(T value, T fatherValue)
    {
        if (root == null)
        {
            Node newNode = new Node(value);
            root = newNode;
            listAllNodes.InsertNodeAtEnd(newNode);
        }
        else
        {
            Node newNode = new Node(value);
            Node father = GetFather(fatherValue);
            father.AddChild(newNode);
            listAllNodes.InsertNodeAtEnd(newNode);
        }
    }

    private Node GetFather(T value)
    {
        dynamic fatherValue = value;
        Node father = null;
        for (int i = 0; i < listAllNodes.Length; ++i)
        {
            if (listAllNodes.ObtainNodeAtPosition(i).Value == fatherValue)
            {
                father = listAllNodes.ObtainNodeAtPosition(i);
                break;
            }
        }
        return father;
    }
    public Node FindNode(T value)
    {
        dynamic NodeToFind = value;
        for (int i = 0; i < listAllNodes.Length; ++i)
        {
            if (listAllNodes.ObtainNodeAtPosition(i).Value == NodeToFind)
            {
                return listAllNodes.ObtainNodeAtPosition(i);
            }
        }
        return null;
    }
    public void PreOrden()
    {
        PreOrdenRecursive(root);
        Debug.Log("\n");
    }

    private void PreOrdenRecursive(Node node)
    {
        if (node != null)
        {
            Debug.Log(node.Value + " ");
            Node currentNode = node.listChilds.ObtainNodeAtStart();
            while (currentNode != null)
            {
                PreOrdenRecursive(currentNode);
                currentNode = node.listChilds.ObtainNodeAtEnd();
            }
        }
    }

    public void PostOrden()
    {
        PostOrdenRecursive(root);
        Debug.Log("\n");
    }

    private void PostOrdenRecursive(Node node)
    {
        if (node != null)
        {
            Node currentNode = node.listChilds.ObtainNodeAtStart();
            while (currentNode != null)
            {
                PostOrdenRecursive(currentNode);
                currentNode = node.listChilds.ObtainNodeAtEnd();
            }
            Debug.Log(node.Value + " ");
        }
    }

    public void InOrden()
    {
        InOrdenRecursive(root);
        Debug.Log("\n");
    }

    private void InOrdenRecursive(Node node)
    {
        if (node != null)
        {
            if (node.listChilds.Length > 0)
            {
                InOrdenRecursive(node.listChilds.ObtainNodeAtStart());
            }
            Debug.Log(node.Value + " ");
            Node currentNode = node.listChilds.ObtainNodeAtEnd();
            while (currentNode != null)
            {
                InOrdenRecursive(currentNode);
                currentNode = node.listChilds.ObtainNodeAtEnd();
            }
        }
    }
}

