using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;


public class RebindSaveLoad : MonoBehaviour
{
    public InputActionAsset actions;
    private string path_to_settings_file;

    private void Awake()
    {
        path_to_settings_file = Path.Combine(Application.persistentDataPath, "bindy.json");
    }

    public void OnEnable()
    {
        // var rebinds = PlayerPrefs.GetString("rebinds");
        // if (!string.IsNullOrEmpty(rebinds))
        //     actions.LoadBindingOverridesFromJson(rebinds);

        if (File.Exists(path_to_settings_file))
        {
            var rebinds = File.ReadAllText(path_to_settings_file);
            actions.LoadBindingOverridesFromJson(rebinds);
        }
    }

    public void OnDisable()
    {
        var rebinds = actions.SaveBindingOverridesAsJson();
        // PlayerPrefs.SetString("rebinds", rebinds);
        File.WriteAllText(path_to_settings_file, rebinds);
        Debug.Log("Zaipsano plik w " + path_to_settings_file);

    }
}
