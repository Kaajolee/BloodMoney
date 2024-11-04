using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvents : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;

    [SerializeField]
    private AudioClip buttonClickSound;
    void Start()
    {
        UIEvents.Instance.AnyButtonClicked += PlayButtonClickSound;
        audioSource = GetComponent<AudioSource>();
    }
    private void PlayButtonClickSound()
    {
        audioSource.clip = buttonClickSound;
        audioSource.Play();
    }
}
