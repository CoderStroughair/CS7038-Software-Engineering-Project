using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tweet {
    public int posterId;
    public string text;
    public int likes;

    public List<string> hashtags;
    public List<int> _at;

    public eClass socialClass;
    public eReligion religion;


    public Tweet(int _posterId,string _text,eClass _socialClass,eReligion _religion)
    {
        posterId = _posterId;
        text = _text;
        socialClass = _socialClass;
        religion = _religion;
    }

    public void LikeTweet()
    {
        likes++;
    }

}
