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
    public GameObject audioSrc;
    // Start is called before the first frame update
    private void Start()
    {
        audioSrc = GameObject.Find("AudioController");
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
        //audioSrc.PlayOneShot(explosion_sound);
        //explosion.Play();
        //ParticleSystem exp = GetComponent<ParticleSystem>();
        //exp.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Enemy")
        {
            
            if (collision.GetComponent<RedSlime>()!= null)
            {
                audioSrc.GetComponent<AudioControl>().playSound("slime_dmg");
            } 
            else if (collision.GetComponent<RangedEnemy>() != null)
            {
                audioSrc.GetComponent<AudioControl>().playSound("penguin_dmg");
            }
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Explode();
            DestroyProjectile();
            
            
        } else if (collision.tag == "Player")
        {
            if (collision.GetComponent<knight>().isParrying)
            {
                speed = -speed;
                audioSrc.GetComponent<AudioControl>().playSound("knight_parry");
            }
            else {      
                collision.GetComponent<knight>().TakeDamage(damage);
                Explode();
                DestroyProjectile(); 
            }
            
        }
    }
}
