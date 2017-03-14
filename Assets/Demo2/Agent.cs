using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class Agent {

    public int[] personality;
    public int[] following;
    public string name;
    public int[] tweetsMade;
    public int[] tweetsRead;

    public Identity identity;

    public static Agent CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Agent>(jsonString);
    }

    public void setEnums()
    {
        identity.setEnums();
    }

    public void prepEnumStrings()
    {
        identity.prepEnumStrings();
    }

    int id;

    private FSM<Agent> stateMachine;

    public List<int> followingList;

    List<int> tweetMade;
    List<int> readTweets;
    //fixed
    int age;
    eGender gender;

    //variables

    public Agent(int _id)
    {
        id = _id;

        /*
        Waiting for Sarah randomize identity values
        */


        personality = new int[5];
        for (int i = 0; i < 5; i++)
            personality[i] = i;

        identity = new Identity();

        identity.g = eGender.FEMALE;

        if(identity.g == eGender.MALE) {
            //read a csv files and randomize from the files
            name = "Max";
        }
        else{
            name = "Maxiee";
        }
            
        identity.r = eReligion.JEWISH;
        identity.p = ePolitics.LIBERAL;
        identity.n = eNationality.INDIAN;
        identity.pref_religion = new float[1];
        for (int i = 0; i < 1; i++)
            identity.pref_religion[i] = i;
        identity.pref_ethnicity = new float[1];
        for (int i = 0; i < 1; i++)
            identity.pref_ethnicity[i] = i;
        identity.pref_gender = new float[2];
        for (int i = 0; i < 2; i++)
            identity.pref_gender[i] = i;
        identity.pref_class = new float[3];
        for (int i = 0; i < 3; i++)
            identity.pref_class[i] = i;
        identity.pref_nationality = new float[1];
        for (int i = 0; i < 1; i++)
            identity.pref_nationality[i] = i;
        identity.pref_political = new float[1];
        for (int i = 0; i < 1; i++)
            identity.pref_political[i] = i;
        
        followingList = new List<int>();
        tweetMade = new List<int>();
        readTweets= new List<int>();
    }

    public void ChangeState(State<Agent> state)
    {
        this.stateMachine.ChangeState(state);
    }

    public void Update(List<Agent> agents,ref List<Tweet> tweets)
    {
        MakeTweet(ref tweets);
        ReadNewsFeed(agents, ref tweets);
    }

    public void MakeTweet(ref List<Tweet> tweets)
    {
        Tweet tweet = new Tweet(id,"im a unicorn", identity.c, identity.r);
        tweets.Add(tweet);
        tweetMade.Add(tweets.Count-1);//id of tweet
    }


    public void ReadNewsFeed(List<Agent> agents,ref List<Tweet> tweets)
    {
        //get from database index following
        for(int i=0;i<followingList.Count;i++)
        {
            Agent a = agents[followingList[i]];
            for(int j=0;j<a.tweetMade.Count;j++)
            {

                int t = a.tweetMade[j];
                bool isFound=false;
                for (int k = 0; k < readTweets.Count; k++)
                {
                    if (readTweets[k] == t) {
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                    continue;

                if (tweets[t].religion == identity.r)
                    tweets[t].LikeTweet();
                
                readTweets.Add(t);

            }
            
        }
    }
}

[Serializable]
public class Identity
{
    public float[] pref_religion;
    public float[] pref_ethnicity;
    public float[] pref_gender;
    public float[] pref_class;
    public float[] pref_nationality;
    public float[] pref_political;
    public string gender;
    public string religion;
    public string politics;
    public string nationality;
    public eClass c;
    public eGender g;
    public eReligion r;
    public ePolitics p;
    public eNationality n;

    public void setEnums()
    {
        g = (eGender)System.Enum.Parse(typeof(eGender), gender);
        r = (eReligion)System.Enum.Parse(typeof(eReligion), religion);
        p = (ePolitics)System.Enum.Parse(typeof(ePolitics), politics);
        n = (eNationality)System.Enum.Parse(typeof(eNationality), nationality);
    }

    public void prepEnumStrings()
    {
        gender = g.ToString();
        religion = r.ToString();
        politics = p.ToString();
        nationality = n.ToString();
    }
}
