using UnityEngine;

[RequireComponent(typeof(deplacement_joueur))]
public class controle_joueur : MonoBehaviour
{
   [SerializeField] 
   private float vitesse = 5f;

    [SerializeField]
    private float sencibilite = 3f;

    private deplacement_joueur deplacement;
    private void Start()
    {
        deplacement = GetComponent<deplacement_joueur>();           //acces au script deplacement_joueur
    }

    private void Update()
    {
        // calculer la vitesse du personnage
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertival = transform.forward * zMov;

        Vector3 velocity = (moveHorizontal + moveVertival).normalized * vitesse;

        deplacement.Move(velocity);

        // calcule de la rotation du joueur
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0, yRot, 0) * sencibilite;

        deplacement.Rotation(rotation);

        // calcule de la rotation de la camera
        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 cameraRotation = new Vector3(xRot, 0, 0) * sencibilite;

        deplacement.CameraRotation(cameraRotation);
    }
}
