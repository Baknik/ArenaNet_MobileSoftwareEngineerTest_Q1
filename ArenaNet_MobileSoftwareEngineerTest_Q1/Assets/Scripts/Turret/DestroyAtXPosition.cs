using UnityEngine;
using System.Collections;

public class DestroyAtXPosition : MonoBehaviour {

	[Header("Configuration")]
	public float XPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x < this.XPosition)
		{
			GameObject.Destroy(this.gameObject);
		}
	}
}
