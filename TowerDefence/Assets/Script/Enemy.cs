using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Waypoints Points;
    private int PointIndex;
    // Start is called before the first frame update
    void Start()
    {
        Points = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,Points.waypoints[PointIndex].position,speed * Time.deltaTime);
        if(Vector2.Distance(transform.position,Points.waypoints[PointIndex].position) < 0.1f){
            if(PointIndex < Points.waypoints.Length - 1){
            PointIndex++;   
            }
            else{
                Destroy(gameObject);
            }
        }

    }
}
