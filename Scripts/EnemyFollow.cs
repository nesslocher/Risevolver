using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;
//using static UnityEngine.RuleTile.TilingRuleOutput;



public class EnemyFollow : MonoBehaviour
{

    public AudioSource deathSound;

    public Transform player;
    public PlayerShooting ammo;

    public float verticalOffset;
    public float frequency;
    public float amplitude;

    private char path = '3';

    public Score text;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        ammo = player.GetComponent<PlayerShooting>();
        deathSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    /* update not needed in this script
    void Update()
    {

    }
    */



    public Vector3 EnemyPath(char m)
    {

        float targetY = player.position.y + verticalOffset;
        float x;
        float y;
        switch (m)
        {
            case '1': // circles
            x = Mathf.Sin(Time.time * frequency) * amplitude;
            y = targetY + Mathf.Cos(Time.time * frequency) * amplitude;
            return new Vector3(x, y);

            case '2': // upside down U's
            x = Mathf.Sin(Time.time * frequency) * amplitude;
            y = targetY + Mathf.Cos(Time.time * (frequency * 2)) * (amplitude / 2);
            return new Vector3(x, y);

            case '3': // sideways eights
                x = Mathf.Sin(Time.time * frequency) * amplitude;
            y = targetY + Mathf.Sin(Time.time * (frequency * 2)) * (amplitude / 2);
            return new Vector3(x, y);

            default: // side to side
            x = Mathf.Sin(Time.time * frequency) * amplitude;
            y = targetY;
            return new Vector3(x, y);
        }
    }


    void Update()
    {
        /*
        float targetY = player.position.y + verticalOffset;

        float x = Mathf.Sin(Time.time * frequency) * amplitude;
        float y = targetY + Mathf.Cos(Time.time * frequency) * amplitude;
        */


        transform.position = EnemyPath(path);

        // mest for debugging
        if (Input.GetKeyDown(KeyCode.J))
        {
            path++;
            if (path > '3')
            {
                path = '1';
            }
        }
        if (Input.GetKeyDown(KeyCode.Y)) amplitude++;
        if (Input.GetKeyDown(KeyCode.U)) amplitude--;
        if (Input.GetKeyDown(KeyCode.I)) frequency++;
        if (Input.GetKeyDown(KeyCode.O)) frequency--;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            Die();
        }
    }
    bool death = false;
    private void Die()
    {
        if (!death)
        {
            deathSound.Play();
            text.kills++;
            ammo.ResetAmmo();
            death = true;
        }
        Destroy(gameObject, deathSound.clip.length);

    }

}

