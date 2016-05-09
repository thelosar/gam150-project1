using UnityEngine;
using System.Collections;

public class LightningWall : MonoBehaviour {

    public float initialDelay = 0f;
    public float onDuration = 1f;
    public float offDuration = 1f;
    public BoxCollider2D toggledCollider;
    public SpriteRenderer toggledSprite;
	
	void Start () {
        StartCoroutine("InitialDelay");
	}
	
	IEnumerator InitialDelay()
    {
        yield return new WaitForSeconds(initialDelay);

        ToggleAndStartNext();
    }

    IEnumerator ToggleEnable()
    {
        if (toggledCollider.enabled)
            yield return new WaitForSeconds(onDuration);
        else
            yield return new WaitForSeconds(offDuration);

        ToggleAndStartNext();
    }

    private void ToggleAndStartNext()
    {
        toggledCollider.enabled = !toggledCollider.enabled;
        toggledSprite.enabled = toggledCollider.enabled;

        StartCoroutine("ToggleEnable");
    }
}
