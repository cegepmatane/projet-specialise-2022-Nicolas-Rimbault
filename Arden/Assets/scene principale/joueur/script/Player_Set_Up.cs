using UnityEngine;
using Mirror;
public class Player_Set_Up : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] composantADesactiver;
    Camera sceneCamera;
    private void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < composantADesactiver.Length; i++)
            {
                composantADesactiver[i].enabled = false;
            }
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }
    }
    private void OnDisable()
    {
        if(sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}
