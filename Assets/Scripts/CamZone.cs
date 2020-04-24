using Cinemachine;
using UnityEngine;

public class CamZone : MonoBehaviour
{
  #region Inspector

  [SerializeField]
  private CinemachineVirtualCamera cam = default;

  #endregion


  #region MonoBehaviour

  private void Start ()
  {
    cam.gameObject.SetActive(false);
  }

  private void OnTriggerEnter (Collider other)
  {
    if ( other.CompareTag("Player") )
      cam.gameObject.SetActive(true);
  }

  private void OnTriggerExit (Collider other)
  {
    if ( other.CompareTag("Player") )
      cam.gameObject.SetActive(false);
  }

  #endregion
}