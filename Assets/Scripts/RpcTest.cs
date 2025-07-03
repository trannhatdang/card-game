using Unity.Netcode;
using UnityEngine;

public class RpcTest : NetworkBehaviour
{

	public override void OnNetworkSpawn()
	{
		if(!IsServer && IsOwner)
		{
			ServerOnlyRpc(0, NetworkObjectId);
		}
	}

	[Rpc(SendTo.ClientsAndHost)]
	private void ClientAndHostRpc(int value, ulong sourceNetworkObjectId)
	{
		Debug.Log($"Client Received the RPC #{value} on NetworkObject #{sourceNetworkObjectId}");
		if(IsOwner)
		{
			ServerOnlyRpc(value + 1, sourceNetworkObjectId);
		}
	}

	[Rpc(SendTo.Server)]
	private void ServerOnlyRpc(int value, ulong sourceNetworkObjectId)
	{
		Debug.Log($"Server Received the RPC #{value} on NetworkObject #{sourceNetworkObjectId}");
		ClientAndHostRpc(value, sourceNetworkObjectId);
	}
}

