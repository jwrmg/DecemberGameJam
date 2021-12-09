using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : Singleton<AudioPlayer>
{
    public void Play(AudioClip clip)
    {
        if (clip != null)
            this.GetComponent<AudioSource>().PlayOneShot(clip);
    }
}