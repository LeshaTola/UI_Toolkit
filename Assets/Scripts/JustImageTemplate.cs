using UnityEngine.UIElements;

public class JustImageTemplate
{

	//private GameObject modelContainer;
	private Button mainImageButton;

	private Label title;
	private Label subTitle;
	private Label raiting;

	public VisualElement JustImageRoot { get; private set; }

	public JustImageTemplate(VisualTreeAsset template)
	{
		TemplateContainer newJustImageTemplate = template.Instantiate();
		JustImageRoot = newJustImageTemplate.Q();

		Init();
	}

	public JustImageTemplate(VisualElement element)
	{
		JustImageRoot = element;

		Init();
	}

	private void Init()
	{
		mainImageButton = JustImageRoot.Q("MainImageButton") as Button;
		title = JustImageRoot.Q("Title") as Label;
		subTitle = JustImageRoot.Q("SubTitle") as Label;
		raiting = JustImageRoot.Q("RatingLable") as Label;
	}

	public void UpdateVisual(FullInfSO information)
	{
		mainImageButton.style.backgroundImage = new StyleBackground(information.MainImage);
		/*if (place.Model != null)
		{
			Instantiate(place.Model, modelContainer.transform);
		}
		else
		{
			Destroy(modelContainer.gameObject);
		}*/

		title.text = information.Title;
		subTitle.text = information.Location;
		raiting.text = information.Raiting.ToString();
	}

	public void SetButtonAction(EventCallback<ClickEvent> action)
	{
		mainImageButton.RegisterCallback<ClickEvent>(action);
	}
}
