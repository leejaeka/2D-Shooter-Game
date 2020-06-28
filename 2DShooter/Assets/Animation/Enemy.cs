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
            //Quaternion target = Quaternion.Euler(180, 0, 0);
            //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 1);
            weapon.GetComponent<Weapon_point>().isActive = false;
            Instantiate(weapon, transform.position, transform.rotation);
            UnityEngine.Debug.Log(weapon.GetComponent<Weapon_point>().isActive);
            
            

        }
    }


    //// Update is called once per frame
    //void Update()
    //{

    //}
}
