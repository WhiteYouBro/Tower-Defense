using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class enemymover : MonoBehaviour
{
    [SerializeField] private List<waypoint> waypoints = new List<waypoint>();
    [SerializeField] private float speed = 1f;
    [SerializeField] private int waitime;
    private WaitForEndOfFrame pathwaittime;
    //[SerializeField][Range(0f, 1f)] private float travelpoint = 0f;
    private void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(move());
    }
    private void Start()
    {
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
        
        gameObject.SetActive(false);
        
    }
    void FindPath()
    {
        waypoints.Clear();
        var path = GameObject.FindGameObjectsWithTag("path");
        foreach (var waypoint in path)
        {
            waypoints.Add(waypoint.GetComponent<waypoint>());
        }
        
    }
    

}