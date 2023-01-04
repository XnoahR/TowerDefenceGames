using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    void Awake(){
        if(Instance != null){
            Debug.LogError("More than one buildmanager");
            return;
        }

        Instance = this;
    }
    private GameObject _TurretBuild;
    public GameObject _TurretPrefab;

    public GameObject GetTurretBuild(){
        return _TurretBuild;
    }
    // Start is called before the first frame update
    void Start()
    {
        _TurretBuild = _TurretPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
