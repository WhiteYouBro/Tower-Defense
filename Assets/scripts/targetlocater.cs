using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetlocater : MonoBehaviour
{
    [SerializeField] private GameObject topmesh;
    private enemymover enemy;
    private void Start()
    {
        enemy = FindObjectOfType<enemymover>();
    }
    private void Update()
    {
        topmesh.transform.LookAt(enemy.transform.position);
    }
}
