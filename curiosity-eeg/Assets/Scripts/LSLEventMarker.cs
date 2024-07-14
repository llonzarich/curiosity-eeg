/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;

public class LSLEventMarker : MonoBehaviour {

    private const string StreamName = "UnityEventMarker";
    string StreamType = "Markers";
    private StreamOutlet outlet;
    private float[] arr; or print string[] sample = {""}; 


    // Start is called before the first frame update
    void Start() {
        StreamInfo streamInfo = new StreamInfo(StreamName, "Markers", 4, 0, 'cf_string');
        arr = new float[1]; 
    }


    public void SendMarkers(float marker) {
        arr[0] = marker;
        outlet.push_sample(arr);
        Debug.Log("Sent Marker: " + marker); 
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
*/
