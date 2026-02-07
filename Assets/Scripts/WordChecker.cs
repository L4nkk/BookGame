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
        foreach (string word in _positiveWords)
        {
            if (word.Trim().ToLower().Equals(wordToCheck))
            {
                wordValue = WordValue.Positive;
                break;
            }
        }

        if (wordValue == WordValue.None)
        {
            foreach (string word in _superPositiveWords)
            {
                if (word.Trim().ToLower().Equals(wordToCheck))
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
                if (word.Trim().ToLower().Equals(wordToCheck))
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
                if (word.Trim().ToLower().Equals(wordToCheck))
                {
                    wordValue = WordValue.SuperNegative;
                    break;
                }
            }
        }

        if (WordChecked != null)
        {
            WordChecked.Invoke(wordValue);
        }
    }
}
