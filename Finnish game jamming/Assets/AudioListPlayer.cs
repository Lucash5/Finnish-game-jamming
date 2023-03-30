using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListPlayer : MonoBehaviour
{
    public List<AudioClip> audioClips;  // Lista AudioClip-objekteista
    public AudioSource audioSource;     // AudioSource-objekti

    private int currentClipIndex = 0;   // Indeksi nykyiselle Audioclipille listalla

    // Update-metodi kutsutaan jokaisella framella
    void Update()
    {
        // Jos pelaaja painaa E-näppäintä
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Jos olemme viimeisellä Audioclipillä, aloitamme listan alusta
            if (currentClipIndex >= audioClips.Count)
            {
                currentClipIndex = 0;
            }

            // Aseta AudioSource-objektin clip-arvoksi seuraava Audioclip-listalta
            audioSource.clip = audioClips[currentClipIndex];

            // Soita Audioclip
            audioSource.Play();

            // Siirry seuraavaan Audioclipiin listalla
            currentClipIndex++;
        }
    }
}
