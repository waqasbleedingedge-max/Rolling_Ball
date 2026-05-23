using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

public class DailyRewardManager : MonoBehaviour
{

    public DateTime now;
    public DateTime lastRewardTime;
    public TimeSpan debugTime;
    private const string FMT = "O";

    public Text remainingTime;
         

    // Start is called before the first frame update
    void Start()
    {
        debugTime = debugTime.Add(new TimeSpan(0, 0, 0, 0));
        now = DateTime.Now;
        Debug.Log("Time Now= " + now);
        string lastClaimedStr = now.AddHours(debugTime.TotalHours).ToString(FMT);
        Debug.Log("Time = " + lastClaimedStr);
        string lastClaimedTimeStr = PlayerPrefs.GetString("LastRewardTime");

        Debug.Log("Last claimed =" + lastClaimedTimeStr);
        lastRewardTime = DateTime.ParseExact(lastClaimedTimeStr, FMT, CultureInfo.InvariantCulture);
      //  Debug.Log("Last Claimed Parse = " + lastRewardTime);
     
       // Debug.Log("Difference =" + GetTimeDifference());
        //string formattedTs = GetFormattedTime(difference);

       // remainingTime.text = string.Format("Come back in {0} for your next reward", formattedTs);
    }

    public TimeSpan GetTimeDifference()
    {
        TimeSpan difference = (lastRewardTime - now);
        difference = difference.Subtract(debugTime);
        return difference.Add(new TimeSpan(0, 4, 0, 0));
    }
    public string GetFormattedTime(TimeSpan span)
    {
        return string.Format("{0:D2}:{1:D2}:{2:D2}", span.Hours, span.Minutes, span.Seconds);
    }

    private void Update()
    {
        now = now.AddSeconds(Time.unscaledDeltaTime);
        UpdateTimer();
    }


    public void UpdateTimer()
    {
        TimeSpan difference = GetTimeDifference();
        string formattedTs = GetFormattedTime(difference);

        remainingTime.text = string.Format("Come back in {0} for your next reward", formattedTs);
    }


}
