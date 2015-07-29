using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
    public bool isKeyInHole = false;
    public void OnTriggerEnter(Collider coll)
    {
        if (coll.name.Equals("KeyHoleCollider"))
        isKeyInHole = true;
        Destroy(this.gameObject.GetComponent<Rigidbody>());
    }
}
