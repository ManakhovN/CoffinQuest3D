using UnityEngine;
using System.Collections;

public class HideScript : MonoBehaviour {
    public GameObject target;
    public RectTransform text;
    bool hide = false;
    private Vector3 uno = new Vector3(1f, 1f, 1f);
    private RectTransform rect;

    public void Start()
    {
        rect = this.GetComponent<RectTransform>();
    }

    public void Update()
    {
        text.sizeDelta = new Vector2(rect.rect.height-20f, rect.rect.width-20f);
        if (hide == false)
            {
                this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, Vector3.zero, 0.1f);
                this.transform.localScale = Vector3.Lerp(this.transform.localScale, uno, 0.1f);
            }
            else
            {
            
                this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, target.transform.localPosition, 0.1f);
                this.transform.localScale = Vector3.Lerp(this.transform.localScale, Vector3.zero, 0.1f);
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
        Debug.Log("click");
    }

    public void Show()
    {
        this.hide = false;
        this.gameObject.SetActive(true);
    }
}
