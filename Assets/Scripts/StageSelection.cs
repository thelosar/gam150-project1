using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageSelection : MonoBehaviour {

    public void GoToMainMenu()
    {
		SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void GoToInfiltrateStage()
    {
		SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void GoToBossBattle()
    {
		SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void GoToEscapeStage()
    {
		SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void RestartStage()
    {
		int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    
}
