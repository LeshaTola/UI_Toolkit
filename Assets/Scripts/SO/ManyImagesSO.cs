using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sites/ManyPlace", fileName = "PlaceM")]
public class ManyImagesSO : ScriptableObject, ITemplate
{
	[SerializeField] private List<TemplateSO> templatesSOList;

	public List<TemplateSO> TemplatesSOList { get => templatesSOList; private set => templatesSOList = value; }
}
