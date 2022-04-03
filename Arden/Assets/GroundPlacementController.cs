using UnityEngine;

public class GroundPlacementController : MonoBehaviour
{
   [SerializeField]
   private GameObject placeablerObjectPrefab;

   [SerializeField]
   private KeyCode newObjectHotKey = KeyCode.Q;

   private GameObject currentPlacableObject;

    
    float mouseWheelRotation;
   private void Update()
   {
      HandleNewObjectHotKey();

      if(currentPlacableObject != null){
          MoveCurrentPlacableObjectToMouse();
          RotateFromMouseWheel();
          RealeseIfClicked();
      }
   }

    private void RealeseIfClicked(){
        if(Input.GetMouseButtonDown(0)){
            currentPlacableObject = null;
        }
    }
   private void RotateFromMouseWheel(){
        mouseWheelRotation += Input.mouseScrollDelta.y;
        currentPlacableObject.transform.Rotate(Vector3.up, mouseWheelRotation * 10f);
   }

    private void MoveCurrentPlacableObjectToMouse(){
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       RaycastHit hitInfo;
       if (Physics.Raycast(ray, out hitInfo))
       {
           currentPlacableObject.transform.position = hitInfo.point;
           currentPlacableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
       }
   }

   private void HandleNewObjectHotKey()
   {
       if(Input.GetKeyDown(newObjectHotKey))
       {
           if(currentPlacableObject == null){
               currentPlacableObject = Instantiate(placeablerObjectPrefab);
           }
           else
           {
               Destroy(currentPlacableObject);
           }
       }
   }
}
