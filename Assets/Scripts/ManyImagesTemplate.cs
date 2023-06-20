using UnityEngine.UIElements;

public class ManyImagesTemplate
{
	public VisualElement ManyImagesRoot;
	private ScrollView scrollView;

	private VisualTreeAsset fullImageTemplate;

	private ManyImagesSO manyImagesSO;

	public ManyImagesTemplate(VisualTreeAsset template, VisualTreeAsset fullImageTemplate, ManyImagesSO manyImagesSO)
	{
		TemplateContainer newManyImagesTemplate = template.Instantiate();
		ManyImagesRoot = newManyImagesTemplate.Q();

		Init(fullImageTemplate, manyImagesSO);
	}

	public ManyImagesTemplate(VisualElement element, VisualTreeAsset fullImageTemplate, ManyImagesSO manyImagesSO)
	{
		ManyImagesRoot = element;

		Init(fullImageTemplate, manyImagesSO);
	}

	private void Init(VisualTreeAsset fullImageTemplate, ManyImagesSO manyImagesSO)
	{
		scrollView = ManyImagesRoot.Q("ScrollView") as ScrollView;

		this.fullImageTemplate = fullImageTemplate;
		this.manyImagesSO = manyImagesSO;
	}

	public void UpdateVisual()
	{
		if (ManyImagesRoot == null)
		{
			return;
		}

		if (manyImagesSO.TemplatesSOList.Count == 0)
		{
			ManyImagesRoot.RemoveFromHierarchy();
			return;
		}
		else
		{
			scrollView.Clear();

			foreach (TemplateSO miniTemplate in manyImagesSO.TemplatesSOList)
			{
				FullImageTemplate newTemplate = new(fullImageTemplate);
				newTemplate.UpdateVisual(miniTemplate);
				scrollView.Add(newTemplate.FullImageRoot);
			}
		}
	}
}
