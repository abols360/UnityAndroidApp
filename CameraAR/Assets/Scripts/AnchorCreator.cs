﻿using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
    [RequireComponent(typeof(ARAnchorManager))]
    [RequireComponent(typeof(ARRaycastManager))]
    public class AnchorCreator : PressInputBase
    {
        public GameObject prefabModel;

        private bool needToDeleteModel = false;
        private int prefabChildCount = 0;

        private int activeChildIndex = 0;
        private int nextChildIndex = 1;

        private int previousChildIndex;

        [SerializeField] private GameObject lowerButton; 

        private int buttonHeight;

        private ARAnchor oldObject; 

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        ARRaycastManager m_RaycastManager;

        ARAnchorManager m_AnchorManager;

        //private Vector3 oldPosition; 

        protected override void Awake()
        {
            base.Awake();
            this.m_RaycastManager = GetComponent<ARRaycastManager>();
            this.m_AnchorManager = GetComponent<ARAnchorManager>();
        }
        private void Start() 
        {
            this.buttonHeight = (int)this.lowerButton.GetComponent<RectTransform>().rect.height;
            this.prefabChildCount = this.prefabModel.transform.childCount;
            previousChildIndex = prefabChildCount - 1;
            for(int i = 0; i < prefabChildCount; i++) 
            {
                if (i == 0)
                {
                    this.prefabModel.transform.GetChild(i).gameObject.SetActive(true);
                }
                else
                {
                    this.prefabModel.transform.GetChild(i).gameObject.SetActive(false);
                }  
            }
        }

        protected override void OnPress(Vector3 position)
        {

            // Raycast against planes and feature points
            const TrackableType trackableTypes = TrackableType.FeaturePoint | TrackableType.PlaneWithinPolygon;

            // Perform the raycast
            if (m_RaycastManager.Raycast(position, s_Hits, trackableTypes) && position.y > this.buttonHeight)
            {
                if (this.needToDeleteModel == true)
                {
                    this.DestroyOldPrefab(this.oldObject);
                    this.needToDeleteModel = false;
                }
                // Raycast hits are sorted by distance, so the first one will be the closest hit.
                // Create a new anchor
                var anchor = CreateAnchor(s_Hits[0]);
                if (anchor != null)
                {
                   // Remember the anchor so we can remove it later.
                   this.needToDeleteModel = true;
                   this.oldObject = anchor;
                }   
                else
                {
                    this.needToDeleteModel = false;
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
                    this.m_AnchorManager.anchorPrefab = prefabModel;
                    return this.m_AnchorManager.AttachAnchor(plane, hit.pose);
                }
            }
            return anchor;
        }

        private void DestroyOldPrefab(ARAnchor old3dModel)
        {
            Destroy(old3dModel.gameObject);
        }

        public void ShowNextAnimal()
        {
            if (this.prefabChildCount <= this.activeChildIndex)
            {
                this.activeChildIndex = 0;
            }
            if (this.prefabChildCount <= this.nextChildIndex) 
            {
                this.nextChildIndex = 0;
            }

            // this.prefabModel.transform.GetChild(this.activeChildIndex).gameObject.SetActive(false);
            // this.prefabModel.transform.GetChild(this.nextChildIndex).gameObject.SetActive(true);
            this.oldObject.transform.GetChild(this.activeChildIndex).gameObject.SetActive(false);
            this.oldObject.transform.GetChild(this.nextChildIndex).gameObject.SetActive(true);
            this.previousChildIndex = this.activeChildIndex;
            this.activeChildIndex ++;
            this.nextChildIndex ++;
        }

        public void ShowPreviousAnimal()
        {
            if (this.activeChildIndex < 0)
            {
                this.activeChildIndex = this.prefabChildCount - 1;
            }
            if (this.previousChildIndex < 0) 
            {
                this.previousChildIndex = this.prefabChildCount - 1;
            }
            // this.prefabModel.transform.GetChild(this.activeChildIndex).gameObject.SetActive(false);
            // this.prefabModel.transform.GetChild(this.previousChildIndex).gameObject.SetActive(true);
            this.oldObject.transform.GetChild(this.activeChildIndex).gameObject.SetActive(false);
            this.oldObject.transform.GetChild(this.previousChildIndex).gameObject.SetActive(true);
            this.nextChildIndex = this.activeChildIndex;
            this.activeChildIndex --;
            this.previousChildIndex --;
        }
    }
}
