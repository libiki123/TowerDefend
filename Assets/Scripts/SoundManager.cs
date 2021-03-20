using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip buildSound, upgradeSound, enemyDeathSound, birdSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        buildSound = Resources.Load<AudioClip>("Build");
        upgradeSound = Resources.Load<AudioClip>("Upgrade");
        enemyDeathSound = Resources.Load<AudioClip>("EnemyDead");
        birdSound = Resources.Load<AudioClip>("Bird");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void playSound(string clip)
    {
        switch (clip)
        {
            case "build":
                audioSrc.PlayOneShot(buildSound);
                break;
            case "upgrade":
                audioSrc.PlayOneShot(upgradeSound);
                break;
            case "enemyDeath":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;
            case "bird":
                audioSrc.PlayOneShot(birdSound);
                break;
            default:
                break;
        }
    }
}