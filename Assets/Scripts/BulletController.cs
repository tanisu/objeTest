using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] BulletData[] bulletDatas;
    SpriteRenderer sp;
    ObjectPoolController objuectPool;
    public int direction = 1;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = bulletDatas[0].sprite;
        objuectPool = transform.parent.GetComponent<ObjectPoolController>();
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.position += transform.up * bulletDatas[0].speed * Time.deltaTime * direction;
    }



    private void OnBecameInvisible()
    {
        HideFromStage();
    }

    public void ShowInStage(Vector3 _pos)
    {
        transform.localScale = new Vector3(1, direction);
        transform.position = _pos;
    }

    

    public void InitBulletType(BULLET_TYPE _type)
    {
        sp.sprite = bulletDatas[(int)_type].sprite;
    }

    public void HideFromStage()
    {
        objuectPool.Collect(this);
    }
}
