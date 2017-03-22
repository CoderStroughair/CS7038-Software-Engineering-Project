using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;


class Generator : MonoBehaviour
{
    public static int NUMBER_OF_AGENTS = 100;
    void Start()
    {
        List<Agent> agents = new List<Agent>();
        for (int i = 0; i < NUMBER_OF_AGENTS; i++)
        {
            agents.Add(new global::Agent(i));
        }
        AgentLoader.saveToFile(agents, "Assets/Resources/agents2.json");
    }
}

[Serializable]
public class AgentLoader
{
    public List<Agent> AgentList = new List<Agent>();
    public Agent[] agents;

    public AgentLoader() { }
    private string InsertJSON()
    {
        return JsonUtility.ToJson(this);
    }

    private static AgentLoader CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<AgentLoader>(jsonString);
    }

    private static AgentLoader setFromFile(string filename)
    {
        TextAsset asset = Resources.Load(filename) as TextAsset;
        AgentLoader a = new AgentLoader();
        a = AgentLoader.CreateFromJSON(asset.text);

        for (int i = 0; i < a.agents.GetLength(0); i++)
            a.agents[i].setEnums();
        Debug.Log("Loading Complete");
        return a;
    }

    private static void saveToFile(AgentLoader aArray, string filename)
    {
        for (int i = 0; i < aArray.agents.GetLength(0); i++)
            aArray.agents[i].prepEnumStrings();

        string result = aArray.InsertJSON();

        using (FileStream fs = new FileStream(filename, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.Write(result);
            }
        }
        UnityEditor.AssetDatabase.Refresh();
        Debug.Log("Save Complete");
    }

    public static List<Agent> loadFromFile(string filename)
    {
        AgentLoader array = AgentLoader.setFromFile(filename);

        return array.AgentList;
    }

    public static void saveToFile(List<Agent> agents, string filename)
    {
        AgentLoader loader = new AgentLoader();
        loader.agents = agents.ToArray();
        saveToFile(loader, filename);
    }
}