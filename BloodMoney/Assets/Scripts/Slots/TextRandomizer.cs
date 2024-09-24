using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextRandomizer : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI[] textComponents;
    private string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RandomizeText()
    {
        for (int i = 0; i < textComponents.Length; i++)
        {
            textComponents[i].text = numbers[Random.Range(0, numbers.Length - 1)];
        }
    }
}
