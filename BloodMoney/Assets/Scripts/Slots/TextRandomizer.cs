using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextRandomizer : MonoBehaviour
{
    // Start is called before the first frame update
    //public TextMeshProUGUI[] textComponents;

    private string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    [SerializeField]
    private List<Sprite> sprites;
    [SerializeField]
    private List<Image> inGameCasinoSpriteSlots;


    private bool isSpinning = false;

    [SerializeField]
    private float initialSpeed;
    [SerializeField]
    private float finalSpeed;
    [SerializeField]
    private float spinDuration;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RandomizeSprites()
    {
        if (!isSpinning)
        {
            foreach (var image in inGameCasinoSpriteSlots)
            {
                StartCoroutine(IconRandomizer(image));
            }

            UIEvents.Instance.ButtonClicked();
            GlobalEvents.Instance.SpinClicked();
        }
    }
    IEnumerator IconRandomizer(Image image)
    {
        isSpinning = true;

        float elapsedTime = 0f;
        float speed = initialSpeed;


        while (elapsedTime < spinDuration) 
        {
            image.sprite = sprites[Random.Range(0, sprites.Count)];

            Debug.Log("Sprite ranomized");

            yield return new WaitForSeconds(speed);

            float progress = elapsedTime / spinDuration;
            speed = Mathf.Lerp(initialSpeed, finalSpeed, progress);

            elapsedTime += speed;
        }

        isSpinning = false;

    }
}
