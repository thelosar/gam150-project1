using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

    public BossBody bossBody;

    private WinZone victoryMenu;

	// Use this for initialization
	void Start () {
        victoryMenu = GetComponent<WinZone>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (!bossBody.IsAlive())
        {
            victoryMenu.DisplayVictoryScreen();
        }
	}
}
