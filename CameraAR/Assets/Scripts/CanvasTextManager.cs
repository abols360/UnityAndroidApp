﻿using UnityEngine;
using UnityEngine.UI;
using Unity.XR.CoreUtils;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class CanvasTextManager : MonoBehaviour
    {
        [SerializeField]
        Text m_TextElement;

        public Text textElement
        {
            get => m_TextElement;
            set => m_TextElement = value;
        }

        public string text
        {
            get => m_TextElement ? m_TextElement.text : null;
            set
            {
                if (m_TextElement)
                {
                    m_TextElement.text = value;
                }
            }
        }
    }
}
