using System.Collections.Generic;
using UnityEngine;

public class gridmanager : MonoBehaviour
{
    [SerializeField] private Vector2 GridSize;

    [Tooltip("Get it from unity snap settings")]
    [SerializeField] private int unityGridSize = 10;
    public int UnityGridSiza { get { return unityGridSize; } }

    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }
    //словарь -> dictionary

    void Awake()
    {
        CreateGrid();
    }
    
    public Node GetNode(Vector2Int coordinates)
    {
        if (!grid.ContainsKey(coordinates))
            return null;
        return grid[coordinates];
    }

    public Vector2Int GetCoordFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);


        return coordinates;

    }

    public Vector3 GetPositionFromCoordinatate(Vector2Int coordinates)
    {
        Vector3 coords = new Vector3();
        coords.x = coordinates.x * unityGridSize;
        coords.z = coordinates.y * unityGridSize;
        return coords;
    }

    public void BlockNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            grid[coordinates].iswalkable = false;
        }
    }

    public void ResetNodes()
    {
        foreach(KeyValuePair<Vector2Int, Node > entry in grid)
        {
            entry.Value.connectedTo = null;
            entry.Value.isexplored = false;
            entry.Value.ispath = false;
        }
    }
    private void CreateGrid()
    {
        for(int x = 0; x < GridSize.x; x++)
        {
            for(int y = 0; y < GridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new Node(coordinates, true));
                //print(grid[coordinates].cooridnates + " " + grid[coordinates].iswalkable);
            }
        }
    }
}