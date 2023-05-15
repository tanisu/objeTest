using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPoolController : MonoBehaviour
{
    [SerializeField] BulletController bullet;
    [SerializeField] int maxCount;
    [SerializeField] Text currentBulletText;
    Queue<BulletController> bulletQueue;
    Vector3 setPos = new Vector3(100, 100, 0);


    BULLET_TYPE bulletType;
    

    private void Awake()
    {
        bulletQueue = new Queue<BulletController>();
        for(int i = 0;i < maxCount; i++)
        {
            BulletController tmp = Instantiate(bullet, setPos, Quaternion.identity, transform);
            bulletQueue.Enqueue(tmp);
        }
    }

    private void Start()
    {
        currentBulletText.text = bulletType.ToString();
    }

    public void ChangeType()
    {
        bulletType++;
        if(bulletType == BULLET_TYPE.TYPE_MAX)
        {
            bulletType = BULLET_TYPE.NORMAL;
        }
        currentBulletText.text = bulletType.ToString();
    }

    public BulletController Launch(Vector3 _pos,bool isEnemy = false)
    {
        if (bulletQueue.Count <= 0) return null;
        BulletController tmp = bulletQueue.Dequeue();
        tmp.gameObject.SetActive(true);
        if (isEnemy)
        {
            tmp.direction = -1;
            tmp.InitBulletType(BULLET_TYPE.NORMAL);
        }
        else
        {
            tmp.direction = 1;
            tmp.InitBulletType(bulletType);
        }
        
        tmp.ShowInStage(_pos);
        return tmp;
    }

    public void Collect(BulletController _bullet)
    {
        _bullet.gameObject.SetActive(false);
        bulletQueue.Enqueue(_bullet);
    } 

}
