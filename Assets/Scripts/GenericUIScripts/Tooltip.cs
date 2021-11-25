using UnityEngine;
using TMPro;

/** 
	The background dynamically sizes itself around the text but it doesn't line
	up properly and I don't have time to figure it out, so we have free floating text ATM
*/
public class Tooltip : MonoBehaviour {

	public static Tooltip Instance {get; private set;}		
	private TextMeshProUGUI tooltipText;
	private RectTransform rectTransform;
	
	[SerializeField]
	private RectTransform canvasRectTransform;
	private RectTransform backgroundRectTransform;

	private System.Func<string> getTooltipTextFunc;

	void Awake() {
		Instance = this;
		backgroundRectTransform = transform.Find("Background").GetComponent<RectTransform>();
		tooltipText = transform.Find("TooltipText").GetComponent<TextMeshProUGUI>();
		rectTransform = transform.GetComponent<RectTransform>();
		HideTooltip();
	}

	private void SetTooltipText(string tooltipstring){
		tooltipText.SetText(tooltipstring);
		tooltipText.ForceMeshUpdate();
		Vector2 textSize = tooltipText.GetRenderedValues(false);
		Vector2 paddingSize = new Vector2(8, 8);
		backgroundRectTransform.sizeDelta = textSize + paddingSize;
	}

	// Move it with mouse!
	private void Update(){
		SetTooltipText(getTooltipTextFunc());
		rectTransform.anchoredPosition = Input.mousePosition;
	}

	//show the instance of the tooltip
	public static void ShowTooltip_Static(string tooltipstring){
		Instance.ShowTooltip(tooltipstring);
	}
	private void ShowTooltip(string tooltipstring){
		ShowTooltip( () => tooltipstring); 
	}

	private void ShowTooltip(System.Func<string> getToolTipTextFunc){
		this.getTooltipTextFunc = getToolTipTextFunc;
		gameObject.SetActive(true);
		SetTooltipText(getToolTipTextFunc());
	}

	// hide the instance of the tooltip
	public static void HideTooltip_Static(){
		Instance.HideTooltip();
	}

	private void HideTooltip(){
		gameObject.SetActive(false);
	}

	// make it work with delegates
	public static void ShowTooltip_Static(System.Func<string> getTooltipStringFunc){
		Instance.ShowTooltip(getTooltipStringFunc);
	}
};