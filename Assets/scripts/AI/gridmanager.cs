using System;
using System.Collections.Generic;
using UnityEngine;

public class gridmanager : MonoBehaviour
{
    [SerializeField] private Vector2 GridSize;

    Dictionary<Vector2Int, node> grid = new Dictionary<Vector2Int, node>();
    public Dictionary<Vector2Int, node> Grid { get { return grid; } }
    //словарь -> dictionary

    void Awake()
    {
        CreateGrid();
    }
    
    public node GetNode(Vector2Int coordinates)
    {
        if (!grid.ContainsKey(coordinates))
            return null;
        return grid[coordinates];
    }
    
    private void CreateGrid()
    {
        for(int x = 0; x < GridSize.x; x++)
        {
            for(int y = 0; y < GridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new node(coordinates, true));
                print(grid[coordinates].cooridnates + " " + grid[coordinates].iswalkable);
            }
        }
    }
}
