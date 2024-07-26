using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 touchPosition;
    private bool isTouchingPaddle;
    
    

    

    void Start()
    {
        mainCamera = Camera.main;
        isTouchingPaddle = false;
    }

    void Update()
    {
        Move();
            
    }
        
     private float Move()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = mainCamera.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null && hit.collider.gameObject == gameObject)
                    {
                        isTouchingPaddle = true;
                    }
                }
            }

            if (isTouchingPaddle && (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary))
            {
                touchPosition = mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, mainCamera.WorldToScreenPoint(transform.position).z));
                transform.position = new Vector3(touchPosition.x, touchPosition.y, transform.position.z);
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isTouchingPaddle = false;
            }
        }

        return 0;
    }
      
    

}
