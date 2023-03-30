using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
public class AudioListPlayer : MonoBehaviour
{
    public TextMeshProUGUI text;
    private bool rp = false;
    public Transform P;
    public Transform T;
    public AudioClip rickroll;
    public List<AudioClip> audioClips;  // Lista AudioClip-objekteista
    public AudioSource audioSource;     // AudioSource-objekti

    private int currentClipIndex = -1;   // Indeksi nykyiselle Audioclipille listalla

    private void Start()
    {

    }
    void Update()
    {

        if (P.position.x > -18 && P.position.x < -12 && P.position.z < -69 && P.position.z > -75 && rp == false)
        {
            text.enabled = true;
            if (Input.GetKey(KeyCode.E))
            {
            text.enabled = false;
            rp = true;
            audioSource.Stop();
            audioSource.PlayOneShot(rickroll);
            }
        }
        else
        {
            text.enabled = false;
        }



            if (currentClipIndex >= audioClips.Count)
            {
                currentClipIndex = 0;
            }
            if (!audioSource.isPlaying)
            {
            currentClipIndex++;
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();
            }
    }

}
