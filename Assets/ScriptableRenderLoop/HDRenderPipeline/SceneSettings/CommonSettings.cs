using System;

namespace UnityEngine.Experimental.Rendering.HDPipeline
{
    public class CommonSettings : ScriptableObject
    {
        [Serializable]
        public struct Settings
        { 
            [SerializeField]
            float m_ShadowMaxDistance;

            [SerializeField]
            int m_ShadowCascadeCount;

            [SerializeField]
            float m_ShadowCascadeSplit0;

            [SerializeField]
            float m_ShadowCascadeSplit1;

            [SerializeField]
            float m_ShadowCascadeSplit2;

            public float shadowMaxDistance { set { m_ShadowMaxDistance = value; OnValidate(); } get { return m_ShadowMaxDistance; } }
            public int shadowCascadeCount { set { m_ShadowCascadeCount = value; OnValidate(); } get { return m_ShadowCascadeCount; } }
            public float shadowCascadeSplit0 { set { m_ShadowCascadeSplit0 = value; OnValidate(); } get { return m_ShadowCascadeSplit0; } }
            public float shadowCascadeSplit1 { set { m_ShadowCascadeSplit1 = value; OnValidate(); } get { return m_ShadowCascadeSplit1; } }
            public float shadowCascadeSplit2 { set { m_ShadowCascadeSplit2 = value; OnValidate(); } get { return m_ShadowCascadeSplit2; } }

            public void OnValidate()
            {
                m_ShadowMaxDistance = Mathf.Max(0.0f, m_ShadowMaxDistance);
                m_ShadowCascadeCount = Math.Min(4, Math.Max(1, m_ShadowCascadeCount));
                m_ShadowCascadeSplit0 = Mathf.Min(1.0f, Mathf.Max(0.0f, m_ShadowCascadeSplit0));
                m_ShadowCascadeSplit1 = Mathf.Min(1.0f, Mathf.Max(0.0f, m_ShadowCascadeSplit1));
                m_ShadowCascadeSplit2 = Mathf.Min(1.0f, Mathf.Max(0.0f, m_ShadowCascadeSplit2));
            }

            public static readonly Settings s_Defaultsettings = new Settings
            {

                m_ShadowCascadeCount = ShadowSettings.Default.directionalLightCascadeCount,
                m_ShadowCascadeSplit0 = ShadowSettings.Default.directionalLightCascades.x,
                m_ShadowMaxDistance = ShadowSettings.Default.maxShadowDistance,
                m_ShadowCascadeSplit1 = ShadowSettings.Default.directionalLightCascades.y,
                m_ShadowCascadeSplit2 = ShadowSettings.Default.directionalLightCascades.z
            };
        }
       
        [SerializeField]
        private Settings m_Settings = Settings.s_Defaultsettings;

        public Settings settings
        {
            get { return m_Settings; }
            set { m_Settings = value; }
        }
    }
}
