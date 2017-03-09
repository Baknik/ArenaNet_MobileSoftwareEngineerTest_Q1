using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreText : MonoBehaviour {

	private int score;

	private Text myText;

	void Awake()
	{
		this.myText = this.GetComponent<Text>();
	}

	// Use this for initialization
	void Start () {
		this.ResetScore();
	}

	void OnEnable()
	{
		PlayerBird.RestartGame += HandleRestartGame;
		PlayerBird.PlayerScored += HandlePlayerScored;
	}

	void OnDisable()
	{
		PlayerBird.RestartGame -= HandleRestartGame;
		PlayerBird.PlayerScored -= HandlePlayerScored;
	}

	// Update is called once per frame
	void Update () {
		this.myText.text = this.score.ToString();
	}

	private void ResetScore()
	{
		this.score = 0;
	}

	private void HandleRestartGame()
	{
		this.ResetScore();
	}

	private void HandlePlayerScored()
	{
		this.score++;
	}
}
