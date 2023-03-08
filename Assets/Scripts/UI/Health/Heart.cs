using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private float _lerpDuration;

    private Image _image;

	private void Awake()
	{
		_image = GetComponent<Image>();
		_image.fillAmount = 1;
	}

	public void ToFill()
	{
		StartCoroutine(FillingImage(0, 1, _lerpDuration, Fill));
	}

	public void ToEmpty()
	{
		StartCoroutine(FillingImage(1, 0, _lerpDuration, Destroy));
	}

	private IEnumerator FillingImage(float startValue, float endValue, float duration, UnityAction<float> lepringEnd)
	{
		float elapsedTime = 0;
		float nextValue;

		while (elapsedTime < duration)
		{
			nextValue = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
			_image.fillAmount = nextValue;
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		lepringEnd?.Invoke(endValue);
	}

	private void Destroy(float value)
	{
		_image.fillAmount = value;
		Destroy(gameObject);
	}

	private void Fill(float value)
	{
		_image.fillAmount = value;
	}
}
