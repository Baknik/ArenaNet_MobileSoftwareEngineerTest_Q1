using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class SortedQuad : MonoBehaviour {

	[Header("Configuration")]
	public string SortingLayerName;
	public int SortingOrder;

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
	
	}
}
