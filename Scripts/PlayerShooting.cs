using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    bool InStandingLayer = false;



    public AudioSource shotSound;

    public Transform shootingPoint;
    public GameObject bulletPrefab;
    int gunForce = 100;
    public int maxAmmo;
    public int ammo;

    private Rigidbody2D player;


    void Start()
    {
        ResetAmmo();
        player = GetComponent<Rigidbody2D>();
        shotSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   

        // mouse pointing
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y).normalized;

        if (!InStandingLayer)
        {
            transform.up = -direction;
        }
        else
        {
            transform.up = Vector3.zero;
        }



        // shoot, recoil
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.E))
        {
            if (ammo > 0)
            {
                ammo--;
    
    
                shotSound.pitch = 1;
                shotSound.pitch *= Random.Range(0.7f, 1.2f);
                shotSound.Play();
    
                if (!InStandingLayer)
                {
                    player.AddForce(-direction * gunForce);
                }
                else
                {
                    Vector2 up = new Vector2(0, 1);
                    player.AddForce(up * gunForce);
                }
    
                GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
                Bullet bulletScript = bullet.GetComponent<Bullet>();
                bulletScript.Initialize(player.velocity);
            }
        }


    }
    public int GetAmmo()
    {
        return ammo;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Entered trigger with {other.gameObject.name}");
        if (other.CompareTag("StandingLayer"))
        {
            InStandingLayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("StandingLayer"))
        {
            InStandingLayer = false;
        }
    }

    public void ResetAmmo()
    {
        // ammo is never null in unity Lol
        // if (maxAmmo == null || ammo <= 0)
        if (ammo <= 0)
        {
            maxAmmo = 20;
        }
        ammo = maxAmmo;
    }

}