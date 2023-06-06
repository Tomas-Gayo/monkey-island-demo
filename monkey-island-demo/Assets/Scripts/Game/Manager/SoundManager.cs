using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static AudioClip attack;
    private static AudioClip hurt;
    private static AudioClip death;
    private static AudioClip type;
    private static AudioSource audioSrc;

    // Get the sounds from the resources folder
    void Start()
    {
        attack = Resources.Load<AudioClip>("Audio/Characters/attack");
        hurt = Resources.Load<AudioClip>("Audio/Characters/hurt");
        death = Resources.Load<AudioClip>("Audio/Characters/death");
        type = Resources.Load<AudioClip>("Audio/UI/type");

        audioSrc = GetComponent<AudioSource>();
    }

    // Through the player and enemy controller the cases are set so here the animations are switch depending on the setted value
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "attack":
                audioSrc.PlayOneShot(attack);
                break;

            case "hurt":
                audioSrc.PlayOneShot(hurt);
                break;

            case "death":
                audioSrc.PlayOneShot(death);
                break;

            case "type":
                audioSrc.PlayOneShot(type);
                break;
        }
    }
}
