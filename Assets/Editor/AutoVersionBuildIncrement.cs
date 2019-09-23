using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System;

public class AutoVersionBuildIncrement : MonoBehaviour
{
    [PostProcessBuild(0)]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        string currentVersion = PlayerSettings.bundleVersion;

        try
        {
            int major = Convert.ToInt32(currentVersion.Split('.')[0]);
            int minor = Convert.ToInt32(currentVersion.Split('.')[1]);
            int build = Convert.ToInt32(currentVersion.Split('.')[2]) + 1;


            PlayerSettings.bundleVersion = major + "." + minor + "." + build;
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            Debug.LogError("AutoVersionBuildIncrement script faild. Make sure your current bundle version is in the format X.X.X (e.g. 1.0.0) and not X.X (1.0) or X (1).");
        }
            Debug.Log(PlayerSettings.bundleVersion);
    }
}
