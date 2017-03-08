using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class ScrollingTexture : MonoBehaviour {

	[Header("Configuration")]
	public float ScrollSpeed;

	private MeshRenderer myMeshRenderer;

	void Awake()
	{
		this.myMeshRenderer = this.GetComponent<MeshRenderer>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.myMeshRenderer.material.mainTextureOffset =
			new Vector2(
				this.myMeshRenderer.material.mainTextureOffset.x + this.ScrollSpeed,
				this.myMeshRenderer.material.mainTextureOffset.y
			);
	}
}
