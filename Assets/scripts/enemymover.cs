using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class enemymover : MonoBehaviour
{
    [SerializeField] private List<waypoint> waypoints = new List<waypoint>();
    [SerializeField] private float speed = 1f;
    private WaitForEndOfFrame pathwaittime;
    //[SerializeField][Range(0f, 1f)] private float travelpoint = 0f;
    private void Start()
    {
        pathwaittime = new WaitForEndOfFrame();
        StartCoroutine(move());
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
        
    }
    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }

}
