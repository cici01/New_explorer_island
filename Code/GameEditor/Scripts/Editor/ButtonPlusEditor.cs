using UnityEngine;
using UnityEngine.UI;
using Game;
using UnityEditor;
using UnityEditor.UI;

namespace GameEditor
{
    [CustomEditor(typeof(ButtonPlus))]
    public class ButtonPlusEditor : ButtonEditor
    {
        private ButtonPlus m_buttonPlus = null;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_buttonPlus = (ButtonPlus)target;
        }

        public override void OnInspectorGUI()
        {
            SerializedProperty property = this.serializedObject.FindProperty("m_transScale");
            EditorGUILayout.PropertyField(property);
            property = this.serializedObject.FindProperty("m_fPressScale");
            EditorGUILayout.PropertyField(property);
            property = this.serializedObject.FindProperty("m_idClickClip");
            EditorGUILayout.PropertyField(property);
            serializedObject.ApplyModifiedProperties();

            EditorGUILayout.Space();
            base.OnInspectorGUI();
            serializedObject.Update();
        }
    }
}
