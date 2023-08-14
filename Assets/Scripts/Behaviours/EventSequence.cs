using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Program a sequence of events from the inspector 
public class EventSequence : MonoBehaviour {

    [Header("All event that shall be triggered")]
    public List<UnityEvent> events;

    [Header("Timings for each event to trigger")]
    public List<float> eventTriggerTimes;

    public bool startSequenceOnGameStart;

    private int eventCount;
    private int currentEvent;
    private bool isSequenceActive;
    private float sequenceTimer;

    void Start() {
        if (startSequenceOnGameStart) {
            isSequenceActive = true;
        } else {
            isSequenceActive = false;
        }

        resetValues();
    }

    private void resetValues() {
        eventCount = events.Count;
        currentEvent = 0;
        sequenceTimer = 0f;
    }

    // Update is called once per frame
    void Update() { if (isSequenceActive == false) return;
        sequenceTimer += Time.deltaTime;

        if (sequenceTimer >= eventTriggerTimes[currentEvent]) {
            events[currentEvent].Invoke();
            currentEvent += 1;

            if (currentEvent >= eventCount) {
                isSequenceActive = false;
            }
        }

    }
}
