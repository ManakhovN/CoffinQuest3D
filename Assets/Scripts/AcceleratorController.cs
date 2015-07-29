using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AcceleratorController : MonoBehaviour {
    public float timeForShake = 0.2f;
    float delta;
    float delay=0.1f;
    Vector3 previousAcceleration;
	void Start () {
        delta = timeForShake;
        previousAcceleration = Input.acceleration;
	}
	
	// Update is called once per frame
	void Update () {
        if (delta > 0)
        {
            Vector3 currentAcceleration = Input.acceleration;
            float c = (currentAcceleration - previousAcceleration).sqrMagnitude;
            if ((currentAcceleration - previousAcceleration).sqrMagnitude > 0.5f)
            {
                delta -= Time.deltaTime;
                delay = 0.5f;
            }
            else
                delay -= Time.deltaTime;
            if (delay < 0) delta = timeForShake;
            previousAcceleration = currentAcceleration;
        }
    }

    public bool isShaked()
    {
        return delta <= 0;
    }

    public void reset()
    {
        delta = timeForShake;
    }
}
