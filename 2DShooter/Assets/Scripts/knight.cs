using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class knight : MonoBehaviour
{
    public float speed;
    public int health;
    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private Animator anim;

    public List<GameObject> hearts;
    public GameObject fullHeart;
    public UnityEngine.UI.GridLayoutGroup gridLayoutGroup;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        UpdateHealthUI(health);
    }

    // Update is called once per frame
    void Update()
    {
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
        health -= damageAmount;
        UpdateHealthUI(health);
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
