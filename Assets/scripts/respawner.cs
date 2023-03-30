using System;
using System.Collections;
using UnityEngine;

public class respawner : MonoBehaviour
{
    [SerializeField] private int respawnseconds;
    [SerializeField] private GameObject enemy;
    [SerializeField] private int poolsize = 5;

    private WaitForSecondsRealtime waittime;
    private GameObject[] pool;
    private void Awake()
    {
        Populatepool();
    }

    private void Populatepool()
    {
        pool = new GameObject[poolsize];
        for (int i = 0; i < poolsize; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);

        }
    }

    private void Start()
    {
        waittime = new WaitForSecondsRealtime(respawnseconds);
        StartCoroutine(respawn());
    }
    
    private IEnumerator respawn()
    {
        while (true)
        {
            Enableonjectinpool();
            yield return waittime;
        }
    }

    private void Enableonjectinpool()
    {
        foreach(var objectenemy in pool)
        {
            if (objectenemy.activeInHierarchy)
                continue;
            objectenemy.SetActive(true);
            return;
        }
    }
}
