using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(enemy))]
public class enemymover : MonoBehaviour
{
    [SerializeField] private List<Node> path = new List<Node>();
    [SerializeField] private float speed = 1f;
    [SerializeField] private int waitime;

    private gridmanager gridmanager;
    private pathfinder pathfinder;

    private WaitForEndOfFrame pathwaittime;
    private enemy _enemy;
    //[SerializeField][Range(0f, 1f)] private float travelpoint = 0f;
    private void Awake()
    {
        pathfinder = FindObjectOfType<pathfinder>();
        gridmanager = FindObjectOfType<gridmanager>();
        _enemy = GetComponent<enemy>();
        pathwaittime = new WaitForEndOfFrame(); 
    }
    private void OnEnable()
    {
        
        ReFindPath();
        ReturnToStart();
        StartCoroutine(move());
    }

    void ReturnToStart()
    {
        transform.position = gridmanager.GetPositionFromCoordinatate(pathfinder.Startingcoord);
    }
     IEnumerator move()
    {
        for (int i = 1; i < path.Count; i++)
        {
            var waypoint = path[i];
            Vector3 startpos = transform.position;
            Vector3 finalpos = gridmanager.GetPositionFromCoordinatate(waypoint.cooridnates);
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
    void ReFindPath()
    {
        path.Clear();
        path = pathfinder.GetNewPath();
    }

    private void FinishPath()
    {
        _enemy.damagecastle();
        gameObject.SetActive(false);
    }
    

}