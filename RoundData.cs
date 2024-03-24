using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class RoundData
{
    public string name;
    public int timeLimitInSeconds;
    public int pointsAddedForcorrectAnswer;
    public QuestionData[] questions;
}
