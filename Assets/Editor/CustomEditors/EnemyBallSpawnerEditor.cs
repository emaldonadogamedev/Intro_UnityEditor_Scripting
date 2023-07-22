using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyBallSpawner))]
public class EnemyBallSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // TODO: additional editor logic here

        base.OnInspectorGUI();
    }

    private void OnSceneGUI()
    {
        // TODO: additional scene view editor logic here

        // var enemyBallSpawner = target as EnemyBallSpawner;
    }
}
