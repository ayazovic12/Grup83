using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour {
    public delegate void TrackCheckpointEvent(object sender, CarCheckpointEventArgs e);
    public event TrackCheckpointEvent OnCarCorrectCheckpoint;
    public event TrackCheckpointEvent OnCarWrongChekpoint;
    public class CarCheckpointEventArgs {
        public Transform carTransform;
    }

    public List<Transform> carTransformList;

    List<Checkpoint> checkpointList;
    List<int> nextCheckpointIndexList;

    private void Awake() {
        checkpointList = new List<Checkpoint>();

        Transform checkpointsTransform = transform.Find("Checkpoints");

        foreach (Transform checkpointTransform in checkpointsTransform) {
            Checkpoint checkpoint = checkpointTransform.GetComponent<Checkpoint>();
            checkpoint.SetTrackCheckpoints(this);
            checkpointList.Add(checkpoint);
        }

        nextCheckpointIndexList = new List<int>();
        foreach (Transform carTransform in carTransformList) {
            nextCheckpointIndexList.Add(0);
        }
    }

    public void ResetCheckpoint(Transform carTransform) {
        int checkpointIndex = carTransformList.IndexOf(carTransform);
        nextCheckpointIndexList[checkpointIndex] = 0;
    }

    public Checkpoint GetNextCheckpoint(Transform carTransform) {
        int carTransformIndex = carTransformList.IndexOf(carTransform);
        int carTransformNextChecpointIndex = nextCheckpointIndexList[carTransformIndex];
        Checkpoint nextCheckpoint = checkpointList[carTransformNextChecpointIndex];
        return nextCheckpoint;
    }

    public void CarThroughCheckpoint(Checkpoint checkpoint, Transform carTransform) {
        int nextCheckpointIndex = nextCheckpointIndexList[carTransformList.IndexOf(carTransform)];
        if (nextCheckpointIndex == checkpointList.IndexOf(checkpoint)) {
            // correct checkpoint
            nextCheckpointIndexList[carTransformList.IndexOf(carTransform)] = (nextCheckpointIndex + 1) % checkpointList.Count;
            OnCarCorrectCheckpoint?.Invoke(this, new CarCheckpointEventArgs { carTransform = carTransform });
        }
        else {
            OnCarWrongChekpoint?.Invoke(this, new CarCheckpointEventArgs { carTransform = carTransform });
        }
    }
}
