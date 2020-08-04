using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Weapon_point : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    public float timeBetweenShots;
    private float shotTime;
    public Transform player;
    public bool isActive = true; // true if player picks up if i want to implement it 
    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
    }
    // Update is called once per frame
    private void Update()
    {
        if (isActive)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle-86, Vector3.forward);
            transform.rotation = rotation;

            if (Input.GetMouseButton(0))
            {
                if(Time.time >= shotTime)
                {
                    Instantiate(projectile, shotPoint.position, transform.rotation);
                    shotTime = Time.time + timeBetweenShots;
                    player.GetComponent<knight>().audioSrc.PlayOneShot(player.GetComponent<knight>().shoot_sound);
                }
            }
            
        }
        
    }

}
