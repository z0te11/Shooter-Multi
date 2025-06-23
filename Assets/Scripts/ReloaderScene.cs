using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PhotonView))]
public class ReloaderScene : MonoBehaviourPunCallbacks
{
    [Header("Настройки")]

    [Tooltip("Автоматически перезагружать при подключении всех игроков")]
    public bool autoReloadOnJoin = false;

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        if (autoReloadOnJoin && PhotonNetwork.IsMasterClient)
        {
            ReloadScene();
        }
    }

    public void ReloadScene()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogWarning("Только мастер-клиент может перезагрузить сцену!");
            return;
        }

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log($"Мастер-клиент запускает перезагрузку сцены #{currentSceneIndex}");

        // Вариант 1: Через Photon (требует AutoSyncScene)
        PhotonNetwork.LoadLevel(currentSceneIndex);

        // Вариант 2: Через RPC (работает без AutoSyncScene)
        //photonView.RPC("RPC_ReloadScene", RpcTarget.All, currentSceneIndex);
    }

    [PunRPC]
    private void RPC_ReloadScene(int sceneIndex)
    {
        Debug.Log($"Получен RPC для загрузки сцены #{sceneIndex}");
        SceneManager.LoadScene(sceneIndex);
    }
}
