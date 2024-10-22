using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public float weight;
    public List<Node> neighbors = new List<Node>();

    public void AddNeighbor(Node neighbor)
    {
        neighbors.Add(neighbor);
    }

    public Node GetRandomNeighbor(Node previousNode)
    {
        List<Node> validNeighbors = new List<Node>();

        for (int i = 0; i < neighbors.Count; i++)
        {
            Node neighbor = neighbors[i];
            if (neighbor != previousNode || (previousNode != null && previousNode.neighbors.Contains(this)))
            {
                validNeighbors.Add(neighbor);
            }
        }

        if (validNeighbors.Count == 0) return null;

        return validNeighbors[Random.Range(0, validNeighbors.Count)];
    }
}