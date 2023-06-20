using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainScreen : MonoBehaviour
{
	[SerializeField] private List<VisualTreeAsset> scrolList;
	[SerializeField] private List<ScriptableObject> scrolListSO;
	[SerializeField] private VisualTreeAsset fullImageTemplate;
	[SerializeField] private FullInfScreen fullInformationTemplate;

	private ScrollView scrollView;

	private enum SOType
	{
		FullInfSO,
		ManyImagesSO
	}

	private void OnEnable()
	{
		UIDocument uiDocument = GetComponent<UIDocument>();
		scrollView = uiDocument.rootVisualElement.Q("MainInformation") as ScrollView;

		UpdateVisual();
	}

	private void UpdateVisual()
	{
		scrollView.Clear();

		for (int i = 0; i < scrolListSO.Count; i++)
		{
			CreateElement(scrolListSO[i]);
		}
	}

	private void CreateElement(ScriptableObject SO)
	{
		if (SO is FullInfSO)
		{
			JustImageTemplate justImageContainer = new(scrolList[(int)SOType.FullInfSO]);
			justImageContainer.UpdateVisual(SO as FullInfSO);
			justImageContainer.SetButtonAction((ClickEvent evnt) =>
			{
				FullInfScreen NewFIS = Instantiate(fullInformationTemplate);
				NewFIS.SetInformation(SO as FullInfSO);
				NewFIS.UpdateVisual();
			});
			scrollView.Add(justImageContainer.JustImageRoot);
		}
		else if (SO is ManyImagesSO)
		{
			ManyImagesTemplate manyImagesConteiner = new(scrolList[(int)SOType.ManyImagesSO], fullImageTemplate, SO as ManyImagesSO);
			manyImagesConteiner.UpdateVisual();
			scrollView.Add(manyImagesConteiner.ManyImagesRoot);
		}
		else
		{
			throw new System.Exception("Unknown element type");
		}
	}
}
