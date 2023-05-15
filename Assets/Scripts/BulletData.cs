using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="bulletData")]
public class BulletData : ScriptableObject
{
    public float speed;
    public Sprite sprite;
    public int power;
    public Color color;
}
