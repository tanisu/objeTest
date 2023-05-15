using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float interval = 0;
    float shootInterval = 1f;
    [SerializeField] ObjectPoolController objectPool;
    

    private void Start()
    {
        interval = shootInterval;
    }

    void Update()
    {
        interval -= Time.deltaTime;

        if(interval <= 0)
        {
            
            objectPool.Launch(transform.position,true);
            interval = shootInterval;
        }
        
    }
}
