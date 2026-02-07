using UnityEngine;

public class BookStats : MonoBehaviour
{
    public int lovePoints;

    public void AddLovePoints(int points)
    {
        lovePoints += points;
        Debug.Log("Love Points: " + lovePoints);
    }

    public void DecrementLovePoints(int points)
    {
        lovePoints -= points;
        Debug.Log("Love Points: " + lovePoints);
    }
}
