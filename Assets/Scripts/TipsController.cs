using UnityEngine;
using System.Collections;

public class TipsController : MonoBehaviour {

    public void ShowElement(GameObject showObject)
    {
        showObject.SetActive(true);
    }

    public void HideElement(GameObject showObject)
    {
        showObject.SetActive(false);
    }


}
