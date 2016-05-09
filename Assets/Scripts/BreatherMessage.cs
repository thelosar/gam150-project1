using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BreatherMessage : MonoBehaviour {

    public Text textBox;
    public string message = "A moment to breathe...";
    public float messageSpeed = 0.1f;

    private bool playerInRange = false;
    private bool displayMessageActive = false;

	void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            playerInRange = true;
            StartCoroutine("DisplayMessage");
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            playerInRange = false;
            if (!displayMessageActive)
                textBox.text = "";
        }
    }
	
	IEnumerator DisplayMessage()
    {
        char[] messageChars = message.ToCharArray();
        displayMessageActive = true;

        for (int letters = 0; letters < message.Length; letters++)
        {
            
            yield return new WaitForSeconds(messageSpeed);
            textBox.text += messageChars[letters];

            if (!playerInRange)
            {
                letters = message.Length;
                textBox.text = "";
            }
        }
        displayMessageActive = false;
    }
}
