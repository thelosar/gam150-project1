using UnityEngine;
using System.Collections;

public class BossBody : MonoBehaviour {

    public BossEyeController[] eyes;
    private bool isAlive = true;

    private Explode bossExplode;
    private int eyesRespawning = 0;

    void Start()
    {
        bossExplode = GetComponent<Explode>();
    }
	
	
	// Update is called once per frame
	void Update () {
        eyesRespawning = 0;
        for (int eyeCheck = 0; eyeCheck < eyes.Length; eyeCheck++)
        {
            if (eyes[eyeCheck].respawnInitialized)
                eyesRespawning++;
            else
                return;
        }
        if (eyesRespawning == eyes.Length)
        {
            isAlive = false;
            bossExplode.OnExplodeLite();
        }  
	}

    public bool IsAlive()
    {
        return isAlive;
    }
}
