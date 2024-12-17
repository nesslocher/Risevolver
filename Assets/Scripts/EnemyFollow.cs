using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
// using static UnityEngine.RuleTile.TilingRuleOutput;



public class EnemyFollow : MonoBehaviour
{
    public AudioSource audio;
    public Transform player;
    public float verticalOffset;
    public float frequency;
    public float amplitude;

    private char path = '3';

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    
    /*
    void Update()
    {

    }
    */

    // 1 = circles
    // 2 = upside down "U"
    // 3 = infinities   
    // 4 = something else


    public Vector3 EnemyPath(char m)
    {

        float targetY = player.position.y + verticalOffset;
        float x;
        float y;
        switch (m)
        {
            case '1':
            x = Mathf.Sin(Time.time * frequency) * amplitude;
            y = targetY + Mathf.Cos(Time.time * frequency) * amplitude;
            return new Vector3(x, y);

            case '2':
            x = Mathf.Sin(Time.time * frequency) * amplitude;
            y = targetY + Mathf.Cos(Time.time * (frequency * 2)) * (amplitude / 2);
            return new Vector3(x, y);

            case '3':
            x = Mathf.Sin(Time.time * frequency) * amplitude;
            y = targetY + Mathf.Sin(Time.time * (frequency * 2)) * (amplitude / 2);
            return new Vector3(x, y);

            default:
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
    bool death = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            audio.Play();

            Destroy(gameObject, 0.2f);
        }
    }


}
