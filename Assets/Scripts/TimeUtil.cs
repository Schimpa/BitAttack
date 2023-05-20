using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUtil {

    public static string secondsToMinuteString(int seconds) {

        int minutes = 0;
        while(seconds >= 60) {
            minutes++;
            seconds -= 60;
        }

        return minutes.ToString()+":"+seconds.ToString();
    }

}
