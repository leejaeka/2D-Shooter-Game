using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    //public Transform explosion;
    //public GameObject explosion;
    public int damage;
    public GameObject explosion;

    // Start is called before the first frame update
    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        //Destroy(gameObject, lifeTime);  
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);


    }
    void Explode()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        //explosion.Play();
        //ParticleSystem exp = GetComponent<ParticleSystem>();
        //exp.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Explode();
            DestroyProjectile();
            
            
        } else if (collision.tag == "Player")
        {
            if (collision.GetComponent<knight>().isParrying)
            {
                speed = -speed;
            }
            else {      
                collision.GetComponent<knight>().TakeDamage(damage);
                Explode();
                DestroyProjectile(); }
            
        }
    }
}
