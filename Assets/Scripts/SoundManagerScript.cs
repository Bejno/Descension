using UnityEngine;
using System.Collections;

class SoundManagerScript : MonoBehaviour {
    
    public static SoundManagerScript instance;

    public AudioClip typeWriter;
    public AudioClip holyBell;
    public AudioClip tearPaper;
    public AudioClip fireBurst;
    public AudioClip wingFlap;
    public AudioClip poof;
    public AudioClip laugh;
    public AudioClip damage;


    public AudioClip music;

    void Awake()
    {
        if (instance != null)
            Debug.LogError("Only one plox");
        instance = this;
    }
    
    public GameObject PlayAudio(AudioClip clip, float volume = 1f, float pitch = 1f, bool loop = false)
    {
        var obj = new GameObject("TempAudio");
        obj.transform.SetParent(transform);
        obj.transform.position = Camera.main.transform.position;

        var audio = obj.AddComponent<AudioSource>();
        audio.clip = clip;
        audio.loop = loop;
        audio.volume = volume;
        audio.pitch = pitch;
        audio.Play();

        if (!loop)
            Destroy(obj, clip.length);

        return obj;
    }

    public static void PlayTypeWriterSound(float volume = 1f, float pitch = 1f, bool loop = false) {
        instance.PlayAudio(instance.typeWriter, volume, Random.Range(0.7f, 1.3f), loop);
    }

    public static void PlayFireBurstSound(float volume = 1f, float pitch = 1f, bool loop = false)
    {
        instance.PlayAudio(instance.fireBurst, volume, pitch, loop);
    }

    public static void PlayHolyBellSound(float volume = 1f, float pitch = 1f, bool loop = false)
    {
        instance.PlayAudio(instance.holyBell, volume, pitch, loop);
    }

    public static void PlayTearPaperSound(float volume = 1f, float pitch = 1f, bool loop = false)
    {
        instance.PlayAudio(instance.tearPaper, volume, pitch, loop);
    }

    public static void PlayWingFlapSound(float volume = 1f, float pitch = 1f, bool loop = false)
    {
        instance.PlayAudio(instance.wingFlap, volume, pitch, loop);
    }

    public static void PlayDamageSound(float volume = 1f, float pitch = 1f, bool loop = false)
    {
        instance.PlayAudio(instance.damage, volume, Random.Range(0.9f, 1.2f), loop);
    }

    public static void PlayPoofSound(float volume = 1f, float pitch = 1f, bool loop = false)
    {
        instance.PlayAudio(instance.poof, volume, pitch, loop);
    }

    public static void PlayLaughSound(float volume = 1f, float pitch = 1f, bool loop = false)
    {
        instance.PlayAudio(instance.laugh, volume, Random.Range(0.9f, 1.2f), loop);
    }

    public static void PlayMusic(float volume = 1f, float pitch = 1f, bool loop = false)
    {
        instance.PlayAudio(instance.music, volume, pitch, true);
    }

}

