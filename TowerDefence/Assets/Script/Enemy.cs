using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int Health = 100;
    public int CurrHealth;
    private Waypoints Points;
    [SerializeField] private int PointIndex;
    // Start is called before the first frame update
    void Start()
    {
        Points = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        CurrHealth = Health;
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

    public void Damaged(int damage){

        CurrHealth = CurrHealth - damage;
        if(CurrHealth <= 0){
            CurrHealth = 0;
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Bullet"){
            
        }
    }

    public void Die(){
        Destroy(gameObject);
    }
}
