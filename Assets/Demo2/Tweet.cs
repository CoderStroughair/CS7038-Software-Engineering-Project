using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tweet {
    public int posterId;
    public string text;
    public int likes;

    public List<string> hashtags;
    public List<int> _at;

    /*public eClass socialClass;
    public eReligion religion;
    */
    public Identity identity;

    public Tweet(int _posterId,string _text,Identity _identity)
    {
        posterId = _posterId;
        text = _text;
        identity = _identity;
    }

    public void LikeTweet()
    {
        likes++;
    }

}
