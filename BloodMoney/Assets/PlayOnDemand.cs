using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnDemand : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource source;
    [SerializeField]
    private AudioClip clip;
    void Start()
    {
        source = GetComponent<AudioSource>();
        GlobalEvents.Instance.PlayerIsDeadCasino += PlayAudio;
    }

    void PlayAudio()
    {
        source.clip = clip;
        source.Play();
    }
}
