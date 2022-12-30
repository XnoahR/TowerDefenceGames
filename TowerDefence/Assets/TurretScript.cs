using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public List<Enemy> enemylist = new List<Enemy>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,5);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy"){
            Debug.Log("On Area");
            Enemy newEnemy = other.GetComponent<Enemy>();
            enemylist.Add(newEnemy);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy"){
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemylist.Contains(enemy)){
                enemylist.Remove(enemy);
            }
        }
    }
}