using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraOperation : MonoBehaviour
{
    
    private int screenWidth;
    private int screenHeight;
    public float speed;

    public int XminCameraDistance; public int XmaxCameraDistance;
    public int YminCameraDistance; public int YmaxCameraDistance;

    public float minZoom; public float maxZoom;
    public float zoomSpeed = 1; private float targetOrtho; public float smoothSpeed = 2.0f;

    Vector2 mouseClickPos;
    Vector2 mouseCurrentPos;
    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        targetOrtho = Camera.main.orthographicSize;


    }

    // Update is called once per frame
    void Update()
    { // When LMB clicked get mouse click position and set panning to true (Перетягивание колёсиком мышки)
        if (Input.GetKey(KeyCode.Mouse2) )
        {
            if (mouseClickPos == default)
            {
                mouseClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            mouseCurrentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var distance = mouseCurrentPos - mouseClickPos;

            transform.position += new Vector3(Mathf.Clamp(-distance.x, YminCameraDistance, YmaxCameraDistance), Mathf.Clamp(-distance.y, YminCameraDistance, YmaxCameraDistance), 0);
            //transform.position += new Vector3( -distance.x, -distance.y, 0);
        }
            // If LMB is released, stop moving the camera
            if (Input.GetKeyUp(KeyCode.Mouse2))
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
            transform.position = new Vector3(Mathf.Clamp(camPos.x, XminCameraDistance, XmaxCameraDistance), Mathf.Clamp(camPos.y, YminCameraDistance, YmaxCameraDistance), camPos.z); // ограничение движения камеры

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0.0f) //зум
            {
                targetOrtho -= scroll * zoomSpeed;
                targetOrtho = Mathf.Clamp(targetOrtho, minZoom, maxZoom);
            }

            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
            //умножение на Time.deltaTime делает движение камеры плавной


        }
    }
