using UnityEngine;
using System.Collections;

public class BitsDecaying : Bits {

    public float timeToDecay = 1f;

	// Use this for initialization
	void Start () {
        StartCoroutine("Decay");
        Scatter();
	}
	
	void OnEnable()
    {
        StartCoroutine("Decay");
        Scatter();
    }

    IEnumerator Decay()
    {
        yield return new WaitForSeconds(timeToDecay);
        GameObjectUtil.Destroy(gameObject);
    }
}
