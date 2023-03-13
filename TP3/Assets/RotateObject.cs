using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public float rotationSpeed = 100f; // vitesse de rotation

    private void Update()
    {
        //Rotation vers la droite (sens anti-horaire)
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        //Rotation vers la gauche (sens horaire)
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }
    }

    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        transform.rotation = Quaternion.Euler(0, -GetMouseWorldPos().x * 2, 0);
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint) + mOffset;
    }
}