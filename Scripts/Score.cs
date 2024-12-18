using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using static System.Net.Mime.MediaTypeNames;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;


    public GameObject player;
    public PlayerShooting ammo;
    public Transform playerPos;

    // private int score;
    private float height = 0;
    private float score;
    public int kills;
    private int scorePerKill = 20000;


    void Start()
    {
        if (player != null)
        {
            ammo = player.GetComponent<PlayerShooting>();
            playerPos = player.transform;
        }
        if (scoreText != null)
        {
            scoreText.enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (playerPos == null || scoreText == null)
        {
            return;
        }

        height = playerPos.position.y;
        score = height + kills * scorePerKill;

        int bulletAmount = ammo.GetAmmo();

        scoreText.text = $@"
Ammo: {bulletAmount}
{ score.ToString("0")}";
        
        // scoreText.text = playerPos.position.y.ToString("0");
    }
      
    
}
