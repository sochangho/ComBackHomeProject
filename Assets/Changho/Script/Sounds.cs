using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : SlngletonGeneral<Sounds>
{




    public List<SoundFair> soundFairs;

    public void Awake()
    {

        DontDestroyOnLoad(this.gameObject);
        
    }

    public void SoundPlay(string name)
    {
        var sound = soundFairs.Find(x => x.soundName == name);


  

        sound.source.Play();

        
    }

    public void SoundStop(string name)
    {
        var sound = soundFairs.Find(x => x.soundName == name);

        

        sound.source.Stop();

    }

    public void SoundSetActive(bool active ,string name)
    {
        var sound = soundFairs.Find(x => x.soundName == name);

        if (active)
        {
            sound.source.gameObject.SetActive(true);
            sound.source.Play();
        }
        else
        {
            sound.source.gameObject.SetActive(false);

        }
       


    }
}


[System.Serializable]
public class SoundFair
{
    public string soundName;

    public AudioSource source;
  


}