using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class TextInput : MonoBehaviour
{
	[SerializeField] private TMP_InputField _inputField;
	private string _inputText;
	[SerializeField] private AudioSource _audioSource;
	[SerializeField] private TextMeshProUGUI _foundWordsText;
	[SerializeField] private Color _positiveColor = Color.green;
	[SerializeField] private Color _negativeColor = Color.red;

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

	public void PlayInputSound()
	{
		if (_audioSource != null)
		{
			_audioSource.Play();
		}
	}

	public void UpdateFoundWordsText(string word, WordValue wordValue)
	{
		string cleanedWord = word.Trim().ToLower();
		if (wordValue != WordValue.None && _foundWordsText != null)
		{
			// Add the found word the display with a color based on its value
			switch (wordValue)
			{
				case WordValue.Positive:
					_foundWordsText.text += $"<mark={"#" + _positiveColor.ToHexString()}>{cleanedWord}</mark> ";
					break;
				case WordValue.SuperPositive:
					_foundWordsText.text += $"<mark={"#" + _positiveColor.ToHexString()}><b>{cleanedWord}</b></mark> ";
					break;
				case WordValue.Negative:
					_foundWordsText.text += $"<mark={"#" + _negativeColor.ToHexString()}>{cleanedWord}</mark> ";
					break;
				case WordValue.SuperNegative:
					_foundWordsText.text += $"<mark={"#" + _negativeColor.ToHexString()}><b>{cleanedWord}</b></mark> ";
					break;
			}
		}
	}
}
