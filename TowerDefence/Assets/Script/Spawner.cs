using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    public bool delay = false;
    public GameObject Enemy;
    public int limiter = 1;
    public int abc = 0;
    public bool WaveStarted =false;
    // Start is called before the first frame update
    void Start()
    {
        WaveStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(WaveStarted){
            //Debug.Log("Wave Start");
            StartCoroutine(WaveAttack());
        if(delay == false && limiter <= 10){
                StartCoroutine(spawn());
        }
        }
        WaveEnded(WaveStarted);
    }

    IEnumerator WaveAttack(){
        yield return new WaitForSeconds(20);
        WaveStarted = false;
    }

    void WaveEnded(bool Wave){
        if(Wave == true){
            return;
        }
        else{
            Debug.Log("Wave Ended!");
        }
    }
    IEnumerator spawn(){
        Instantiate(Enemy,transform.position,transform.rotation);
        delay = true;
        yield return new WaitForSeconds(2);
        delay = false;
        limiter++;
    }
}
