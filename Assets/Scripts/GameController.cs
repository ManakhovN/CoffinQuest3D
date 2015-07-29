using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject coffin;
    private int currentState = 0;
    private bool keyClicked = false;
    private GameObject clickedObject;
    public GameObject boards;
    public GameObject key;
    // Use this for initialization
    private AcceleratorController acceleratorController;
    private Animator coffinAnimator;
    private Animator boardsAnimator;
    void Start()
    {
        acceleratorController = this.GetComponent<AcceleratorController>();
        coffinAnimator = coffin.GetComponent<Animator>();
        boardsAnimator = boards.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case 0:
                state0();
                break;
            case 1:
                state1();
                break;
            case 2:
                state2();
                break;
            case 3:
                state3();
                break;
            case 4:
                break;
        }
    }

    private void state0()
    {
        if (acceleratorController.isShaked() || Input.GetKey(KeyCode.Q))
        {
            nextState();
            coffinAnimator.SetBool("shaked", true);
            boardsAnimator.SetBool("shaked",true);
        }
    }
    private void state1()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedObject = GetClickedObject();
            if (clickedObject != null && clickedObject.name.Equals("key"))
            {
                key.GetComponent<Animator>().SetBool("KeyTouched", true);
                keyClicked = true;
            }
        }
        if (Input.GetMouseButtonUp(0)){
            keyClicked = false;
        }
        if (keyClicked)
        {            
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            curPosition.y += 1f;
            curPosition.z = 0f;
            key.transform.position = curPosition;
            if (key.GetComponent<Key>().isKeyInHole)
            {
                coffinAnimator.SetBool("keyUsed", true);
                nextState();
                clickedObject = null;
            }
 
        }
    }
    private void state2()
    {
        if (Input.acceleration.x < -0.7 || Input.acceleration.x>0.7 || Input.GetKey(KeyCode.E))
        {
            this.nextState();
            coffinAnimator.SetBool("isTilted", true);
        }
    }

    private void state3()
    {
        if (Input.GetMouseButton(0))
        {
            clickedObject = GetClickedObject();
            if (clickedObject != null && clickedObject.name.Equals("MapCollider"))
            {
                coffinAnimator.SetBool("isScrollOpened", true);
                nextState();
                Camera.main.GetComponent<PinchZoom>().canUseZoom = true;
            }
        }

        
    }

    public void setCurrenState(int currentState_)
    {
        this.currentState = currentState_;
    }

    public void nextState()
    {
        currentState++;
    }

    GameObject GetClickedObject()
    {
        GameObject target=null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.collider == null)
            return null;
        target = hit.collider.gameObject;
        return target;
    }
}
