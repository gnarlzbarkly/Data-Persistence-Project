using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Scores
{
    [System.Serializable]
    public class HighScore
    {
        public string Name;
        public int Score;

        public HighScore(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }
    }
}
