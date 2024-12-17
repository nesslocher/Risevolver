using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public LayerMask layersToHit;



    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, 1);

    }

    // Update is called once per frame
    void Update()
    {

        float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 50f, layersToHit);
        if (hit.collider == null)
        {
            transform.localScale = new Vector3(50f, transform.localScale.y, 1);
            return;
        }
        transform.localScale = new Vector3(hit.distance, transform.localScale.y, 1);
        if (hit.collider.tag == "Player")
        {
            // Destroy(hit.collider.gameObject);
        }
    }


}