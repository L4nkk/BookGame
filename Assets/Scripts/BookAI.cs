using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BookAI : MonoBehaviour
{
	[SerializeField] private WordChecker _wordChecker;
	[SerializeField] private TextInput _textInput;
	[SerializeField] private FaceController _faceController;
	[SerializeField] private GameObject _loveEffect;
	[SerializeField] private GameObject _dislikeEffect;
	[SerializeField] private AudioSource _audioSource;
	[SerializeField] private AudioClip[] _positiveClips;
	[SerializeField] private AudioClip[] _negativeClips;
	[SerializeField] private AudioClip[] _superPositiveClips;
	[SerializeField] private AudioClip[] _superNegativeClips;
	[SerializeField] private AudioClip[] _neutralClips;
	[SerializeField] private AudioClip[] _onClickClips;
	[SerializeField] private float _effectDuration = 2f;
	private int _currentClickClipIndex = 0;
	private Camera _mainCamera;

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

		if (_faceController == null)
		{
			_faceController = GetComponent<FaceController>();
		}

		if (_audioSource == null)
		{
			_audioSource = GetComponent<AudioSource>();
		}

		_mainCamera = Camera.main;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
		_textInput.TextEntered -= OnTextEntered;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) // Check for left or right mouse button click
		{
			RaycastHit hit;
			Ray ray = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider != null && hit.collider.gameObject == gameObject) // Check if the clicked object is part of the book
				{
					OnBookClicked();
				}
			}
		}
	}

	public void StartInteraction()
	{
		_textInput.TextEntered += OnTextEntered;
	}

	public void EndInteraction()
	{
		_textInput.TextEntered -= OnTextEntered;
	}

	public void OnBookClicked()
	{
		if (_audioSource != null && _onClickClips.Length > 0)
		{
			if (_currentClickClipIndex < _onClickClips.Length)
			{
				_audioSource.clip = _onClickClips[_currentClickClipIndex];
				_audioSource.Play();
				StartCoroutine(EffectCoroutine(null, _audioSource.clip.length));
				_currentClickClipIndex++;
			}
			else
			{
				_audioSource.clip = _onClickClips[Random.Range(0, _onClickClips.Length)];
				_audioSource.Play();
				StartCoroutine(EffectCoroutine(null, _audioSource.clip.length));
			}
		}
	}

	private void OnTextEntered(string text)
	{
		WordValue wordValue = _wordChecker.CheckWord(text);
		_textInput.UpdateFoundWordsText(text, wordValue);
		ReactToPlayerInput(wordValue);
	}

	private void ReactToPlayerInput(WordValue wordValue)
	{
		switch (wordValue)
		{
			case WordValue.Positive:
				// Do positive things
				Debug.Log("Positive word detected!");
				_faceController.SetExpression(_faceController.happy);
				StartCoroutine(EffectCoroutine(_loveEffect, _effectDuration));
				_audioSource.clip = _positiveClips[Random.Range(0, _positiveClips.Length)];
				_audioSource.Play();
				break;
			case WordValue.SuperPositive:
				// Do super positive things
				Debug.Log("Super positive word detected!");
				_faceController.SetExpression(_faceController.happy);
				StartCoroutine(EffectCoroutine(_loveEffect, _effectDuration));
				_audioSource.clip = _superPositiveClips[Random.Range(0, _superPositiveClips.Length)];
				_audioSource.Play();
				break;
			case WordValue.Negative:
				// Do negative things
				Debug.Log("Negative word detected!");
				_faceController.SetExpression(_faceController.sad);
				StartCoroutine(EffectCoroutine(_dislikeEffect, _effectDuration));
				_audioSource.clip = _negativeClips[Random.Range(0, _negativeClips.Length)];
				_audioSource.Play();
				break;
			case WordValue.SuperNegative:
				// Do super negative things
				Debug.Log("Super negative word detected!");
				_faceController.SetExpression(_faceController.angry);
				StartCoroutine(EffectCoroutine(_dislikeEffect, _effectDuration));
				_audioSource.clip = _superNegativeClips[Random.Range(0, _superNegativeClips.Length)];
				_audioSource.Play();
				break;
			default:
				// Word not recognized
				Debug.Log("Word not recognized.");
				_faceController.SetExpression(_faceController.neutral);
				StartCoroutine(EffectCoroutine(null, _effectDuration));
				if (_neutralClips.Length > 0)
				{
					_audioSource.clip = _neutralClips[Random.Range(0, _neutralClips.Length)];
					_audioSource.Play();
				}
				break;
		}
	}

	private IEnumerator EffectCoroutine(GameObject effect, float duration)
	{
		if (effect == null)
		{
			_faceController.isTalking = true;
			yield return new WaitForSeconds(duration);
			_faceController.isTalking = false;
			yield break;
		}

		foreach (Transform child in effect.transform)
		{
			child.gameObject.GetComponent<ParticleSystem>().Play();
		}
		_faceController.isTalking = true;
		yield return new WaitForSeconds(duration);
		_faceController.isTalking = false;
	}
}
