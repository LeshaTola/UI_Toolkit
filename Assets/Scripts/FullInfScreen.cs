using UnityEngine;
using UnityEngine.UIElements;

public class FullInfScreen : MonoBehaviour
{
	[SerializeField] private VisualTreeAsset fullImageTemplate;

	private VisualElement manyImagesTemplate;
	private VisualElement justImageTemplate;

	private Label detail;
	private Label description;

	private Label costText;
	private Button exitButton;


	[Header("Place")]
	[SerializeField] private FullInfSO information;

	private void OnEnable()
	{
		UIDocument uiDocument = GetComponent<UIDocument>();

		manyImagesTemplate = uiDocument.rootVisualElement.Q("ManyImages");
		justImageTemplate = uiDocument.rootVisualElement.Q("JustImage");

		detail = uiDocument.rootVisualElement.Q("ManyImagesSubText") as Label;
		description = uiDocument.rootVisualElement.Q("Discription") as Label;

		costText = uiDocument.rootVisualElement.Q("CostLable") as Label;

		exitButton = uiDocument.rootVisualElement.Q("BuyButton") as Button;
		exitButton.RegisterCallback<ClickEvent>(DestroyScreen);

		UpdateVisual();
	}

	private void DestroyScreen(ClickEvent evnt)
	{
		Destroy(gameObject);
	}

	public void UpdateVisual()
	{
		JustImageTemplate justImageContainer = new(justImageTemplate);
		justImageContainer.UpdateVisual(information);

		detail.text = information.Detail;
		description.text = information.Description;
		costText.text = "$" + information.Cost + "/night";

		ManyImagesTemplate manyImagesConteiner = new(manyImagesTemplate, fullImageTemplate, information.AdditionalInformation);
		manyImagesConteiner.UpdateVisual();
	}

	public void SetInformation(FullInfSO informationSO)
	{
		information = informationSO;
	}
}
