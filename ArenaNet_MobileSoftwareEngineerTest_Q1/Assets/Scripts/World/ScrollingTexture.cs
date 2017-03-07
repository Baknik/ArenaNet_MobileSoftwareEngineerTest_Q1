using UnityEngine;
using System.Collections;

public class ScrollingTexture : MonoBehaviour {

	[Header("Configuration")]
	public string SortingLayerName;
	public int SortingOrder;
	public float ScrollSpeed = 1.0f;

	private MeshRenderer myMeshRenderer;

	void Awake()
	{
		this.myMeshRenderer = this.GetComponent<MeshRenderer>();
	}

	// Use this for initialization
	void Start () {
		this.myMeshRenderer.sortingLayerName = this.SortingLayerName;
		this.myMeshRenderer.sortingOrder = this.SortingOrder;
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
