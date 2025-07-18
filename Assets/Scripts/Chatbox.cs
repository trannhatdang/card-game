using UnityEngine;
using Unity.Netcode;
using TMPro;

public class Chatbox : NetworkBehaviour
{
	public static Chatbox Instance;
	[SerializeField] TMP_Text _chat;
	[SerializeField] TMP_InputField _input;
	[SerializeField] bool _inChat = false;
	public bool InChat
	{
		get {return _inChat;}
		private set {value = _inChat;}
	}
	void Awake()
	{
		if(Instance && Instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	[Rpc(SendTo.Server)]
	public void SendChatRpc(string name, string content)
	{
		_chat.text += "\n" + name + ": " + content;
	}


	public void OpenChat()
	{
		_inChat = true;
	}

	public void CloseChat(string input)
	{
		_input.text = "";
		_inChat = false;
		SendChatRpc("deng", input);
	}

}
