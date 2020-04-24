using UnityEngine;
using UnityEngine.Rendering;

[ExecuteAlways]
public class BendingManagerDemo : MonoBehaviour
{
  #region Constants
  
  private const string BENDING_FEATURE = "ENABLE_BENDING";
  
  #endregion


  #region MonoBehaviour

  private void Awake ()
  {
    if ( Application.isPlaying )
      Shader.EnableKeyword(BENDING_FEATURE);
    else
      Shader.DisableKeyword(BENDING_FEATURE);
  }

  private void OnEnable ()
  {
    if ( !Application.isPlaying )
      return;

    RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
    RenderPipelineManager.endCameraRendering += OnEndCameraRendering;
  }

  private void OnDisable ()
  {
    RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
    RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
  }

  #endregion


  #region Methods

  private static void OnBeginCameraRendering (ScriptableRenderContext ctx,
                                              Camera cam)
  {
    cam.cullingMatrix = Matrix4x4.Ortho(-99, 99, -99, 99, 0.001f, 99) *
                        cam.worldToCameraMatrix;
  }

  private static void OnEndCameraRendering (ScriptableRenderContext ctx,
                                            Camera cam)
  {
    cam.ResetCullingMatrix();
  }

  #endregion
}