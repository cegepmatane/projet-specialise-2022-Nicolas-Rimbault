using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class deplacement_joueur : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    private Vector3 velocity;
    private Vector3 rotation;
    private Vector3 cameraRotation;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotation(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void CameraRotation(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }
    private void FixedUpdate()
    {
        Effectuer_mouvement();
        Effectuer_rotation();
    }

    private void Effectuer_mouvement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void Effectuer_rotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        camera.transform.Rotate(-cameraRotation);
    }
}
