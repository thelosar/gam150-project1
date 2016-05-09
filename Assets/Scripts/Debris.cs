using UnityEngine;
using System.Collections;

public class Debris : Explode {

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Floor" || target.gameObject.tag == "Bullet")
        {
            OnExplode();
        }
    }

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.gameObject.tag == "Floor" || target.gameObject.tag == "Bullet")
		{
			OnExplode();
		}
	}
}
