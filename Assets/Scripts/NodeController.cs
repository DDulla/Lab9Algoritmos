using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public Transform[] nodeTransforms;
    public List<Node> nodes = new List<Node>();

    void Start()
    {
        nodes.Clear();
        for (int i = 0; i < nodeTransforms.Length; i++)
        {
            Transform nodeTransform = nodeTransforms[i];
            Node node = nodeTransform.GetComponent<Node>();
            if (node != null)
            {
                AddNode(node);
            }
        }
    }

    public void AddNode(Node node)
    {
        nodes.Add(node);
    }

    public Node GetRandomNode()
    {
        return nodes[Random.Range(0, nodes.Count)];
    }
}