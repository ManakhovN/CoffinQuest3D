using UnityEngine;
using System.Collections;

public class MoriartiConotroller : MonoBehaviour {
    public float LifeTime=3f;
    public void Update()
    {
        LifeTime -= Time.deltaTime;
        if (LifeTime < 0f)
            Destroy(this.gameObject);
    }
}
