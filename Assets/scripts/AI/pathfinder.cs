using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(gridmanager))]
public class pathfinder : MonoBehaviour
{
    [SerializeField] private Node currentsearchnode;

    [SerializeField] private Vector2Int startingcoord;

    [SerializeField] private Vector2Int endofcoord;

    private Dictionary<Vector2Int, Node> reached = new();
    private Node startingnode;
    private Node endnode;
    
    private Queue<Node> frontier = new Queue<Node>();

    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    private Vector2Int[] _directions = {Vector2Int.right, Vector2Int.up, Vector2Int.down, Vector2Int.left};
    
    private gridmanager _gridmanager;


    private void Awake()
    {
        _gridmanager = FindObjectOfType<gridmanager>();

        if (_gridmanager != null)
            grid = _gridmanager.Grid;
    }

    private void Start()
    {
        startingnode = grid[startingcoord];
        endnode = grid[endofcoord];
        BreadthFirstSearch();
        BuildPath();
    }

    public List<Node> GetNewPath()
    {
        _gridmanager.ResetNodes();
        BreadthFirstSearch();
        return BuildPath();
    }

    private void ExploreNeighbors()
    {
        
        List<Node> neighbors = new List<Node>();
        foreach(Vector2Int direct in _directions)
        {
            Vector2Int neighborscoord = currentsearchnode.cooridnates + direct;
            if (grid.ContainsKey(neighborscoord))
            {
                neighbors.Add(grid[neighborscoord]);


            }
                
        }
        foreach (var neighbor in neighbors)
        {
 //              пока не смотрели                               можно ли ходить
            if (!reached.ContainsKey(neighbor.cooridnates) && neighbor.iswalkable)
            {
                neighbor.connectedTo = currentsearchnode;
                reached.Add(neighbor.cooridnates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }
        
    }

    private void BreadthFirstSearch()
    {
        bool isrunning = true;
        frontier.Enqueue(startingnode);
        reached.Add(startingcoord, startingnode);

        while(frontier.Count > 0 && isrunning)
        {
            currentsearchnode = frontier.Dequeue();
            currentsearchnode.isexplored = true;
            ExploreNeighbors();
            if (currentsearchnode.cooridnates == endofcoord)
            {
                isrunning = false;
            }
        }
    }

    private List<Node> BuildPath()
    {
        //
        List<Node> path = new List<Node>();

        var curnode = endnode;
        path.Add(curnode);
        curnode.ispath = true;

        while(curnode.connectedTo != null)
        {
            curnode = curnode.connectedTo;
            curnode.ispath = true;
            path.Add(curnode);
        }


        //
        path.Reverse();
        return path;
    }
}
