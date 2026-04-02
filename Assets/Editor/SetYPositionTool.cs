using UnityEngine;
using UnityEditor;

public class SetYPositionTool : EditorWindow
{
    private float newYPosition = 0f;

    [MenuItem("Tools/Set Y Position to 0")]
    public static void ShowWindow()
    {
        GetWindow<SetYPositionTool>("Set Y Position");
    }

    void OnGUI()
    {
        GUILayout.Label("Set Y Position for Selected Objects", EditorStyles.boldLabel);
        newYPosition = EditorGUILayout.FloatField("New Y Position", newYPosition);

        if (GUILayout.Button("Set Y Position"))
        {
            SetSelectedObjectsYPosition();
        }
    }

    void SetSelectedObjectsYPosition()
    {
        // Iterate over all selected GameObjects in the scene hierarchy
        foreach (GameObject go in Selection.gameObjects)
        {
            // Get the current position
            Vector3 currentPosition = go.transform.position;
            // Create a new position with the desired Y value
            Vector3 newPosition = new Vector3(currentPosition.x, newYPosition, currentPosition.z);
            // Set the object's position
            go.transform.position = newPosition;

            // Mark the object as dirty to ensure the change is saved in the scene
            EditorUtility.SetDirty(go);
        }
        Debug.Log("Set Y position of " + Selection.gameObjects.Length + " objects to " + newYPosition);
    }
}
