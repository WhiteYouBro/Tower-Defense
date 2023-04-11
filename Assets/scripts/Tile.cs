using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private bool isnotplaycable;
    [SerializeField] private tower _tower;  

    public bool IsPlaycable
    {
        get { return !isnotplaycable; }
    }

    private gridmanager _gridmanager;
    private pathfinder _pathfinder;
    private Vector2Int coordinates;
    //[SerializeField] private enemymover enemy;

    private void Awake()
    {
        _gridmanager = FindObjectOfType<gridmanager>();
        _pathfinder = FindObjectOfType<pathfinder>();
    }

    private void Start()
    {
        if (_gridmanager != null)
        {
            coordinates = _gridmanager.GetCoordFromPosition(transform.position);
            if (!IsPlaycable)
            {
                _gridmanager.BlockNode(coordinates);
            }
        }
    }
    private void OnMouseDown()
    {
        if (_gridmanager.GetNode(coordinates).iswalkable)
        {
            bool isplaced = _tower.spawntower(_tower, transform.position);
            isnotplaycable = isplaced;
            if (isplaced)
            {
                _gridmanager.BlockNode(coordinates);
                _pathfinder.GetNewPath();
            }

        }
        
    }
   
}
