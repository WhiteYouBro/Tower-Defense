using UnityEngine;

//clear C# class
[System.Serializable]
public class node
{
    public Vector2Int cooridnates;
    public bool @iswalkable;
    public bool @isexplored;
    public bool @ispath;

    public node connectedTo; // может быть пустой

    public node(Vector2Int coordiantes, bool iswalkable) //constructor
    {
        this.cooridnates = coordiantes;
        this.iswalkable = iswalkable;
    }
}
