using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOver : MonoBehaviour
{
	[SerializeField] private Button _restartButton;
	[SerializeField] private Button _exitButton;
	[SerializeField] private PlayerLogic _player;

	private CanvasGroup _gameOverGroup;

	private void OnEnable()
	{
		_player.Died += OnDied;
		_restartButton.onClick.AddListener(OnRestartButtonClick);
		_exitButton.onClick.AddListener(OnExitButtonClick);
	}

	private void OnDisable()
	{
		_player.Died -= OnDied;
		_restartButton.onClick.RemoveListener(OnRestartButtonClick);
		_exitButton.onClick.RemoveListener(OnExitButtonClick);
	}

	private void Start()
	{
		_restartButton.gameObject.SetActive(false);
		_exitButton.gameObject.SetActive(false);
		_gameOverGroup = GetComponent<CanvasGroup>();
		_gameOverGroup.alpha = 0;
	}

	private void OnDied()
	{
		_gameOverGroup.alpha = 1;
		Time.timeScale = 0;
		_restartButton.gameObject.SetActive(true);
		_exitButton.gameObject.SetActive(true);
	}

	private void OnRestartButtonClick()
	{
		SceneManager.LoadScene(0);
		Time.timeScale = 1;
	}

	private void OnExitButtonClick()
	{
		Application.Quit();
	}
}
