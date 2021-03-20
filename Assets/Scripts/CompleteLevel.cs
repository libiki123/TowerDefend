using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    public string nextLevelName = "Level02";


    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }

    public void Continue()
    {
        int nextLevelReach = PlayerPrefs.GetInt("levelReached") + 1;
        PlayerPrefs.SetInt("levelReached", nextLevelReach);
        sceneFader.FadeTo(nextLevelName);
    }

}
