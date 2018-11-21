using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AcceleratorController : MonoBehaviour {
/*    public float timeForShake = 0.2f;
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
    }*/

    float accelerometerUpdateInterval = 1.0f / 60.0f;
    // The greater the value of LowPassKernelWidthInSeconds, the slower the
    // filtered value will converge towards current input sample (and vice versa).
    public float lowPassKernelWidthInSeconds = 1.0f;
    // This next parameter is initialized to 2.0 per Apple's recommendation,
    // or at least according to Brady! ;)
    public float shakeDetectionThreshold = 2.0f;

    float lowPassFilterFactor;
    Vector3 lowPassValue;

    void Start()
    {
        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Input.acceleration;
    }
    Vector3 deltaAcceleration;
    void Update()
    {
        Vector3 acceleration = Input.acceleration;
        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
        deltaAcceleration = acceleration - lowPassValue;

        if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
        {
            // Perform your "shaking actions" here. If necessary, add suitable
            // guards in the if check above to avoid redundant handling during
            // the same shake (e.g. a minimum refractory period).
            Debug.Log("Shake event detected at time " + Time.time);
        }
    }

    public bool isShaked()
    {
        return deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold;
    }

    public void reset()
    {
        deltaAcceleration = Vector3.zero;
    }
}
