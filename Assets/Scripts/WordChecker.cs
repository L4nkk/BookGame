using System;
using UnityEngine;

public class WordChecker : MonoBehaviour
{
    [SerializeField] private string[] _positiveWords;
    [SerializeField] private string[] _negativeWords;
    [SerializeField] private string[] _superPositiveWords;
    [SerializeField] private string[] _superNegativeWords;

    public event Action<WordValue> WordChecked;

    public void CheckWord(string wordToCheck)
    {
        WordValue wordValue = WordValue.None;
        int iterations = 0;
        foreach (string word in _positiveWords)
        {
            if (word.Trim().ToLower().Equals(wordToCheck) && !word.Equals(""))
            {
                wordValue = WordValue.Positive;
                _positiveWords[iterations] = ""; // Clear the matched word to prevent future matches
                break;
            }
            iterations++;
        }

        iterations = 0;

        if (wordValue == WordValue.None)
        {
            foreach (string word in _superPositiveWords)
            {
                if (word.Trim().ToLower().Equals(wordToCheck))
                {
                    wordValue = WordValue.SuperPositive;
                    _superPositiveWords[iterations] = ""; // Clear the matched word to prevent future matches
                    break;
                }
                iterations++;
            }
        }

        iterations = 0;
        if (wordValue == WordValue.None)
        {
            foreach (string word in _negativeWords)
            {
                if (word.Trim().ToLower().Equals(wordToCheck))
                {
                    wordValue = WordValue.Negative;
                    _negativeWords[iterations] = ""; // Clear the matched word to prevent future matches
                    break;
                }
                iterations++;
            }
        }

        iterations = 0;
        if (wordValue == WordValue.None)
        {
            foreach (string word in _superNegativeWords)
            {
                if (word.Trim().ToLower().Equals(wordToCheck))
                {
                    wordValue = WordValue.SuperNegative;
                    _superNegativeWords[iterations] = ""; // Clear the matched word to prevent future matches
                    break;
                }
                iterations++;
            }
        }

        if (WordChecked != null)
        {
            WordChecked.Invoke(wordValue);
        }
    }
}
