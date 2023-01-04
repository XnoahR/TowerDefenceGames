using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public List<Enemy> enemylist = new List<Enemy>();
    public Enemy CurrentEnemyTarget;
    public GameObject bullet;
    public Transform bulletT;
    public Transform target;
    public Transform FP;
    public bool canShot = true;
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
     GetCurrentEnemyTarget();
     RotateToTarget();   
    }

    void GetCurrentEnemyTarget(){

        if(enemylist.Count <= 0){
            CurrentEnemyTarget = null;
            return;
        }
        CurrentEnemyTarget = enemylist[0];
        target = CurrentEnemyTarget.transform;
        
        if(canShot)
        StartCoroutine(BulletFire());
        
    }

    private void RotateToTarget(){
        if(CurrentEnemyTarget == null){
            return;
        }
        Vector3 targetPos = CurrentEnemyTarget.transform.position - transform.position;//Mendapatkan jarak dari turret ke target
        float angle = Vector3.SignedAngle(transform.up,targetPos,transform.forward);//Mendapatkan sudut dari turret ke target
        transform.Rotate(0,0,angle);//Melakukan rotasi Z sesuai variable angle 
     
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,3.5f);
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

    void BulletShot(){
    GameObject BulletObj = (GameObject)Instantiate(bullet,FP.position,FP.rotation);
    Debug.Log("SHOT!");
    BulletScript Bullet = BulletObj.GetComponent<BulletScript>();
    if(Bullet != null){
        Bullet.seek(target);
        Bullet.CheckTarget(CurrentEnemyTarget);
    }
    }
    IEnumerator BulletFire(){
        BulletShot();
        canShot = false;
        yield return new WaitForSeconds(0.75f);
        canShot = true;
    }
    
}