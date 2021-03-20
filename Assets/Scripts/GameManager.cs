using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded;

    public GameObject gameoverUI;

    public GameObject completeLevelUI;

    private void Start()
    {
        gameEnded = false;
    }

    void Update()
    {
        if (gameEnded)
            return;

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        gameoverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gameEnded = true;
        completeLevelUI.SetActive(true);
    }
}
