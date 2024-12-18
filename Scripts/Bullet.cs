using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public float speed;

    
    // Start is called before the first frame update
    /*
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb.GetComponent<Rigidbody2D>();
        rb.velocity = (Vector2)(-transform.up) * speed;
    }
    */
   
    public void Initialize(Vector2 initialVelocity)
    {
        rb.velocity = initialVelocity + speed * (Vector2)(-transform.up);
    }
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5);
    }
}