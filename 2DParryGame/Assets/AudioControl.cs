using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public AudioClip knight_dmg;
    public AudioClip slime_dmg;
    public AudioClip knight_fire;
    public AudioClip hushtail_dmg;
    public AudioClip knight_parry;
    public AudioClip penguin_dmg;
    private AudioSource audioSrc;
    public GameObject slider;
    public AudioClip penguin_bang;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playSound(string sound)
    {
        if (sound == "knight_dmg")
        {
            audioSrc.PlayOneShot(knight_dmg);
        } else if (sound == "slime_dmg")
        {
            audioSrc.PlayOneShot(slime_dmg);
        }
        else if (sound == "knight_fire")
        {
            audioSrc.PlayOneShot(knight_fire);
        }
        else if (sound == "knight_parry")
        {
            audioSrc.PlayOneShot(knight_parry);
        }
        else if (sound == "hushtail_dmg")
        {
            audioSrc.PlayOneShot(hushtail_dmg);
        }
        else if (sound == "penguin_dmg")
        {
            audioSrc.PlayOneShot(penguin_dmg);
        }
        else if (sound == "penguin_bang")
        {
            audioSrc.PlayOneShot(penguin_bang);
        }
    }
    public void controlVolume()
    {
        //audioSrc.volume = slider.GetComponent<Slider>().value;
    }
}
