using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    public bool delay = false;
    public GameObject Enemy;
    public int limiter = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(delay == false && limiter <= 10){
                StartCoroutine(spawn());
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
