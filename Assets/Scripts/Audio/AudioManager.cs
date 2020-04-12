using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Singleton { get; private set; }

    [SerializeField] private AudioSource AudioComp;
    [SerializeField] private AudioClip AudioError ;
    

    private void Awake()
    {
        if(Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlayASound(AudioClip SoundToPlay)
    {
        AudioComp.PlayOneShot(SoundToPlay);
    }

    public void PlayErrorSound()
    {
        PlayASound(AudioError);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
