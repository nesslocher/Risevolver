using UnityEngine;

public class PlayerWrap : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 screenBounds;
    private float playerWidth;

    void Start()
    {
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        playerWidth = GetComponent<SpriteRenderer>().bounds.extents.x; // Half the width of the player
    }

    void Update()
    {
        Vector3 playerPosition = transform.position;

        // Wrap on X-axis
        if (playerPosition.x > screenBounds.x + playerWidth)
        {
            // Exit right, wrap to left
            playerPosition.x = -screenBounds.x - playerWidth;
        }
        else if (playerPosition.x < -screenBounds.x - playerWidth)
        {
            // Exit left, wrap to right
            playerPosition.x = screenBounds.x + playerWidth;
        }

        transform.position = playerPosition;
    }
}
