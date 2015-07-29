using UnityEngine;
using System.Collections;

using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    public float perspectiveZoomSpeed = 8f;        
    public float orthoZoomSpeed = 8f;        
    public bool canUseZoom = false;
    public float moveSpeedDivide = 100f;
    void Update()
    {
        if (!canUseZoom) return;
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x/moveSpeedDivide, -touchDeltaPosition.y/moveSpeedDivide, 0f);
            Vector3 correct = transform.position;
            if (correct.x < -2f) correct.x = -2;    // Границы передвижения камеры
            if (correct.x > 1.8f) correct.x = 1.8f;
            if (correct.y < -2.5f) correct.y = -2.5f;
            if (correct.y > 3f) correct.y = 3f;
            transform.position = correct;

        }
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            if (GetComponent<Camera>().orthographic)
            {
                var cam = GetComponent<Camera>();
                if (cam.orthographicSize < 5.2 && deltaMagnitudeDiff > 0) //Максимальное отдаление
                    cam.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;              
               if (cam.orthographicSize > 2.5 && deltaMagnitudeDiff <= 0) //Максимальное приближение
                   cam.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
               if (cam.orthographicSize > 5.2) cam.orthographicSize = 5.2f;
               if (cam.orthographicSize < 2.5) cam.orthographicSize = 2.5f;

                GetComponent<Camera>().orthographicSize = Mathf.Max(GetComponent<Camera>().orthographicSize, 0.1f);
            }
            
        }
    }
}