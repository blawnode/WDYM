using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Main;
    public PlayerMovement _playerMovement;
    private Transform _player;
    [SerializeField] public GameObject _deathParticle;
    [SerializeField] public Animator _hpGUI;
    [SerializeField] public const float PUNCH_POWER = 175;
    public int killCount;
    [SerializeField] public int _killCountTarget = 2;
    [SerializeField] public Collider2D _exitCollider;
    [SerializeField] public TextMeshProUGUI _victoryText;
    [SerializeField] public TextMeshProUGUI _dogetteText;

    private void Start()
    {
        Main = this;
        _player = _playerMovement.transform;
    }

    public void ShowHPGui()
    {
        _hpGUI.Play("HPGUI");
    }

    public void LoadScene(string sceneName)
    {

    }

    public void TeleportTo(Transform target)
    {
        _player.position = target.position;
    }

    public void StartCameraFollow()
    {
        Camera camera = Camera.main;
        camera.transform.SetParent(_player);
        camera.transform.position = _player.position + new Vector3(0, 0, -10);
    }

    public void UnleashTheManiac()
    {
        _exitCollider.enabled = true;
        _dogetteText.gameObject.SetActive(false);
    }

    public void UnitWasKilled()
    {
        killCount++;
        if(killCount >= _killCountTarget)
        {
            gg();
        }
    }

    private void gg()
    {
        print("GG!!!!!");
        MusicManager.Main.PlayMusic(MusicManager.Music.Victory);
        Camera.main.orthographicSize = 2.5f;
        _victoryText.gameObject.SetActive(true);
    }
}
