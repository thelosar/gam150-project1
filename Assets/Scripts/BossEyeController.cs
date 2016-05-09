using UnityEngine;
using System.Collections;

public class BossEyeController : MonoBehaviour {

    public float respawnTimer = 60f;
    public Explode eye;

    public bool respawnInitialized = false;

    private AudioSource sfx;

    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (!eye.IsActive() && !respawnInitialized)
        {
            StartCoroutine("RespawnEye");
            respawnInitialized = true;
            sfx.Play();
        }
	}

    IEnumerator RespawnEye()
    {
        yield return new WaitForSeconds(respawnTimer);
        eye.OnRespawn();
        sfx.Play();
        respawnInitialized = false;
    }

    public bool IsRespawning()
    {
        return respawnInitialized;
    }
}
