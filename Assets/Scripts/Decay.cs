using UnityEngine;
using System.Collections;

public class Decay : MonoBehaviour {

    public float timeToDecay = 1f;
    
    void OnEnable()
    {
        StartCoroutine("DecayCountdown");
    }
	
	IEnumerator DecayCountdown()
    {
        yield return new WaitForSeconds(timeToDecay);

        GameObjectUtil.Destroy(gameObject);
    }
}
