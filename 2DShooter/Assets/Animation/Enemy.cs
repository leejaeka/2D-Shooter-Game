using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float timeBetweenAttack;
    public int damage;
    public int health;
    [HideInInspector]
    public Transform player;
    public GameObject weapon;

    // Start is called before the first frame update
    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            
                Instantiate(weapon, transform.position, transform.rotation);
            
        }
    }


    //// Update is called once per frame
    //void Update()
    //{

    //}
}
