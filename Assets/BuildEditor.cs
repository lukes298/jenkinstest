using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
using System.Collections.Generic;

public class BuildEditor
{

    static string[] sceneNames = FindEnabledEditorScenes();


    [MenuItem("Build/Windows(x86)")]

    static void PerformWindowsx86Build()
    {
        string targetDir = "Build/Windows(x86)/" + PlayerSettings.productName + ".exe";

        GenericBuild(targetDir, BuildTarget.StandaloneWindows, BuildOptions.None);

    }


    


    static void GenericBuild(string targetDir, BuildTarget buildTarget, BuildOptions buildOptions)
    {
        //Switch the platform to target platform
        EditorUserBuildSettings.SwitchActiveBuildTarget(buildTarget);

        //Perform the build
        string result = BuildPipeline.BuildPlayer(sceneNames, targetDir, buildTarget, buildOptions);

        //Check if there is an error
        if(result.Length > 0)
        {
            string error = "Build Failure:" + result;
            Debug.Log(error);
            System.Console.WriteLine(error);
        }
    }


    static string[] FindEnabledEditorScenes()
    {
        List<string> editorScenes = new List<string>();

        // Loop through all the scenes in the build settings
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
            {
                editorScenes.Add(scene.path);
            }

        }

        return editorScenes.ToArray();
    }


}
#endif
