using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            // decrease t by a tiny bit
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            //fade color slowly
            img.color = new Color(1f, 1f, 1f, a);
            // wait 1 signle frame
            yield return 0;
        }

    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            // decrease t by a tiny bit
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            //fade color slowly
            img.color = new Color(1f, 1f, 1f, a);
            // wait 1 signle frame
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
