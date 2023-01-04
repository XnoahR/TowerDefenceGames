using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public GameObject Turret;

    [Header ("Color and Texture")]
    public Color Hover;
    private Color _DefaultColor;
    public SpriteRenderer _Renderer;


    // Start is called before the first frame update
    void Start()
    {
    _Renderer = GetComponent<SpriteRenderer>();
    _DefaultColor = _Renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnMouseDown() {
        if(Turret != null){
         Debug.Log("CANT PLACE HERE!");
         return;   
        }
        else{
            GameObject _TurretBuild = BuildManager.Instance.GetTurretBuild();
            Turret = (GameObject)Instantiate(_TurretBuild,transform.position,transform.rotation);
        }
    }

     void OnMouseEnter() {
     _Renderer.material.color = Hover;   
     Debug.Log("Color Change!");
    }

    void OnMouseExit() {
    _Renderer.material.color =_DefaultColor;
    }
}
