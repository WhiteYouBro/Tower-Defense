using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class waypoint : MonoBehaviour
{
    [SerializeField] private bool isnotplaycable;
    [SerializeField] private tower _tower;  

    public bool IsPlaycable
    {
        get { return !isnotplaycable; }
    }
    //[SerializeField] private enemymover enemy;
    private void OnMouseDown()
    {
        if (isnotplaycable)
        {   
            return;
        }
        bool isplaced = _tower.spawntower(_tower, transform.position);
        isnotplaycable = isplaced;
        
    }
   
}
