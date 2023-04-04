using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetlocater : MonoBehaviour
{
    [SerializeField] private Transform topmesh;
    [SerializeField] private float radius = 15f;
    [SerializeField] private ParticleSystem projecttileparticle;

    private bool isreadyshoot;
    private Transform target;

    private void Update()
    {
        Findclosesttarger();
        AimWeapon();
    }

    private void Findclosesttarger()
    {
        enemy[] enemies = FindObjectsOfType<enemy>();
        Transform closesttarget = null;
        float maxdistance = Mathf.Infinity;
        foreach(enemy enemy in enemies)
        {
            var targetdistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetdistance >= maxdistance)
                continue;
            closesttarget = enemy.transform;
            maxdistance = targetdistance;
        }
        target = closesttarget;
    }

    private void AimWeapon()
    {
        var targetdistance = Vector3.Distance(target.position, transform.position);
        Attack(targetdistance < radius);
        topmesh.LookAt(target);
    }

    private void Attack(bool isshoot)
    {
        var emmision = projecttileparticle.emission;
        emmision.enabled = isshoot;
    }
}
