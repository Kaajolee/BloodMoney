using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int maxTime;

    [SerializeField]
    private float whiteRate;

    [SerializeField]
    private AudioClip beep;

    [SerializeField]
    private AudioClip explosion;

    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private TextMeshPro textMeshProUGUI;

    [SerializeField]
    private SpriteRenderer whiteCover, nukeSprite;

    void Start()
    {
        textMeshProUGUI.text = maxTime.ToString();
        source = GetComponent<AudioSource>();
    }
    private void Awake()
    {
        StartCoroutine(TimerFunction());
    }

    IEnumerator TimerFunction()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            textMeshProUGUI.text = (maxTime - 1).ToString();
            maxTime--;

            if(maxTime <= 3)
                textMeshProUGUI.color = Color.red;

            if(maxTime == 0)
            {
                source.clip = explosion;
                source.Play();
                StartCoroutine(WhiteScreen());
                GlobalEvents.Instance.NukeBoom();
                nukeSprite.sprite = null;
                textMeshProUGUI.text = string.Empty;
                break;
            }
            source.Play();
        }
    }
    IEnumerator WhiteScreen()
    {
        whiteCover.color = Color.white;
        Color currentColor = whiteCover.color;
        float alpha = currentColor.a;

        while (alpha > 0)
        {
            yield return new WaitForSeconds(whiteRate);

            alpha -= 0.02f; // Adjust this step value to control fade speed (smaller = slower)
            alpha = Mathf.Clamp01(alpha);

            
            whiteCover.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
        }
    }

}
