using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// Manages the plane material color for each recognized plane based on
    /// the <see cref="UnityEngine.XR.ARSubsystems.TrackingState"/> enumeration defined in ARSubsystems.
    /// </summary>

    public class PlaneTrackingModeVisualizer : MonoBehaviour
    {
        private MeshRenderer planeMeshRenderer;
        private Color planeMatColor = Color.cyan;

        private void Start() 
        {
            this.planeMeshRenderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            this.UpdatePlaneColor();
        }

        private void UpdatePlaneColor()
        {
            this.planeMatColor.a = planeMeshRenderer.material.color.a;
            this.planeMeshRenderer.material.color = this.planeMatColor;
        }
    }
}
