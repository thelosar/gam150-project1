using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinZone : MonoBehaviour {

    public GameObject winScreen;
    public GameObject winText;
    public bool showVictoryText = true;

    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

	void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            player.StopPlayer();
            DisplayVictoryScreen();
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            player.StopPlayer();
            DisplayVictoryScreen();
            
        }
    }

    public void DisplayVictoryScreen()
    {
        player.enabled = false;
        winScreen.SetActive(true);
        if (showVictoryText)
            winText.SetActive(true);
    }
}
