using UnityEngine;
using System.Collections;

public class EyeBeam : MonoBehaviour {

    public float warningTime = 2f;
    public float beamDuration = 2f;
    public float afterimageDuration = 2f;
    public Animator animator;
    public BoxCollider2D beamCollider;
    public ulong sfxDelay = 400;

    private AudioSource sfx;

    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }
	
	void OnEnable()
    {
        beamCollider.enabled = false;
        StartCoroutine("EyeBeamAnimation");
    }

    IEnumerator EyeBeamAnimation()
    {
        animator.SetInteger("BeamState", 0);
        yield return new WaitForSeconds(warningTime);
        animator.SetInteger("BeamState", 1);
        beamCollider.enabled = true;
        sfx.Play(sfxDelay);
        yield return new WaitForSeconds(beamDuration);
        animator.SetInteger("BeamState", 2);
        beamCollider.enabled = false;
        yield return new WaitForSeconds(afterimageDuration);
        GameObjectUtil.Destroy(gameObject);
    }
}
