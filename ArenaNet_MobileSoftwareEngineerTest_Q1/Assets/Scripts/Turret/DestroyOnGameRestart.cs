using UnityEngine;
using System.Collections;

public class DestroyOnGameRestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnEnable()
	{
		PlayerBird.RestartGame += HandleRestartGame;
	}

	void OnDisable()
	{
		PlayerBird.RestartGame -= HandleRestartGame;
	}

	// Update is called once per frame
	void Update () {
	
	}

	private void HandleRestartGame()
	{
		GameObject.Destroy(this.gameObject);
	}
}
