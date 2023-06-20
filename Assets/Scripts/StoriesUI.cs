using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoriesUI : MonoBehaviour
{
	[Header("UI params")]
	[SerializeField] private Image background;
	[SerializeField] private TextMeshProUGUI mainText;
	[SerializeField] private Button nextButton;

	[Header("Slider params")]
	[SerializeField] private Slider SliderTemplate;
	[SerializeField] private GameObject SliderContainer;

	[Header("Story params")]
	[SerializeField] private StoryListSO stories;
	[SerializeField] private float storyDuration;

	private List<Slider> sliderTimers;
	private float storyTimer;
	private int iCurrentStoy;

	private void Awake()
	{
		iCurrentStoy = 0;
		storyTimer = storyDuration;

		sliderTimers = new List<Slider>(stories.List.Count);
		foreach (StorySO storySO in stories.List)
		{
			Slider newSlider = Instantiate(SliderTemplate, SliderContainer.transform);
			sliderTimers.Add(newSlider);
		}

		UpdateStory();

		nextButton.onClick.AddListener(() =>
		{
			NextStory();
		});
	}

	private void Update()
	{
		storyTimer -= Time.deltaTime;
		sliderTimers[iCurrentStoy].value = StoryTimerNomalised(storyTimer);
		if (storyTimer <= 0)
		{
			NextStory();
		}
	}

	private void NextStory()
	{
		float maxSliderValue = 1f;
		sliderTimers[iCurrentStoy].value = maxSliderValue;

		storyTimer = storyDuration;
		iCurrentStoy++;
		if (iCurrentStoy >= stories.List.Count)
		{
			iCurrentStoy = 0;
		}
		UpdateStory();
	}

	private float StoryTimerNomalised(float curentTime)
	{
		return 1f - (curentTime / storyDuration);
	}

	private void UpdateStory()
	{
		background.sprite = stories.List[iCurrentStoy].Background;
		mainText.text = stories.List[iCurrentStoy].MainText;
	}
}
