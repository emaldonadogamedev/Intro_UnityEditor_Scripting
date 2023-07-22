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

        Handles.DrawWireDisc(
            simpleKeyboardCharacterMovement.transform.position,
            simpleKeyboardCharacterMovement.transform.up,
            simpleKeyboardCharacterMovement.moveSpeed);

        Handles.Label(
            simpleKeyboardCharacterMovement.transform.position,
            $"Current Speed: {simpleKeyboardCharacterMovement.moveSpeed}");

        Handles.DrawLine(
            simpleKeyboardCharacterMovement.transform.position,
            simpleKeyboardCharacterMovement.transform.position + Vector3.up);
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
        // target is already included as part of the base 'Editor' class
        var simpleKeyboardCharacterMovement = target as SimpleKeyboardCharacterMovement;

        EditorGUILayout.LabelField("Current Movement:");

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(
                "Horizontal:" + simpleKeyboardCharacterMovement.horizontalInput);

            EditorGUILayout.Space(1f);

            EditorGUILayout.LabelField(
                "Vertical:" + simpleKeyboardCharacterMovement.verticalInput);
        EditorGUILayout.EndHorizontal();
    }
}