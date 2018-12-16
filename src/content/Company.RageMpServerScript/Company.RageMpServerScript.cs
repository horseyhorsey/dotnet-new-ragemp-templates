using GTANetworkAPI;

public class Company.RageMpServerScript : Script
{
#if (scriptType == "gamemode")
    public static int MySettings;

    [ServerEvent(Event.ResourceStart)]
    public void OnResourceStart()
    {
        MySettings = NAPI.Resource.GetSetting<int>(this, "my_settings");
    }
#endif

    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnected(Client player)
    {
        NAPI.Notification.SendNotificationToAll("~b~~h~" + player.Name + "~h~ ~w~joined.");
        NAPI.Chat.SendChatMessageToAll("~b~" + player.Name + "~w~ has joined the server.");
    }

    [ServerEvent(Event.PlayerDisconnected)]
    public void OnPlayerDisconnected(Client player, DisconnectionType type, string reason)
    {
        NAPI.Notification.SendNotificationToAll("~b~~h~" + player.Name + "~h~ ~w~quit.");
        switch (type)
        {
            case DisconnectionType.Left:
                NAPI.Chat.SendChatMessageToAll("~b~" + player.Name + "~w~ has quit the server.");
                break;

            case DisconnectionType.Timeout:
                NAPI.Chat.SendChatMessageToAll("~b~" + player.Name + "~w~ has timed out.");
                break;

            case DisconnectionType.Kicked:
                NAPI.Chat.SendChatMessageToAll("~b~" + player.Name + "~w~ has been kicked for " + reason);
                break;
        }
    }
}
