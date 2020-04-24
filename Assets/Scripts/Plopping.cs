using DG.Tweening;
using UnityEngine;

public class Plopping : MonoBehaviour
{
  #region Inspector

  [SerializeField]
  private GameObject[] tiles = default;

  [SerializeField]
  private GameObject[] islands = default;

  [SerializeField]
  private GameObject[] trees = default;

  [SerializeField]
  private GameObject[] bridges = default;

  [SerializeField]
  private GameObject boat = default;

  #endregion


  #region MonoBehaviour

  private void Start ()
  {
    foreach ( GameObject tile in tiles )
      Plop(tile.transform, size: 2, bottom: 5);

    foreach ( GameObject island in islands )
      Plop(island.transform, 1f);

    foreach ( GameObject bridge in bridges )
      Plop(bridge.transform, 1f);

    foreach ( GameObject tree in trees )
      Plop(tree.transform, 1.3f, bottom: 1);

    // Boat
    const float duration = 0.5f;
    const float delay = 3f;
    Transform t = boat.transform;
    Vector3 pos = t.position;
    t.DOMoveZ(pos.z, 0).From(pos.z - 10).SetDelay(delay - 0.01f);
    t.DOScale(Vector3.one, duration).From(Vector3.zero).SetDelay(delay);
    t.DOMoveY(0, duration).From(10).SetDelay(delay);
    t.DOPunchPosition(Vector3.up * 0.35f, duration * 2, 3)
     .SetDelay(delay + duration);
  }

  #endregion


  #region Methods

  private static void Plop (Transform t,
                            float extraDelay = 0,
                            float size = 1,
                            float bottom = 2)
  {
    Vector3 pos = t.position;
    Vector3 rot = t.eulerAngles;
    const float duration = 1.5f;
    float delay = GetDelay(t) + extraDelay;
    t.DOScale(new Vector3(size, 1, size), duration)
     .From(Vector3.zero)
     .SetDelay(delay);
    t.DOLocalRotate(rot, duration)
     .From(new Vector3(0, rot.y + 60, 0))
     .SetDelay(delay);
    t.DOMoveY(pos.y, duration).From(pos.y - bottom).SetDelay(delay);
  }

  private static float GetDelay (Transform t)
  {
    Vector3 pos = t.position;
    return pos.magnitude / 50 + pos.y / 2;
  }

  #endregion
}