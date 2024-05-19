using UnityEngine;

public class Checkpoint : MonoBehaviour {
    TrackCheckpoints trackCheckpoints;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponentInParent<PrometeoCarController>()) {
            trackCheckpoints.CarThroughCheckpoint(this, other.gameObject.GetComponentInParent<PrometeoCarController>().transform);
        }
    }

    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints) {
        this.trackCheckpoints = trackCheckpoints;
    }
}
