using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthLabelUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI healthText;

    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        GlobalEvents.Instance.HealthAmountChanged += UpdateHealthText;
        UpdateHealthText();
    }
    public void UpdateHealthText()
    {
        healthText.text = "Health: " + PlayerHealthController.Instance.health.ToString();
    }
}
