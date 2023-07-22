using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SimpleKeyboardCharacterMovement))]
[CanEditMultipleObjects]
public class SimpleKeyboardCharacterMovementEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("Hello! This is a simple movement script!");

        DrawEditorIsPlayingSection();

        base.OnInspectorGUI();
    }

    public void OnSceneGUI()
    {
        var simpleKeyboardCharacterMovement = target as SimpleKeyboardCharacterMovement;

        //TODO: Add custom scene GUI logic here
    }

    private void DrawEditorIsPlayingSection()
    {
        if (!EditorApplication.isPlaying)
            return;

        EditorGUILayout.LabelField("We now show this because editor is playing!");

        DrawCurrentMovementSection();
    }

    private void DrawCurrentMovementSection()
    {
        // TODO: Add custome inspector GUI section here
    }
}