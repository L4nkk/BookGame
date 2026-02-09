using UnityEngine;

public class CheckButton : MonoBehaviour
{
    public GameObject[] slots;
    public MinigameManager minigameManager;
    public BookStats bookStats;
    public FaceController faceController;
    private int correctCount = 0;
    private int incorrectCount = 0;
    public BookAI bookAI;

    public void Check()
    {
        foreach (var slot in slots)
        {
            if (slot.transform.childCount == 0)
            {
                continue;
            }

            if(slot.transform.GetChild(0).GetComponent<ItemGenre>().Genre != slot.GetComponent<SlotGenre>().Genre)
            {
                Debug.Log("Wrong!");
                incorrectCount++;
            }
            else
            {
                Debug.Log("Correct!");
                correctCount++;
            }
        }

        if (correctCount == slots.Length)
        {
            bookStats.AddLovePoints(20);
            bookAI.ReactToPlayerInput(WordValue.SuperPositive);
        }
        else if (correctCount == 2 || correctCount == 3)
        {
            bookStats.AddLovePoints(10);
            bookAI.ReactToPlayerInput(WordValue.Positive);
        }
        else if (correctCount == 1)
        {
            bookStats.AddLovePoints(5);
            bookAI.ReactToPlayerInput(WordValue.Negative);
        }
        else if (correctCount == 0)
        {
            bookStats.DecrementLovePoints(10);
            bookAI.ReactToPlayerInput(WordValue.SuperNegative);

        }

        minigameManager.CompleteCurrentPanel();
        ResetCounts();
    }

    public void ResetCounts()
    {
        correctCount = 0;
        incorrectCount = 0;
    }
}
