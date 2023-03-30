using System;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    [SerializeField] private int maxhitpoints = 5;

    private int currenthealth;
    private void OnEnable()
    {
        currenthealth = maxhitpoints;
    }
    private void OnParticleCollision(GameObject other)
    {
        takedamage();
    }
    void takedamage()
    {
        currenthealth--;
        if (currenthealth <= 0)
            gameObject.SetActive(false);
    }
}
