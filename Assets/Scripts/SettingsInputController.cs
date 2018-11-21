using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsInputController : MonoBehaviour {
    float timer = 0;
    bool mouseDown = false;
    public GameObject settingsPanel;
    AcceleratorController acceleratorController;
    Slider lowPassSlider;
    Slider treshHoldSlider;
    Text treshHoldLabel;
    Text lowPassLabel;
    public void Awake()
    {
        acceleratorController = FindObjectOfType<AcceleratorController>();

        lowPassSlider = settingsPanel.transform.Find("lowPassKernelSlider").GetComponent<Slider>();
        treshHoldSlider = settingsPanel.transform.Find("shakeDetectionThresholdSlider").GetComponent<Slider>();
        treshHoldLabel = settingsPanel.transform.Find("shakeDetectionThresholdLabel").GetComponent<Text>();
        lowPassLabel = settingsPanel.transform.Find("lowPassKernelLabel").GetComponent<Text>();
        if (!PlayerPrefs.HasKey("lowPassKernel"))
            PlayerPrefs.SetFloat("lowPassKernel", acceleratorController.lowPassKernelWidthInSeconds);

        lowPassChanged(PlayerPrefs.GetFloat("lowPassKernel"));
        lowPassSlider.onValueChanged.AddListener(lowPassChanged);

        if (!PlayerPrefs.HasKey("shakeDetectionThreshold"))
            PlayerPrefs.SetFloat("shakeDetectionThreshold", acceleratorController.shakeDetectionThreshold);
        treshHoldChanged(PlayerPrefs.GetFloat("shakeDetectionThreshold"));
        treshHoldSlider.onValueChanged.AddListener(treshHoldChanged);
    }

    private void treshHoldChanged(float arg0)
    {
        PlayerPrefs.SetFloat("shakeDetectionThreshold", arg0);
        PlayerPrefs.Save();
        acceleratorController.shakeDetectionThreshold = PlayerPrefs.GetFloat("shakeDetectionThreshold");
        treshHoldLabel.text = "treshHold = " + PlayerPrefs.GetFloat("shakeDetectionThreshold");
        treshHoldSlider.value = PlayerPrefs.GetFloat("shakeDetectionThreshold");
    }

    private void lowPassChanged(float arg0)
    {
        PlayerPrefs.SetFloat("lowPassKernel",arg0);
        PlayerPrefs.Save();
        acceleratorController.lowPassKernelWidthInSeconds = PlayerPrefs.GetFloat("lowPassKernel");
        lowPassSlider.value = PlayerPrefs.GetFloat("lowPassKernel");
        lowPassLabel.text = "lowPass = " + PlayerPrefs.GetFloat("lowPassKernel");
    }

    void Update () {
        if (Input.GetMouseButtonDown(0))
            mouseDown = true;
        if (Input.GetMouseButtonUp(0))
            mouseDown = false;

        if (mouseDown)
            timer += Time.deltaTime;
        else
            timer = 0f;

        if (timer > 20f)
        {
            settingsPanel.SetActive(true);
            timer = 0f;
        }
	}
}
