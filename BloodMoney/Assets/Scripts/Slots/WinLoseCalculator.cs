using TMPro;
using UnityEngine;

public class WinLoseCalculator : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField Bet; // Bet input field

    private TextRandomizer textRandomizer;

    [SerializeField]
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        GlobalEvents.Instance.SlotSpinEnded += CalculateWinnings; // Subscribe to the spin event
        textRandomizer = GetComponent<TextRandomizer>();
    }

    void CalculateWinnings()
    {
        int[] slotValues = textRandomizer.finalSlotValues;
        int bet;

        // Try to parse the bet value
        if (!int.TryParse(Bet.text, out bet))
        {
            Debug.LogError("Error parsing bet text to int");
            return;
        }

        int winnings = 0; // Default winnings

        // Check win conditions
        if (slotValues[0] == 6 && slotValues[1] == 6 && slotValues[2] == 6)
        {
            winnings = 0; // Special case for 666
            textMeshPro.text = "666! UPS!";
        }
        else if (slotValues[0] == slotValues[1] && slotValues[1] == slotValues[2])
        {
            winnings = bet * 5; // Jackpot
            textMeshPro.text = $"Jackpot! You won {winnings}!";
        }
        else if (slotValues[0] == slotValues[1] - 1 && slotValues[1] == slotValues[2] - 1)
        {
            winnings = bet * 3; // Increment case
            textMeshPro.text = $"You won {winnings}!";
        }
        else if (slotValues[0] == slotValues[1] + 1 && slotValues[1] == slotValues[2] + 1)
        {
            winnings = bet * 3; // Decrement case
            textMeshPro.text = $"You won {winnings}!";
        }
        else
        {
            winnings = -bet; // Loss case, subtract bet amount from health
            textMeshPro.text = $"You lost {bet}!";
        }

        // Apply the result (win or loss)
        if (winnings >= 0)
        {
            PlayerHealthController.Instance.GainHealth(winnings);
        }
        else
        {
            if (PlayerHealthController.Instance.health + winnings <=0)
                GlobalEvents.Instance.PlayerDiedCasino();
            else
                PlayerHealthController.Instance.GainHealth(winnings);
        }

        Debug.Log($"Result: {winnings}");
    }
}
