using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform shootingPoint;
    public float shootingInterval;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootLazerAtIntervals());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            InstantiateLazer();
        }
    }

    IEnumerator ShootLazerAtIntervals()
    {
        while (true)
        {
            InstantiateLazer();
            yield return new WaitForSeconds(shootingInterval);
        }
    }

    void InstantiateLazer()
    {
        Debug.Log("hi");
        GameObject Lazer = Instantiate(laserPrefab, shootingPoint.position, shootingPoint.rotation);

        
    }
}
