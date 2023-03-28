using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    [SerializeField] private bool isnotplaycable;
    [SerializeField] private GameObject tower;
    [SerializeField] private coins coems;
    //[SerializeField] private enemymover enemy;
    private void OnMouseDown()
    {
        if (isnotplaycable)
            return;
        coems.curcoins -= 15;
        Instantiate(tower, transform.position, Quaternion.identity);
        isnotplaycable = true;
    }
}
