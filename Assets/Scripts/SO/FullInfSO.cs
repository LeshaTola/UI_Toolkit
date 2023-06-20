using UnityEngine;

[CreateAssetMenu(menuName = "Sites/Place", fileName = "Place")]
public class FullInfSO : ScriptableObject, ITemplate
{
	[Header("Image Params")]
	[SerializeField] private Sprite mainImage;
	[SerializeField] private GameObject model;

	[Header("Information Params")]
	[SerializeField] private string title;
	[SerializeField] private string location;
	[SerializeField, TextArea()] private string detail;
	[SerializeField, TextArea()] private string description;
	[SerializeField, Range(0f, 5f)] private float raiting;
	[SerializeField] private float cost;

	[Header("ManyImages Params")]
	[SerializeField] private ManyImagesSO additionalInformation;


	public Sprite MainImage { get => mainImage; private set => mainImage = value; }
	public string Title { get => title; private set => title = value; }
	public string Location { get => location; private set => location = value; }
	public float Raiting { get => raiting; private set => raiting = value; }
	public ManyImagesSO AdditionalInformation { get => additionalInformation; private set => additionalInformation = value; }
	public string Detail { get => detail; private set => detail = value; }
	public string Description { get => description; private set => description = value; }
	public float Cost { get => cost; private set => cost = value; }
	public GameObject Model { get => model; private set => model = value; }
}
