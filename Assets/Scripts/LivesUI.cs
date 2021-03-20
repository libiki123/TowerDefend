using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text liveText;
    
    void Update()
    {
        liveText.text = PlayerStats.Lives.ToString();
    }
}
