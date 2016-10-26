using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class HideScript : MonoBehaviour, IPointerClickHandler {
    public GameObject target;
    public RectTransform text;
    bool hide = false;
    private Vector3 uno = new Vector3(1f, 1f, 1f);
    private RectTransform rect;
    public GameObject tipsButton;
    public void Start()
    {
        rect = this.GetComponent<RectTransform>();
    }

    public void Update()
    {
        text.sizeDelta = new Vector2(0.9f*rect.rect.height, 0.85f*rect.rect.width);
        if (hide == false)
            {
                this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, Vector3.zero, 0.3f);
                this.transform.localScale = Vector3.Lerp(this.transform.localScale, uno, 0.3f);
            }
            else
            {
            
                this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, target.transform.localPosition, 0.3f);
                this.transform.localScale = Vector3.Lerp(this.transform.localScale, Vector3.zero, 0.3f);
                if (this.transform.localScale.x < 0.05f)
                {
                    hide = false;
                    this.gameObject.SetActive(false);
                }
            }
    }

    public void Hide()
    {
        this.hide = true;
    }

    public void Show()
    {
        this.hide = false;
        this.gameObject.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Hide();
        tipsButton.SetActive(true);
    }
}
