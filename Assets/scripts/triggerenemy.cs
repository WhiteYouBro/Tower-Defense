using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerenemy : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private healthofcastle health;
    private void OnTriggerEnter(Collider other)
    {
        health.health -= damage;
    }
}
