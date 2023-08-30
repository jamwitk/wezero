using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class CreateFolders : EditorWindow
    {
        private static string projectName = "Wezero";

        [MenuItem("Assets/CreateFolders")]
        private static void SetUpFolders()
        {
            CreateFolders window = ScriptableObject.CreateInstance<CreateFolders>();
            window.position = new Rect(Screen.width / 2f, Screen.height / 2f, 400, 150);
            window.ShowPopup();
        }

        private static void CreateAllFolders()
        {
            List<string> folders = new List<string>
            {
                "Animations",
                "Audio",
                "Editor",
                "Materials",
                "Models",
                "Prefabs",
                "Resources",
                "Scenes",
                "Scripts",
                "Shaders",
                "Textures"
            };
        
            foreach (string folder in folders)
            {
                if (!AssetDatabase.IsValidFolder("Assets/" + projectName + "/" + folder))
                {
                    AssetDatabase.CreateFolder("Assets/" + projectName, folder);
                }
            }
            var uiFolders = new List<string>
            {
                "Buttons",
                "Fonts",
                "Images",
                "Icons",
                "Materials",
                "Textures"
            };
            foreach (string folder in uiFolders)
            {
                if (!AssetDatabase.IsValidFolder("Assets/" + projectName + "/UI/" + folder))
                {
                    AssetDatabase.CreateFolder("Assets/" + projectName + "/UI", folder);
                }
            }
            AssetDatabase.Refresh();
            Debug.Log("Folders Created");
        }

        private void OnGUI()
        {
            GUILayout.Label("Create Folders", EditorStyles.boldLabel);
            GUILayout.Label("Project Name");
            projectName = GUILayout.TextField(projectName);
            if (GUILayout.Button("Create Folders"))
            {
                CreateAllFolders();
                Close();
            }
        }
    }
}
