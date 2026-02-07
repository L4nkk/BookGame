using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    private string _inputText;

    public void EnterButtonPressed()
    {
        _inputText = _inputField.text.Trim().ToLower();
        Debug.Log(_inputText);
        // TODO: Send text to some checker to see if the book likes it ;)
    }
}
