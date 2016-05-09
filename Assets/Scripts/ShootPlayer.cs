using UnityEngine;
using System.Collections;

public class ShootPlayer : MonoBehaviour {

    public float reloadSpeedMin = .75f;
    public float reloadSpeedMax = 1.5f;
    public bool targetInSight = false;
    public GameObject projectile;

    private AudioSource sfx;
    private float reloadDelay = 1f;

	void Start()
    {
        StartCoroutine("ShootIfReady");
        sfx = GetComponent<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            targetInSight = true;
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "Player")
            targetInSight = false;
    }

    IEnumerator ShootIfReady()
    {
        reloadDelay = Random.Range(reloadSpeedMin, reloadSpeedMax);

        yield return new WaitForSeconds(reloadDelay);

        if (targetInSight)
            FireAtTarget();

        targetInSight = false;

        StartCoroutine("ShootIfReady");
    }

    private void FireAtTarget()
    {
        GameObjectUtil.Instantiate(projectile, transform.position);
        if (sfx != null)
            sfx.Play();
    }
}
