using System;
using TMPro;
using UnityEngine;

public class WinLoseCalculator : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Slot1, Slot2, Slot3;
    [SerializeField]
    private TextMeshProUGUI Bet;

    void Start()
    {
        //GlobalEvents.Instance.SlotSpinClicked += CalculateWinnings;
    }
    void ParseNumbers(out int[] values, out int bet)
    {
        values = new int[3];
        bet = 0;
        try
        {
            values[0] = int.Parse(Slot1.text);
            values[1] = int.Parse(Slot2.text);
            values[2] = int.Parse(Slot3.text);

            bet = int.Parse(Bet.text);
        }
        catch (FormatException)
        {
            Debug.LogError("Error parsing slot text/bet text to int");
            return;
        }
    }
    public void CalculateWinnings()
    {
        int[] values;
        int bet;

        ParseNumbers(out values, out bet);

        var result = (values[0], values[1], values[2]) switch
        {
            var (x, y, z) when x == 6 && y == 6 && z == 6 => 0, // 666 pizda
            var (x, y, z) when x == y && y == z => 5, // jackpot *5
            var (x, y, z) when x == y - 1 && y == z - 1 => 3, // n+1 *3
            var (x, y, z) when x == y + 1 && y == z + 1 => 3, // n-1 *3
            _ => 0,
        };

        ApplyMultiplier(bet, result);
    }
    void ApplyMultiplier(int bet, int multiplier)
    {
        switch (multiplier)
        {
            case 0:
                ChangeHealth(bet, multiplier);
                break;

            case 1:
                ChangeHealth(bet, multiplier);
                break;

            case 2:
                ChangeHealth(bet, multiplier);
                break;

            case 3:
                ChangeHealth(bet, multiplier);
                break;

            case 5:
                ChangeHealth(bet, multiplier);
                break;

            default:
                break;
        }

    }
    void ChangeHealth(int bet, int multiplier)
    {
        int winnings = bet * multiplier;
        Debug.Log("Won: " + winnings);
        PlayerHealthController.Instance.GainHealth(winnings);
    }
}
