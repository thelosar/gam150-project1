using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour {

    public GameObject bullet;

    private AudioSource sfx;

    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
            FireProjectile();
	}

    private void FireProjectile()
    {
        if (bullet != null)
            GameObjectUtil.Instantiate(bullet, transform.position);
        else
            Debug.Log("Bullet Null");
        sfx.Play();
    }
}
