using System.Collections;
using UnityEngine;

public class respawner : MonoBehaviour
{
    [Range(1f,30f)][SerializeField] private int respawnseconds;
    [Range(1, 30f)][SerializeField] private int poolsize = 5;
    [SerializeField] private GameObject enemy;

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
            Enableobjectinpool();
            yield return waittime;
        }
    }

    private void Enableobjectinpool()
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
