using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipScript : MonoBehaviour
{
    private RectTransform rectTransform;
    private Text tooltipText;
    private float textPadding = 4f;
    private Transform parentTransform;
    
    private void Awake() {
        rectTransform = transform.Find("bg").GetComponent<RectTransform>();
        tooltipText = transform.Find("text").GetComponent<Text>();
    }

    private void Update() {
        /* TEMPORARY FIX. Currently has empty text.
        transform.rotation = Camera.main.transform.rotation;
        if(parentTransform != null) {
            transform.position = parentTransform.position + new Vector3(0, 0.5f, 0);
        }
        */
    }

    public void initTooltip(string newText, Transform parentTransform) {
        this.parentTransform = parentTransform;
        tooltipText.text = "";
        //tooltipText.text = newText;
        Vector2 backgroundSize = new Vector2(tooltipText.preferredWidth + textPadding, tooltipText.preferredHeight + textPadding * 2f);
        rectTransform.sizeDelta = backgroundSize;
    }
}
