using UnityEngine;
using System.Collections;

public class PlayerDestroyed : MonoBehaviour {

    private AudioSource sfx;
    private Player player;
    public bool playerDead = false;

	// Use this for initialization
	void Start () {
        sfx = GetComponent<AudioSource>();
        player = FindObjectOfType<Player>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (!playerDead)
        {
            if (player == null)
            {
                sfx.Play();
                playerDead = true;
            }
        }
	}
}
