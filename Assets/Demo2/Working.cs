using UnityEngine;
using System.Collections;

public sealed class Working : State<Agent>
{

    static readonly Working instance = new Working();

    public static Working Instance
    {
        get
        {
            return instance;
        }
    }

    static Working() { }
    private Working() { }

    public override void Enter(Agent agent)
    {
        Debug.Log("Sitting in traffic...");
    }

    public override void Execute(Agent agent)
    {
        Debug.Log("working...");

        agent.ChangeState(Free.Instance);
    }

    public override void Exit(Agent agent)
    {
        Debug.Log("leaving work...");
    }
}