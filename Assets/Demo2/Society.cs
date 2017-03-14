using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Society : MonoBehaviour {

    public List<Agent> agents;
    public List<Tweet> tweets;

	// Use this for initialization
	void Start () {

        tweets = new List<Tweet>();
        agents = new List<Agent>();
        for(int i=0;i<10;i++)
        {
            agents.Add(new Agent(i));

            for (int j = 0; j < 10; j++)
            {
                if (i != j)
                    agents[i].followingList.Add(j);
            }
        }
        StartCoroutine("LinearTime");
        /*
        for (int i = 0; i < 10; i++)
        {
            agents[i].MakeTweet(ref tweets);
        }

        for (int i = 0; i < 10; i++)
        {
            agents[i].ReadNewsFeed(agents,ref tweets);
        }

        Debug.Log(agents[5].religion.ToString());
        for (int i = 0; i<agents[5].following.Count; i++)
        {
            Debug.Log(agents[5].following[i]);
        }
        for (int i = 0; i < tweets.Count; i++)
        {
            Debug.Log(tweets[i].religion +" "+ tweets[i].text + " " + tweets[i].likes);
        } */
    }
    void round() {

        for (int i = 0; i < 10; i++)
        {
            agents[i].MakeTweet(ref tweets);
        }

        for (int i = 0; i < 10; i++)
        {
            agents[i].ReadNewsFeed(agents, ref tweets);
        }

        for (int i = 0; i < tweets.Count; i++)
        {
            Debug.Log(tweets[i].religion + " " + tweets[i].text + " " + tweets[i].likes);
        }
    }

    IEnumerator LinearTime()
    {
        int hour = 8;
        while (true)
        {
            hour %= 24;
            Debug.Log(hour + ":00");
            round();
            yield return new WaitForSeconds(1.0f);
            hour++;
        }
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
