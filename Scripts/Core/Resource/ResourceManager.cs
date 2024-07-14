

using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ResourceManager
{
    private static Dictionary<string, string> configMap;
    
    static ResourceManager()
    {
        string configContent = LoadConfigFile();
        BuildMap(configContent);
    }
    
    // 加载文件
    private static string LoadConfigFile()
    {
        string path = Application.dataPath + "/Config/ResConfig.txt";
        string content = "";
        if (File.Exists(path))
        {
            content = File.ReadAllText(path);
        }
        return content;
    }
    
    // 解析文件
    private static void BuildMap(string configContent)
    {
        if (configMap == null)
        {
            configMap = new Dictionary<string, string>();
        }
        
        // 文件名=路径\r\n文件名=路径
        string[] lines = configContent.Split("\r\n");
        foreach (var line in lines)
        {
            string[] kv = line.Split('=');
            if (kv.Length == 2)
            {
                configMap.Add(kv[0], kv[1]);
            }
        }
    }
    
    public static T Load<T>(string resName) where T : UnityEngine.Object
    {
        string resPath = configMap[resName];
        return Resources.Load<T>(resPath);
    }    
}
