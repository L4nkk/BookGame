using UnityEngine;

public class BookStats : MonoBehaviour
{
	public float lovePoints;
	public float hatePoints;
	public ImageFill loveFill;
	public ImageFill hateFill;
	private BookAI bookAI;

	private void Awake()
	{
		bookAI = GetComponent<BookAI>();
	}

	public void AddLovePoints(float points)
	{
		lovePoints += points;
		loveFill.UpdateFill(lovePoints);
		if (lovePoints >= 100f)
		{
			bookAI.WinVoiceLine();
		}
		Debug.Log("Love Points: " + lovePoints);
	}

	public void AddHatePoints(float points)
	{
		hatePoints += points;
		hateFill.UpdateFill(hatePoints);
		if (hatePoints >= 100f)
		{
			bookAI.LoseVoiceLine();
		}
		Debug.Log("Hate Points: " + hatePoints);
	}
}
