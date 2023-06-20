using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StoriesSettings/StoryList", fileName = "StoryList")]
public class StoryListSO : ScriptableObject
{
	[SerializeField] private List<StorySO> list;

	public List<StorySO> List { get => list; private set => list = value; }
}
