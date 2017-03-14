using UnityEngine;
using System.Collections;

public class FSM <T> {

    private T agent;
    private State<T> state;

    public void Awake()
    {
        this.state = null;
    }

    public void Init(T agent, State<T> startState)
    {
        this.agent = agent;
        this.state = startState;
    }

    public void Update()
    {
        if (this.state != null) this.state.Execute(this.agent);
    }

    public void ChangeState(State<T> nextState)
    {
        if (this.state != null) this.state.Exit(this.agent);
        this.state = nextState;
        if (this.state != null) this.state.Enter(this.agent);
    }
}
