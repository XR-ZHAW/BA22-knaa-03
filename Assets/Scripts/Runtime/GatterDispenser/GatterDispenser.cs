using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GatterDispenser : MonoBehaviour
{
    [SerializeField] private TMP_Text gatterDisplay;
    public TMP_Text GatterDisplay => gatterDisplay;

    [SerializeField] private Transform refrencePoint;

    [SerializeField] private List<GameObject> gatterList;

    private List<AbstractGatter> gatterListRefined;

    private int currentIndex = 0;

    private void showGatterName(AbstractGatter currentGatter)
    {
        gatterDisplay.text = currentGatter.LabelText;
    }

    private void Awake()
    {
        gatterListRefined = gatterList
            .Select(g => g.GetComponentInChildren<AbstractGatter>())
            .Where(g => g != null)
            .ToList();
        
    }

    private void Start()
    {
        if (gatterListRefined.Count == 0)
            return;
        
        updateLabel();
    }

    private void updateLabel()
    {
        showGatterName(GetCurentGatter());
    }

    private AbstractGatter GetCurentGatter()
    {
        return gatterListRefined[currentIndex];
    }

    public void NextGatter()
    {
        if(gatterListRefined.Count is 0 or 1)
            return;

        currentIndex++;
        if (currentIndex > gatterListRefined.Count -1)
            currentIndex = 0;
        updateLabel();
    }

    public void PreviousGatter()
    {
        if(gatterListRefined.Count is 0 or 1)
            return;

        currentIndex--;
        if (currentIndex < 0)
            currentIndex = gatterListRefined.Count - 1;
        updateLabel();
    }

    public void DispenseGatter()
    {
        var currentGatter = gatterList[currentIndex];
        Instantiate(currentGatter, refrencePoint.position, refrencePoint.rotation);
    }
}
