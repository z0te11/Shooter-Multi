using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerChatBubble : MonoBehaviourPun
{
    public GameObject chatBubblePrefab;
    public Transform messagePosition;
    public string[] predefinedMessages;
    
    private GameObject currentBubble;

    void Update()
    {
        if (photonView.IsMine && Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            SendPredefinedMessage(0);
        }
        if (photonView.IsMine && Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            SendPredefinedMessage(1);
        }
        if (photonView.IsMine && Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            SendPredefinedMessage(2);
        }
        if (photonView.IsMine && Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            SendPredefinedMessage(3);
        }
    }
    
    public void SendPredefinedMessage(int messageIndex)
    {
        if (messageIndex >= 0 && messageIndex < predefinedMessages.Length)
        {
            photonView.RPC("ShowMessage", RpcTarget.All, predefinedMessages[messageIndex]);
        }
    }
    
    [PunRPC]
    void ShowMessage(string message, PhotonMessageInfo info)
    {
        if (currentBubble != null)
        {
            Destroy(currentBubble);
        }
        
        currentBubble = Instantiate(chatBubblePrefab, messagePosition.position, Quaternion.identity, transform);
        currentBubble.GetComponentInChildren<Text>().text = message;
        
        Destroy(currentBubble, 3f);
    }
}
