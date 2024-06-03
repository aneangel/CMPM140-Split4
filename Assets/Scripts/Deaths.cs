using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Deaths : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI deathsText;
    private int deathCount;
    // Update is called once per frame
    void Update()
    {
        deathCount = RespawnManager.instance.getPlayerDeathCount();
        deathsText.text = string.Format("Deaths: {0}", deathCount);
    }
}
