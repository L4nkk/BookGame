using UnityEngine;

public class BookAI : MonoBehaviour
{
    [SerializeField] private WordChecker _wordChecker;
    [SerializeField] private TextInput _textInput;

    private void Start()
    {
        if (_wordChecker == null)
        {
            _wordChecker = GetComponent<WordChecker>();
        }

        if (_textInput == null)
        {
            _textInput = FindFirstObjectByType<TextInput>();
        }
    }

    private void OnEnable()
    {
        _wordChecker.WordChecked += ReactToPlayerInput;
    }

    private void OnDisable()
    {
        _wordChecker.WordChecked -= ReactToPlayerInput;
        _textInput.TextEntered -= OnTextEntered;
    }

    public void StartInteraction()
    {
        _textInput.TextEntered += OnTextEntered;
    }

    public void EndInteraction()
    {
        _textInput.TextEntered -= OnTextEntered;
    }

    private void OnTextEntered(string text)
    {
        _wordChecker.CheckWord(text);
    }

    private void ReactToPlayerInput(WordValue wordValue)
    {
        switch (wordValue)
        {
            case WordValue.Positive:
                // Do positive things
                Debug.Log("Positive word detected!");
                break;
            case WordValue.SuperPositive:
                // Do super positive things
                Debug.Log("Super positive word detected!");
                break;
            case WordValue.Negative:
                // Do negative things
                Debug.Log("Negative word detected!");
                break;
            case WordValue.SuperNegative:
                // Do super negative things
                Debug.Log("Super negative word detected!");
                break;
            default:
                // Word not recognized
                Debug.Log("Word not recognized.");
                break;
        }
    }
}
