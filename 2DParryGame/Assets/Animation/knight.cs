﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class knight : MonoBehaviour
{
    public float speed;
    public int health;
    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private Animator anim;

    public bool isParrying;
    public float parryDuration;
    private float parryTime;
    private float parryAvailable;
    public float parryCd;
    public List<Weapon_point> inventory;
    public List<GameObject> hearts;
    public GameObject fullHeart;
    public UnityEngine.UI.GridLayoutGroup gridLayoutGroup;
    public CanvasGroup grid;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        UpdateHealthUI(health);
        grid.alpha = 0f; //this makes everything transparent
        grid.blocksRaycasts = false;
        isParrying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {

            if (isParrying == false || Time.time >= parryAvailable)
            {
                isParrying = true;
                parryAvailable = Time.time + parryCd;
                parryTime = Time.time + parryDuration;
            } 
        }
        if (Time.time >= parryTime)
        {
            isParrying = false;
        }
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;
        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
    private void UpdateHealthUI(int currentHealth)
    {
        hearts.Clear();
        GameObject[] GOS = GameObject.FindGameObjectsWithTag("HP");
        foreach (GameObject item in GOS) {
            Destroy(item);
        }

        for (int i = 0; i < currentHealth; i++)
        {
            GameObject heart = Instantiate(fullHeart, new Vector3(0, 0, 10), Quaternion.identity) as GameObject;
            hearts.Add(heart);
            hearts[i].transform.SetParent(gridLayoutGroup.transform);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }
    public void TakeDamage(int damageAmount)
    {
        if (!isParrying)
        {
            health -= damageAmount;
            UpdateHealthUI(health);
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        
    }
    public void AddWeapon(Weapon_point weapon)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        if (!inventory.Contains(weapon))
        {
            inventory.Add(weapon);
        }
        
        //Instantiate(weapon, transform.position, transform.rotation, transform);
    }
}