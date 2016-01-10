using UnityEngine;
using System.Collections;

public class SoundActivatorScript : MonoBehaviour {

    public bool atStart = true;
    public bool playFireBurst = false;
    public bool playHolyBell = false;
    public bool playPaperTear = false;
    public bool playTypeWriter = false;
    public bool playWingFlap = false;
    public bool playPoof = false;
    public bool playLaugh = false;
    public bool playDamage = false;

    public bool playMusic = false;

    void Start () {

        if (atStart)
        {
            PlaySound();
        }
	}

    public void PlaySound()
    {
        if (playWingFlap)
        {
            SoundManagerScript.PlayWingFlapSound();
        }
        else if (playDamage)
        {
            SoundManagerScript.PlayDamageSound();
        }
        else if (playTypeWriter)
        {
            SoundManagerScript.PlayTypeWriterSound();
        }
        else  if (playFireBurst)
        {
            SoundManagerScript.PlayFireBurstSound();
        }
        else if (playHolyBell)
        {
            SoundManagerScript.PlayHolyBellSound();
        }
        else if (playPaperTear)
        {
            SoundManagerScript.PlayTearPaperSound();
        }
        else if (playPoof)
        {
            SoundManagerScript.PlayPoofSound();
        }
        else if (playLaugh)
        {
            SoundManagerScript.PlayLaughSound();
        }
        else if (playMusic)
        {
            SoundManagerScript.PlayMusic();
        }


    }

}
