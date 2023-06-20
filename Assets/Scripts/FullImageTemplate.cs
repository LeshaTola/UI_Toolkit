using UnityEngine;
using UnityEngine.UIElements;

public class FullImageTemplate
{
	private VisualElement image;
	private Label mainText;
	//private Label subText;

	public VisualElement FullImageRoot { get; private set; }

	public FullImageTemplate(VisualTreeAsset root)
	{
		TemplateContainer newFullImageTemplate = root.Instantiate();

		FullImageRoot = newFullImageTemplate.Q();
		image = newFullImageTemplate.Q("FullImageMainImage");
		mainText = newFullImageTemplate.Q("FullImaegMainText") as Label;

		//subText = newFullImageTemplate.Q("SubText") as Label;
	}

	public void UpdateVisual(Sprite sprite, string mainText, string subText)
	{
		image.style.backgroundImage = new StyleBackground(sprite);
		this.mainText.text = mainText;
		//this.subText.text = subText;
	}

	public void UpdateVisual(TemplateSO manyImages)
	{
		image.style.backgroundImage = new StyleBackground(manyImages.Image);
		mainText.text = manyImages.MainText;
		//subText.text = manyImages.SubText;
	}
}
