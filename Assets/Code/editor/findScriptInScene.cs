using UnityEditor;
using UnityEngine;

public class findScriptInScene : EditorWindow
{
    [MenuItem("Tools/Find Objects With Script")]
    private static void ShowWindow()
    {
        var window = GetWindow<findScriptInScene>();
        window.titleContent = new GUIContent("Find Objects With Script");
        window.Show();
    }

    private string scriptName = "";

    private void OnGUI()
    {
        scriptName = EditorGUILayout.TextField("Script Name:", scriptName);

        if (GUILayout.Button("Find"))
        {
            FindObjects();
        }
    }

    private void FindObjects()
    {
        if (string.IsNullOrWhiteSpace(scriptName)) return;

        // Try to get the type from the script name
        var type = GetType(scriptName);
        if (type != null)
        {
            var objectsWithScript = FindObjectsOfType(type);
            Selection.objects = objectsWithScript;
            Debug.Log(objectsWithScript.Length + " objects with script " + scriptName + " found." + "Object name");

            foreach (var objectWithScript in objectsWithScript)
            {
                Debug.Log("objectname: " + objectWithScript.name.ToString());
            }
        }
        else
        {
            Debug.LogWarning("Script not found: " + scriptName);
        }
    }

    private System.Type GetType(string typeName)
    {
        var type = System.Type.GetType(typeName);
        if (type != null) return type;

        // If the type wasn't found, try searching all loaded assemblies
        foreach (var asm in System.AppDomain.CurrentDomain.GetAssemblies())
        {
            type = asm.GetType(typeName);
            if (type != null) return type;
        }

        return null;
    }
}