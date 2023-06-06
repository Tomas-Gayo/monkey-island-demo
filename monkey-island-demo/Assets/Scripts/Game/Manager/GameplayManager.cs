using UnityEngine;

public class GameplayManager : StateMachine
{
    [SerializeField] private GameScreen ui;
    [SerializeField] private GameObject optionsPrefab;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private Transform playerInterface;
    [SerializeField] private Transform dialogueInterface;

    public  bool isTurn;

    public int playerHealth = 3;
    public int enemyHealth = 3;

    public JSONReader jsonReader;
    public PlayerController player;
    public EnemyController enemy;

    public GameScreen Interface => ui;
    public GameObject OptionsPrefab => optionsPrefab;
    public GameObject ContinueButton => continueButton;
    public Transform PlayerInterface => playerInterface;
    public Transform DialogueInterface => dialogueInterface;

    // The game ("Game" screen) starts deciding who begins the game randomnly
    // Then, the state machine is set to the "Begin" state 
    void Start()
    {
        isTurn = randomBool();

        SetState(new Begin(this));
    }

    // Return a random booloean randomly (true or false)
    private bool randomBool()
    {
        return (Random.value > 0.5f);
    }
}
