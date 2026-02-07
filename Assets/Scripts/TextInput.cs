using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TextInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    private string _inputText;

    public event Action<string> TextEntered;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            EnterButtonPressed();
        }
    }

    public void EnterButtonPressed()
    {
        _inputText = _inputField.text.Trim().ToLower();
        Debug.Log(_inputText);
        
        if (TextEntered != null)
        {
            TextEntered.Invoke(_inputText);
        }
        _inputField.text = "";
    }
}
