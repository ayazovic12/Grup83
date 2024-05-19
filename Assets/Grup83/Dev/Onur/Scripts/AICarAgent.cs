using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class AICarAgent : Agent {
    public TrackCheckpoints trackCheckpoints;

    Vector3 spawnLocation;
    Vector3 spawnForward;

    PrometeoCarController carController;

    void Awake() {
        carController = GetComponent<PrometeoCarController>();
    }

    void Start() {
        trackCheckpoints.OnCarCorrectCheckpoint += TrackCheckpoints_OnCarCorrectCheckpoint;
        trackCheckpoints.OnCarWrongChekpoint += TrackCheckpoints_OnCarWrongCheckpoint;
        carController.playerControlEnabled = false;
        spawnLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        spawnForward = new Vector3(transform.forward.x, transform.forward.y, transform.forward.z);
    }

    void TrackCheckpoints_OnCarCorrectCheckpoint(object sender, TrackCheckpoints.CarCheckpointEventArgs e) {
        if (e.carTransform == transform) {
            AddReward(1f);
        }
    }

    void TrackCheckpoints_OnCarWrongCheckpoint(object sender, TrackCheckpoints.CarCheckpointEventArgs e) {
        if (e.carTransform == transform) {
            AddReward(-1f);
        }
    }

    public override void OnEpisodeBegin() {
        transform.position = spawnLocation;
        transform.forward = spawnForward;
        trackCheckpoints.ResetCheckpoint(transform);
        carController.carSpeed = 0f;
    }

    public override void CollectObservations(VectorSensor sensor) {
        Vector3 checkpointForward = trackCheckpoints.GetNextCheckpoint(transform).transform.forward;
        float directionDot = Vector3.Dot(transform.forward, checkpointForward);
        sensor.AddObservation(directionDot);
    }

    public override void OnActionReceived(ActionBuffers actions) {
        float forwardAmount = 0f;
        float turnAmount = 0f;

        switch (actions.DiscreteActions[0]) {
            case 0:
                forwardAmount = 0f;
                break;
            case 1:
                forwardAmount = 1f;
                break;
            case 2:
                forwardAmount = -1f;
                break;
        }

        switch (actions.DiscreteActions[1]) {
            case 0:
                turnAmount = 0f;
                break;
            case 1:
                turnAmount = 1f;
                break;
            case 2:
                turnAmount = -1f;
                break;
        }

        carController.SetInputs(forwardAmount, turnAmount);
    }

    public override void Heuristic(in ActionBuffers actionsOut) {
        int forwardAction = 0;
        int turnAction = 0;

        if (Input.GetKey(KeyCode.UpArrow))
            forwardAction = 1;
        if (Input.GetKey(KeyCode.DownArrow))
            forwardAction = 2;

        if (Input.GetKey(KeyCode.RightArrow))
            turnAction = 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            turnAction = 2;

        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;
        discreteActions[0] = forwardAction;
        discreteActions[1] = turnAction;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            AddReward(-0.5f);
        }
    }

    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            AddReward(-0.1f);
        }
    }
}
