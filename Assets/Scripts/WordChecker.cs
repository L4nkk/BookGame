using UnityEngine;

public class WordChecker : MonoBehaviour
{
    [SerializeField] private string[] _positiveWords;
    [SerializeField] private string[] _negativeWords;
    [SerializeField] private string[] _superPositiveWords;
    [SerializeField] private string[] _superNegativeWords;

    public void CheckWord(string wordToCheck)
    {
        WordValue wordValue = WordValue.None;
        foreach (string word in _positiveWords)
        {
            if (word.Equals(wordToCheck))
            {
                wordValue = WordValue.Positive;
                break;
            }
        }

        if (wordValue == WordValue.None)
        {
            foreach (string word in _superPositiveWords)
            {
                if (word.Equals(wordToCheck))
                {
                    wordValue = WordValue.SuperPositive;
                    break;
                }
            }
        }

        if (wordValue == WordValue.None)
        {
            foreach (string word in _negativeWords)
            {
                if (word.Equals(wordToCheck))
                {
                    wordValue = WordValue.Negative;
                    break;
                }
            }
        }

        if (wordValue == WordValue.None)
        {
            foreach (string word in _superNegativeWords)
            {
                if (word.Equals(wordToCheck))
                {
                    wordValue = WordValue.SuperNegative;
                    break;
                }
            }
        }

        switch (wordValue)
        {
            case WordValue.Positive:
                // Do positive things
                break;
            case WordValue.SuperPositive:
                // Do super positive things
                break;
            case WordValue.Negative:
                // Do negative things
                break;
            case WordValue.SuperNegative:
                // Do super negative things
                break;
            default:
                Debug.Log("No value assigned to the word: " + wordToCheck);
                break;
        }
    }
}
