using UnityEngine;

[CreateAssetMenu(menuName = "StoriesSettings/Story", fileName = "Story")]
public class StorySO : ScriptableObject
{
	[SerializeField] private Sprite background;
	[SerializeField, TextArea()] private string mainText;

	public Sprite Background { get => background; private set => background = value; }
	public string MainText { get => mainText; private set => mainText = value; }
}
