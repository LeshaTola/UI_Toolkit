using UnityEngine;

[CreateAssetMenu(menuName = "ManyImages", fileName = "Image")]
public class TemplateSO : ScriptableObject
{
	[SerializeField] private Sprite image;
	[SerializeField] private string mainText;
	[SerializeField] private string subText;

	public Sprite Image { get => image; private set => image = value; }
	public string MainText { get => mainText; private set => mainText = value; }
	public string SubText { get => subText; private set => subText = value; }
}
