using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundNote : MonoBehaviour
{

    public List<AudioClip> clips = new List<AudioClip>();
    public AudioSource audio;

    // Use this for initialization
    IEnumerator Start()
    {

        while (true)
        {
            AudioClip clip = clips[Random.Range(0, clips.Count - 1)];
            audio.PlayOneShot(clip);
            yield return new WaitForSeconds(clip.length * 0.7f);
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
