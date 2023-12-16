using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
    [RequireComponent(typeof(ARAnchorManager))]
    [RequireComponent(typeof(ARRaycastManager))]
    public class AnchorCreator : PressInputBase
    {
        [SerializeField] private GameObject prefabModel;

        [SerializeField] private bool isPrefabAdded = false;

        private ARAnchor oldObject; 

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        List<ARAnchor> m_Anchors = new List<ARAnchor>();

        ARRaycastManager m_RaycastManager;

        ARAnchorManager m_AnchorManager;

        protected override void Awake()
        {
            base.Awake();
            m_RaycastManager = GetComponent<ARRaycastManager>();
            m_AnchorManager = GetComponent<ARAnchorManager>();
        }

        protected override void OnPress(Vector3 position)
        {
            // Raycast against planes and feature points
            const TrackableType trackableTypes = TrackableType.FeaturePoint | TrackableType.PlaneWithinPolygon;

            // Perform the raycast
            if (m_RaycastManager.Raycast(position, s_Hits, trackableTypes))
            {
                if (this.isPrefabAdded == true)
                {
                    this.DestroyOldPrefab(this.oldObject);
                }
                // Raycast hits are sorted by distance, so the first one will be the closest hit.
                // Create a new anchor
                var anchor = CreateAnchor(s_Hits[0]);
                if (anchor != null)
                {
                   // Remember the anchor so we can remove it later.
                   this.isPrefabAdded = true;
                   this.oldObject = anchor;
                }   
                else
                {
                    this.isPrefabAdded = false;
                }          
            }
        }

        private ARAnchor CreateAnchor(in ARRaycastHit hit)
        {
            ARAnchor anchor = null;

            // If tap on a plane, try to attach the anchor to the plane
            if (hit.trackable.GetType() == typeof(ARPlane))
            {
                var planeManager = GetComponent<ARPlaneManager>();
                if (planeManager != null)
                {
                    var plane = (ARPlane)hit.trackable;
                    m_AnchorManager.anchorPrefab = prefabModel;
                    return m_AnchorManager.AttachAnchor(plane, hit.pose);
                }
            }
            return anchor;
        }

        private void DestroyOldPrefab(ARAnchor oldObject)
        {
             Destroy(oldObject.gameObject);
        }
    }
}
