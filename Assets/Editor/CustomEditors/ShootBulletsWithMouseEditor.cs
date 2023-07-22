using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShootBulletsWithMouse))]
public class ShootBulletsWithMouseEditor : Editor
{
    private static readonly float s_clickBulletLineLength = 1f;
    private static readonly float s_clickBulletLineThickness = 5f;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    public void OnSceneGUI()
    {
        var shootBulletsWithMouse = target as ShootBulletsWithMouse;

        DrawLeftClickBulletLine(shootBulletsWithMouse);

        DrawRightClickBulletLine(shootBulletsWithMouse);
    }

    private void DrawLeftClickBulletLine(ShootBulletsWithMouse shootBulletsWithMouse)
    {
        //TODO: Add logic
    }

    private void DrawRightClickBulletLine(ShootBulletsWithMouse shootBulletsWithMouse)
    {
        //TODO: Add logic
    }
}
