using UnityEngine;
using System.Collections;

public class Coffin : MonoBehaviour {
    private AudioSource audioSource;
    public CameraFilterPack_TV_Vintage filter;
    public HideScript hideScripts;
    public GameObject hintsButton;
    public AudioSource backgrMusic;
    public void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip clip)
    {
        if (this.audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
            audioSource.loop = false;
        }
    }

    public void Update()
    {
        if (this.audioSource != null)
        {
            if (this.audioSource.isPlaying == false)
                backgrMusic.volume = 0.1f;
        }
    }

    public void PlaySoundAndLowBackgrSound(AudioClip clip)
    {
        if (this.audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
            audioSource.loop = false;
            backgrMusic.volume = 0.01f;
        }
    }
    public void hideKey()
    {
        GameObject key = GameObject.Find("Key");
        key.SetActive(false);
    }

    public void summonMoriarti(GameObject moriarti)
    {
        GameObject moriartiObj = Instantiate(moriarti);
        moriartiObj.transform.position = new Vector3(0,0,5f);
    }

    public void turnOffFilter()
    {
        filter.enabled = false;
    }

    public void showTips()
    {
        hideScripts.Show();
        hintsButton.SetActive(false);
    }
}
