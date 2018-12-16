using System;

using RAGE;
using RAGE.Elements;

public class MyFirstScript : Events.Script
{
    public MyFirstScript()
    {
        RAGE.Chat.Output("Loaded MyFirstScript Script");
        RAGE.Events.OnPlayerCommand += OnPlayerCommand;  
    }

    public void OnPlayerCommand(string cmd, RAGE.Events.CancelEventArgs cancel)
    {
        Chat.Output($"OnPlayerCommand: {cmd}");
        if (cmd == "heal")
        {
            Chat.Output($"Healing");
            RAGE.Elements.Player.LocalPlayer.SetHealth(200);
            Chat.Output($"PlayerHealth: {Player.LocalPlayer.GetHealth()}");
        }
        else if (cmd == "armour")
        {
            Chat.Output($"Armour");
            RAGE.Elements.Player.LocalPlayer.SetArmour(100);
        }

	//Use this to cancel server call for this command??
        cancel.Cancel = true;
    }
}