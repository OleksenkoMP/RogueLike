using UnityEngine;
using UnityEditor;

public class OMP_Renamer : EditorWindow
{
    private GameObject[] GameObjects;
    private string Name;
    private int Index = 0;

    [MenuItem("OMP/RenameNestedGameObjects")]
    public static void ShowWindow() =>
        GetWindow(typeof(OMP_Renamer));

    private void OnGUI()
    {
        GameObjects = Selection.gameObjects;

        if (GameObjects == null || GameObjects.Length <= 0)
            return;
        
        foreach (GameObject go in GameObjects)
        {
            GUILayout.Label(go.name, EditorStyles.boldLabel);
            Name = EditorGUILayout.TextField("Base Name", Name);
            EditorGUILayout.LabelField("Counter:", "%n");


            if (GUILayout.Button("Rename"))
            {
                RenameNestedGameObjects(go);
            }
        }
    }

    private void RenameNestedGameObjects(GameObject gameObject)
    {
        switch (Name.Contains("%n"))
        {
            case true:
                RenameWithN(gameObject);
                break;
            case false:
                RenameWithoutN(gameObject);
                break;
            default:
                RenameWithoutN(gameObject);
                break;
        }
    }

    private void RenameWithoutN(GameObject go)
    {
        foreach (Transform child in go.transform)
        {
            Undo.RegisterCompleteObjectUndo(child.gameObject, "");
            child.name = Name;
            EditorUtility.SetDirty(go);
        }
    }

    private void RenameWithN(GameObject go)
    {
        int pos = Index;
        string pos_index = pos.ToString();
        foreach (Transform child in go.transform)
        {
            pos_index = pos.ToString();
            while (pos_index.Length < 3)
            {
                pos_index = '0' + pos_index;
            }
            Undo.RegisterCompleteObjectUndo(child.gameObject, "");
            child.name = Name.Replace("%n", pos_index);
            pos++;
            EditorUtility.SetDirty(go);
        }
    }

}
