using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
public float bulletSpeed;
TurretScript tScript;
public Transform FP;
Rigidbody2D rb2;

public Enemy enemyTarget;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        transform.position = Vector2.MoveTowards(transform.position,tScript.CurrentEnemyTarget.transform.position,bulletSpeed);
        Destroy(gameObject,3f);
    }

    void moveBullet(){
        //transform.position = Vector2.MoveTowards(transform.position,tScript.CurrentEnemyTarget.transform.position,bulletSpeed*Time.deltaTime);

    }
    // Update is called once per frame

   
    void Update()
    {
   
    }
    
}
