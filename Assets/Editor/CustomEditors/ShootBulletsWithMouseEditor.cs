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
        Handles.color = Color.blue;

        Handles.DrawLine(
            shootBulletsWithMouse.LeftClickBulletSpawnPosition,
            shootBulletsWithMouse.LeftClickBulletSpawnPosition +
                (shootBulletsWithMouse.transform.forward * s_clickBulletLineLength),
            s_clickBulletLineThickness);
    }

    private void DrawRightClickBulletLine(ShootBulletsWithMouse shootBulletsWithMouse)
    {
        Handles.color = Color.red;

        Handles.DrawLine(
            shootBulletsWithMouse.RightClickBulletSpawnPosition,
            shootBulletsWithMouse.RightClickBulletSpawnPosition +
                (shootBulletsWithMouse.transform.forward * s_clickBulletLineLength),
            s_clickBulletLineThickness);
    }
}
