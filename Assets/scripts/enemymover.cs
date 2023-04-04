using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(enemy))]
public class enemymover : MonoBehaviour
{
    [SerializeField] private List<waypoint> waypoints = new List<waypoint>();
    [SerializeField] private float speed = 1f;
    [SerializeField] private int waitime;

    private WaitForEndOfFrame pathwaittime;
    private enemy _enemy;
    //[SerializeField][Range(0f, 1f)] private float travelpoint = 0f;
    private void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(move());
    }
    private void Start()
    {
        _enemy = GetComponent<enemy>();
        pathwaittime = new WaitForEndOfFrame(); 
    }
    void ReturnToStart()
    {
        transform.position = waypoints[0].transform.position;
    }
     IEnumerator move()
    {
        foreach (var waypoint in waypoints)
        {
            Vector3 startpos = transform.position;
            Vector3 finalpos = waypoint.transform.position;
            float travelpercent = 0f;
            while(travelpercent < 1)
            {
                transform.LookAt(finalpos);
                travelpercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startpos, finalpos, travelpercent);
                yield return pathwaittime;
            }
            
        }
        FinishPath();
        
    }
    void FindPath()
    {
        waypoints.Clear();
        var parent = GameObject.FindGameObjectWithTag("path");
        foreach (Transform child in parent.transform)
        {
            var waypoint = child.GetComponent<waypoint>();
            if (waypoint != null)
                waypoints.Add(waypoint);
        }
        
    }

    private void FinishPath()
    {
        _enemy.damagecastle();
        gameObject.SetActive(false);
    }
    

}