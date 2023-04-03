using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotateObject : MonoBehaviour
{
    //R ou T pour la rotation
    [SerializeField] int time;

    private Vector3 mOffset;
    private float mZCoord;
    public float rotationSpeed = 100f; // vitesse de rotation

    public Button btn;
    private float timePressed = 0f;
    private float holdTime = 1f;
    private bool isPressed = false;

    private void Update()
    {
        //Rotation vers la droite (sens anti-horaire)
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        //Rotation vers la gauche (sens horaire)
        if (Input.GetKey(KeyCode.T))
        {
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }
    }

    void StartCoroutine()
    {
        StartCoroutine(MaCoroutine());
    }

    private IEnumerator MaCoroutine()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        yield return null;
    }
}