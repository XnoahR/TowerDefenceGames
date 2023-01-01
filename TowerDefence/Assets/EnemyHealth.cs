using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int  Health = 100;
    [SerializeField] int CurrHealth;

public Enemy _enemy;

    // Start is called before the first frame update
    void Start()
    {
        CurrHealth = Health;
        _enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Damaged(1);
        }
    }

    public void Damaged(int Damage){
        CurrHealth -= Damage;
    Debug.Log("Damaged!");
        if(CurrHealth <= 0 ){
            CurrHealth = 0;
            _enemy.Die();
        }
    }
}
