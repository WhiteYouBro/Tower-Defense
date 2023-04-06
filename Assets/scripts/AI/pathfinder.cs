using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(gridmanager))]
public class pathfinder : MonoBehaviour
{
    [SerializeField] private node currentnode;
    
    Dictionary<Vector2Int, node> grid = new Dictionary<Vector2Int, node>();

    private Vector2Int[] _directions = {Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left};

    private gridmanager _gridmanager;


    private void Awake()
    {
        _gridmanager = FindObjectOfType<gridmanager>();

        if (_gridmanager != null)
            grid = _gridmanager.Grid;
    }

    private void Start()
    {
        ExploreNeighbors();
    }

    private void ExploreNeighbors()
    {
        if (grid.ContainsKey(currentnode.cooridnates))
            grid[currentnode.cooridnates].ispath = true;
        List<node> neighbors = new List<node>();
        foreach(Vector2Int direct in _directions)
        {
            Vector2Int neighborscoord = currentnode.cooridnates + direct;
            if (grid.ContainsKey(neighborscoord))
            {
                neighbors.Add(grid[neighborscoord]);

                //delete after debug
                grid[neighborscoord].isexplored = true;
                grid[currentnode.cooridnates].ispath = true;
            }
                
        }
        // лист соседей (готово)
        // проходим по всем направленим с помощью массива (наврено готово)
        // проверить в направлении соседние ноды
        // если существуют то добавить в лист соседей + метка Explored (готово)
    }
}
