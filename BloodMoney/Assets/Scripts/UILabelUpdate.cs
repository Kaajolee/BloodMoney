using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILabelUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI healthText, enemiesLeftText;

    private static UILabelUpdate _instance;
    public static UILabelUpdate Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Global events is null");
            }
            return _instance;
        }
    }
    void Start()
    {
        GlobalEvents.Instance.HealthAmountChanged += UpdateHealthText;
        GlobalEvents.Instance.EnemyDied += UpdateEnemiesLeftText;
        UpdateHealthText();
    }
    public void UpdateHealthText()
    {
        healthText.text = "Health: " + PlayerHealthController.Instance.health.ToString();
    }
    public void UpdateEnemiesLeftText()
    {
        enemiesLeftText.text = "Enemies left: Null";
    }
}
