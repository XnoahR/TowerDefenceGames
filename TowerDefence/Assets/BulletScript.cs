using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
public float bulletSpeed;
TurretScript tScript;

public EnemyHealth enemyHP;
Enemy enemy;
public Transform FP;
Rigidbody2D rb2;

public Transform enemyTarget;

public void seek(Transform _enemyTarget){
    enemyTarget = _enemyTarget;
}
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        tScript = GetComponent<TurretScript>();
     //   transform.position = Vector2.MoveTowards(transform.position,tScript.CurrentEnemyTarget.transform.position,bulletSpeed);
        Destroy(gameObject,10f);
    }

    void moveBullet(){
        //transform.position = Vector2.MoveTowards(transform.position,tScript.CurrentEnemyTarget.transform.position,bulletSpeed*Time.deltaTime);

    }
    // Update is called once per frame

   
    void Update()
    {
        if(enemyTarget ==  null){
            Debug.Log("Destroyed");
            Destroy(gameObject);
            return;
        }

        Vector2 direction = enemyTarget.position - transform.position;
        float distanceFrame = bulletSpeed*Time.deltaTime;
        //Debug.Log(direction.magnitude);
        //Debug.Log("Bullet speed : " + bulletSpeed*Time.deltaTime);

        if(direction.magnitude <= distanceFrame){
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized*distanceFrame,Space.World);
    }
    public void CheckTarget(Enemy Target){
        enemy = Target;
    }
    void HitTarget(){
       // Debug.Log("Hit!");
      //  enemy.Damaged(10);
      if(enemy != null){
        enemy.Damaged(15);
              Destroy(gameObject);
      }
      else
      return;
      //  Destroy(enemyTarget.gameObject);
    }

    

}
