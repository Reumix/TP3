using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // L'objet autour duquel la cam�ra doit tourner
    public float distance = 5.0f; // La distance entre la cam�ra et l'objet
    public float sensitivity = 2.0f; // La sensibilit� de la souris pour faire pivoter la cam�ra
    public int zoomSpeed; // La vitesse � laquelle la cam�ra doit zoomer
    public float minDistance = 2.0f; // La distance minimale � laquelle la cam�ra peut se rapprocher de l'objet
    public float maxDistance = 20.0f; // La distance maximale � laquelle la cam�ra peut s'�loigner de l'objet
    public Ui_Manager manager;

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked; // Verrouille le curseur de la souris au centre de l'�cran
        zoomSpeed = 4;
        manager.SetZoomSpeedValues(zoomSpeed);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            currentX += Input.GetAxis("Mouse X") * sensitivity;
            currentY -= Input.GetAxis("Mouse Y") * sensitivity;


            currentY = Mathf.Clamp(currentY, -90f, 90f); // Limitation de l'angle de rotation de la cam�ra

        }

        if (Input.GetKeyDown("c") && zoomSpeed > 1)
        {
            zoomSpeed -= 1;
            manager.SetZoomSpeedValues(zoomSpeed);
        }

        if (Input.GetKeyDown("v") && zoomSpeed < 10)
        {
            zoomSpeed += 1;
            manager.SetZoomSpeedValues(zoomSpeed);
        }
        float zoom = Input.GetAxis("Mouse ScrollWheel"); // Zoom avec la molette de la souris
        distance -= zoom * 4 * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
    }

    void LateUpdate()
    {
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = target.position + rotation * direction;
        transform.LookAt(target.position);
    }
}