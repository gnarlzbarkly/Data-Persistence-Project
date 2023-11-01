using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Scores;
using UnityEngine.UI;
using TMPro;

public class HighScoreUIHandler : MonoBehaviour
{
    public TMP_Text HighScoresText;
    // Start is called before the first frame update
    void Start()
    {
        DisplayScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<HighScore> SortScores()
    {
        return ScoresManager.Instance.HighScores.OrderByDescending(s => s.Score).ToList();
    }

    public void DisplayScores()
    {
        int i = 0;
        foreach(HighScore hs in SortScores())
        {
            if(i < 10)
            {
                Debug.Log(i);
                HighScoresText.text = HighScoresText.text + $"{++i}) {hs.Name} {hs.Score}\n";
            }
        }
    }
}
