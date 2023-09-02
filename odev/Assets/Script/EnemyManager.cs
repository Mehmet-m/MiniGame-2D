using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public float health;
    public float damage;
    bool coliderBussy = false;

    public Slider slider;

    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }


    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player"&&!coliderBussy)
        {
            coliderBussy = true;
            collision.GetComponent<PlayerManager>().GetDamage(damage);
        }
        else if (collision.tag=="Bullet")
        {
            GetDamage(collision.GetComponent<BulutManager>().bulutDamage);
            Destroy(collision.gameObject);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            coliderBussy = false;
        }
    }
    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIdead();
    }
    void AmIdead()
    {
        if (health <= 0)
        {
            DataManager.Instance.EnemyKilled++;
            Destroy(gameObject);
        }
    }
}
