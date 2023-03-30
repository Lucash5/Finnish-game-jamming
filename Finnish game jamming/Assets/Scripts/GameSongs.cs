using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSongs : MonoBehaviour
{
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void song(int sonk)
    {
        if (sonk == 1)
        {
            source.Stop();
            source.volume = 0.9f;
            source.PlayOneShot(clip1);
        }
        else if (sonk == 2)
        {
            source.Stop();
            source.volume = 0.05f;
            source.PlayOneShot(clip2);
        }
        else if (sonk == 3)
        {
            source.Stop();
            source.volume = 0.15f;
            source.PlayOneShot(clip3);
        }
        else if (sonk == 4)
        {
            source.volume = 0.005f;
        }
        
    }
}
