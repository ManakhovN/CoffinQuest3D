using UnityEngine;
using System.Collections;

public class Coffin : MonoBehaviour {
    private AudioSource audioSource;
    public CameraFilterPack_TV_Vintage filter;
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
}
