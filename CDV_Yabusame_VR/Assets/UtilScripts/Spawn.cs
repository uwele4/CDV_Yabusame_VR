using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawn : MonoBehaviour
{

    //public UnityEvent OnSpawn(Object) ;
    public delegate void SpawnEvent(GameObject gameObject);
    public SpawnEvent OnSpawn;

    [SerializeField]
    private Launcher spawnListener;

    [SerializeField, Tooltip("Prefab to spawn")]
    private GameObject prefab;

    void Start()
    {

        if(spawnListener != null)
        {
            OnSpawn += spawnListener.OnSpawn;
        }

    }

    public void SpawnPrefab()
    {
        GameObject instance = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity); 
        OnSpawn?.Invoke(instance);
    }

}
