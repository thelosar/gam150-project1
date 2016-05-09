using UnityEngine;
using System.Collections;

public class BossEyes : MonoBehaviour {

    public float minChangeTime = 1f;
    public float maxChangeTime = 3f;
    public float preEyeBeamDelay = 3f;
    public float postEyeBeamDelay = 3f;
    public GameObject eyeBeam;

    private Animator animator;
    private float changeTime = 1f;
    private int animationStates = 5;
    private int randomAnimation = 1;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        StartCoroutine("ChangeEyeState");
	}
	
	IEnumerator ChangeEyeState()
    {
        changeTime = Random.Range(minChangeTime, maxChangeTime);
        yield return new WaitForSeconds(changeTime);
        randomAnimation = Random.Range(1, animationStates + 1);
        animator.SetInteger("EyeState", randomAnimation);
        if (randomAnimation == 5)
            StartCoroutine("EyeBeam");
        else
            StartCoroutine("ChangeEyeState");
    }

    IEnumerator EyeBeam()
    {
        yield return new WaitForSeconds(preEyeBeamDelay);

        GameObjectUtil.Instantiate(eyeBeam, transform.position);

        yield return new WaitForSeconds(postEyeBeamDelay);

        StartCoroutine("ChangeEyeState");
    }
}
