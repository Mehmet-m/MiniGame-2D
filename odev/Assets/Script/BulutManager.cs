using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulutManager : MonoBehaviour
{
    public float bulutDamage, lifeTime;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }


    void Update()
    {
        
    }
}
