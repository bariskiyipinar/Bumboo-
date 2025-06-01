using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnockDownBar : MonoBehaviour
{
    public Slider barSlider;

    public void UpdateBar(int current,int max)
    {
        if (barSlider != null)
        {
            barSlider.value = (float)current /max;
        }
    }
}
