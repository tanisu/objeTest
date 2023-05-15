using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ObjectPoolController objectPool;
    
    void Start()
    {
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            objectPool.ChangeType();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            objectPool.Launch(transform.position);
        }
    }

}
