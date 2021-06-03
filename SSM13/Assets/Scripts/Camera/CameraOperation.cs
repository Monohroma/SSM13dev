using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraOperation : MonoBehaviour
{
    
    private int screenWidth;
    private int screenHeight;
    public float speed;

    public MapLimit MapLimits;

    public float minZoom; public float maxZoom;
    public float zoomSpeed; private float targetOrtho; public float smoothSpeed;

    Vector2 mouseClickPos;
    Vector2 mouseCurrentPos;
    
    void Start()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        targetOrtho = Camera.main.orthographicSize;
    }

   
    void Update()
    { 
        if (Input.GetKey(KeyCode.Mouse2) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (mouseClickPos == default)
            {
                mouseClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            mouseCurrentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var distance = mouseCurrentPos - mouseClickPos;

            transform.position += new Vector3(Mathf.Clamp(-distance.x, MapLimits.YminCameraDistance, MapLimits.YmaxCameraDistance), Mathf.Clamp(-distance.y, MapLimits.YminCameraDistance, MapLimits.YmaxCameraDistance), 0);
           
        }
            // If LMB is released, stop moving the camera
            if (Input.GetKeyUp(KeyCode.Mouse2) && !EventSystem.current.IsPointerOverGameObject())
            {
                mouseClickPos = default;
            }
            
            // движение камеры, когда курсор возле указанной части экрана
            Vector3 camPos = transform.position;
            if (Input.mousePosition.x <= 10 & Input.GetKey(KeyCode.Mouse2) != true  ) //с этой позиции камера начинает двигаться если колёсико мышки не нажато 
            {
            camPos.x -= speed * Time.deltaTime * (Camera.main.orthographicSize >= 2.9 ? 2 : Camera.main.orthographicSize/2) ;  
            }
            else if (Input.mousePosition.x >= screenWidth - 10 & Input.GetKey(KeyCode.Mouse2) != true)
            {
                camPos.x += speed * Time.deltaTime * (Camera.main.orthographicSize >= 2.9 ? 2 : Camera.main.orthographicSize / 2); // умножение на зум камеры, чтобы уменьшить чувствительность при приближении.
            }
            else if (Input.mousePosition.y <= 12 & Input.GetKey(KeyCode.Mouse2) != true)
            {
                camPos.y -= speed * Time.deltaTime * (Camera.main.orthographicSize >= 2.9 ? 2 : Camera.main.orthographicSize / 2);
            }
            else if (Input.mousePosition.y >= screenHeight - 10 & Input.GetKey(KeyCode.Mouse2) != true)
            {
                camPos.y += speed * Time.deltaTime * (Camera.main.orthographicSize >= 2.9 ? 2 : Camera.main.orthographicSize / 2);
            }
            transform.position = new Vector3(Mathf.Clamp(camPos.x, MapLimits.XminCameraDistance, MapLimits.XmaxCameraDistance), Mathf.Clamp(camPos.y, MapLimits.YminCameraDistance, MapLimits.YmaxCameraDistance), camPos.z); // ограничение движения камеры

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0.0f && !EventSystem.current.IsPointerOverGameObject()) 
            {
                targetOrtho -= scroll * zoomSpeed;
                targetOrtho = Mathf.Clamp(targetOrtho, minZoom, maxZoom);
            }

            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
            //умножение на Time.deltaTime делает движение камеры плавной


        }
    }
