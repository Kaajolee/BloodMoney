using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDied : MonoBehaviour
{
    [SerializeField]
    private GameObject inGameCanvas, deathCanvas, buttons;

    [SerializeField]
    private Image background;

    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;

    [SerializeField]
    private float fadeDuration = 2f; // Duration of the fade effect

    void Start()
    {
        deathCanvas.SetActive(false);
        buttons.SetActive(false);


        GlobalEvents.Instance.PlayerIsDeadOther += DeathNoteOther;
        GlobalEvents.Instance.PlayerIsDeadCasino += DeathNoteCasino;

        GlobalEvents.Instance.PlayerIsDeadOther += PlayerHasDied;
        GlobalEvents.Instance.PlayerIsDeadCasino += PlayerHasDied;
    }

    // Call this method when the player dies
    void PlayerHasDied()
    {
        inGameCanvas.SetActive(false);
        deathCanvas.SetActive(true);
        StartCoroutine(FadeIn());
    }
    void DeathNoteCasino()
    {
        textMeshProUGUI.text = "The house always wins...";
    }
    void DeathNoteOther()
    {
        textMeshProUGUI.text = "You died...";
    }
    // Coroutine to fade in the background and text
    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        // Get the initial alpha values of the background and text
        Color backgroundColor = background.color;
        Color textColor = textMeshProUGUI.color;

        // Fade background and text from invisible to visible
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);

            // Update the alpha values of the background and text
            background.color = new Color(backgroundColor.r, backgroundColor.g, backgroundColor.b, alpha);
            textMeshProUGUI.color = new Color(textColor.r, textColor.g, textColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the background and text are fully visible at the end
        background.color = new Color(backgroundColor.r, backgroundColor.g, backgroundColor.b, 1f);
        textMeshProUGUI.color = new Color(textColor.r, textColor.g, textColor.b, 1f);

        // Enable the buttons after the transition
        buttons.SetActive(true);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void TryAgain()
    {
        SceneManager.LoadScene("Geimas");
        GlobalEvents.Instance.Reload();
    }
}
