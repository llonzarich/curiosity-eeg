using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;

namespace LSL4Unity.Samples.SimplePhysicsEvent
{
    public class SimpleOutletTriggerEvent : MonoBehaviour
    {
        /*
         * This is a simple example of an LSL Outlet to stream out irregular events occurring in Unity.
         * This uses only LSL.cs and is intentionally simple. For a more robust version, see another sample.
         * 
         * We stream out the trigger event during OnTriggerEnter which is, in our opinion, the closest
         * time to when the trigger actually occurs (i.e., independent of its rendering).
         * A simple way to print the events is with pylsl: `python -m pylsl.examples.ReceiveStringMarkers`
         *
         * If you are instead trying to log a stimulus event then there are better options. Please see the 
         * LSL4Unity SimpleStimulusEvent Sample for such a design.
         */
        string StreamName = "LSL4Unity.Samples.SimpleCollisionEvent"; // name of stream. 
        string StreamType = "Markers"; // type of stream.
        private StreamOutlet outlet; // outlet is what we use to send data samples.
        private string[] sample = {""}; // an array of strings that store the data samples that are sent through the outlet. 

        void Start()
        {
            var hash = new Hash128(); // hash object is created.
            hash.Append(StreamName); // populating hash with the stream name. 
            hash.Append(StreamType); // populating hash with the stream type. 
            hash.Append(gameObject.GetInstanceID()); // populating hash with the ID of the game object to ensure unique identification of the stream. 
            StreamInfo streamInfo = new StreamInfo(StreamName, StreamType, 1, LSL.LSL.IRREGULAR_RATE,
                channel_format_t.cf_string, hash.ToString());
            outlet = new StreamOutlet(streamInfo); // creating an outlet that will push data samples to the LSL stream. 
        }

        private void OnTriggerEnter(Collider other)
        {
            if (outlet != null) // check
            {
                sample[0] = "TriggerEnter " + gameObject.GetInstanceID(); // updates the array, 'sample' with a message to indicate whether its a trigger enter or exit. This depends on the instance ID of game object. 
                // Debug.Log(sample[0]);
                outlet.push_sample(sample); // send the updated sample data to the LSL stream. 
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (outlet != null)
            {
                sample[0] = "TriggerExit " + gameObject.GetInstanceID();
                // Debug.Log(sample[0]);
                outlet.push_sample(sample);
            }
        }
    }
}