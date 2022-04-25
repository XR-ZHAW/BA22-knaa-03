﻿using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExerciseList",menuName = "BA22/Create list of exercises")]
public class ExerciseList : ScriptableObject
{ 
    [SerializeField] 
    private List<Exercise> exerciseList = new List<Exercise>();

    private int currentIndex = 0;
    public Exercise CurrentExercise => exerciseList.Count == 0 || currentIndex > exerciseList.Count - 1 ? null : exerciseList[currentIndex];

    public void Continue()
    {
        currentIndex++;
    }

    public int Count()
    {
        return exerciseList.Count;
    }
}
