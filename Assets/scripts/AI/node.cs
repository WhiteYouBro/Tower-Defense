using UnityEngine;

//clear C# class
[System.Serializable]
public class Node
{
    public Vector2Int cooridnates;
    public bool @iswalkable;
    public bool @isexplored;
    public bool @ispath;

    public Node connectedTo; // может быть пустой

    public Node(Vector2Int coordiantes, bool iswalkable) //constructor
    {
        this.cooridnates = coordiantes;
        this.iswalkable = iswalkable;
    }
}
