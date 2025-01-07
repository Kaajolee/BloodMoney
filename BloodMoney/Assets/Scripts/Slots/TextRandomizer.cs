using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextRandomizer : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> sprites; // List of slot sprites
    [SerializeField]
    private List<Image> inGameCasinoSpriteSlots; // Slot images in the UI

    [SerializeField]
    private float initialSpeed;
    [SerializeField]
    private float finalSpeed;
    [SerializeField]
    private float spinDuration;

    private int slotsSpinningCount = 0; // Counter for how many slots are still spinning

    private Dictionary<Sprite, int> spriteToNumberMap; // Map sprites to numbers
    public int[] finalSlotValues; // Stores the resulting slot numbers after spinning

    [SerializeField]
    private TextMeshProUGUI text;

    void Start()
    {
        // Initialize sprite-to-number mapping
        spriteToNumberMap = new Dictionary<Sprite, int>();
        for (int i = 0; i < sprites.Count; i++)
        {
            spriteToNumberMap[sprites[i]] = i; // Assign each sprite a unique number
        }

        finalSlotValues = new int[inGameCasinoSpriteSlots.Count]; // Initialize the results array
    }

    public void RandomizeSprites()
    {
        if (slotsSpinningCount == 0) // Only start if no slots are spinning
        {
            slotsSpinningCount = inGameCasinoSpriteSlots.Count; // Set the counter to total slots
            for (int i = 0; i < inGameCasinoSpriteSlots.Count; i++)
            {
                StartCoroutine(IconRandomizer(inGameCasinoSpriteSlots[i], i));
            }

            // Notify that the spin has started
            UIEvents.Instance.ButtonClicked();
            GlobalEvents.Instance.SpinClicked();
        }
    }

    IEnumerator IconRandomizer(Image image, int slotIndex)
    {
        // Start spinning this slot
        float elapsedTime = 0f;
        float speed = initialSpeed;

        text.text = "Spinning...";

        while (elapsedTime < spinDuration)
        {
            Sprite randomSprite = sprites[Random.Range(0, sprites.Count)];
            image.sprite = randomSprite; // Randomize the sprite
            yield return new WaitForSeconds(speed);

            float progress = elapsedTime / spinDuration;
            speed = Mathf.Lerp(initialSpeed, finalSpeed, progress);

            elapsedTime += speed;
        }

        // After spinning, set the final slot value
        Sprite finalSprite = image.sprite;
        finalSlotValues[slotIndex] = spriteToNumberMap[finalSprite];

        // Decrement the spinning counter
        slotsSpinningCount--;

        // Check if all slots have stopped spinning
        if (slotsSpinningCount == 0)
        {
            // Trigger win-lose calculation
            GlobalEvents.Instance.SpinEnded();
        }
    }
}
