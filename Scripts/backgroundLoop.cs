using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject[] backgroundPrefabs; // Background prefabs to use
    public float backgroundHeight;         // Height of each background piece
    private Queue<GameObject> backgroundQueue; // Queue for recycling backgrounds
    private Camera mainCamera;
    private Vector2 screenBounds;

    public int poolSize = 3; // Number of backgrounds to preload

    void Start()
    {
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        backgroundQueue = new Queue<GameObject>();

        // Preload background objects
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bg = Instantiate(backgroundPrefabs[i % backgroundPrefabs.Length]);
            bg.transform.position = new Vector3(0, i * backgroundHeight, 0);
            backgroundQueue.Enqueue(bg);
        }
    }

    void Update()
    {
        float cameraTop = mainCamera.transform.position.y + screenBounds.y;

        // Check if the bottom background piece is off-screen
        GameObject bottomBackground = backgroundQueue.Peek();
        if (bottomBackground.transform.position.y + backgroundHeight < cameraTop - screenBounds.y * 2)
        {
            // Reposition and recycle the background
            GameObject recycledBackground = backgroundQueue.Dequeue();
            recycledBackground.transform.position += new Vector3(0, poolSize * backgroundHeight, 0);
            backgroundQueue.Enqueue(recycledBackground);
        }
    }
}
