using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainLevel";
    public SceneFader sceneFader;

    public void PLay()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Exit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }

}
