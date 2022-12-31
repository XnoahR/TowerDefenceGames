using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
public float bulletSpeed;
TurretScript tScript;
public Transform FP;
Rigidbody2D rb2;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tScript.CurrentEnemyTarget != null){
       transform.position = Vector2.MoveTowards(transform.position,tScript.enemylist[0].transform.position,150*Time.deltaTime);
        }
        else
        return;
    }
}
