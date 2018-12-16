using System;

#if (scriptType == "script")
using RAGE;
#elseif (scriptType == "nativeui")
using RAGE.NUI;
#endif

public class Company.RageMpClientScript : Events.Script
{
#if (scriptType == "script")
    public Company.RageMpClientScript()
    {
        RAGE.Chat.Output("Loaded Company.RageMpClientScript Script");
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
#elseif (scriptType == "events")
  public Company.RageMpClientScript()
  {
    // this kind of events receives mp.trigger, mp.events.callLocal, but also remote events
    RAGE.Events.AddEvent("remote_triggerable_event", SomeEvent);
    
    RAGE.Events.AddDataHandler("some_data", SomeDataHandler);
    
    RAGE.Events.Tick += Tick;
    RAGE.Events.OnPlayerChat += ChatHandler;
    
    // trigger a js event
    RAGE.Events.CallLocal("eventName", 1, "someString", 1.0f);
  }
  
  public void SomeEvent(object[] args)
  {
  }
  
  public void SomeDataHandler(RAGE.Elements.Entity entity, object value)
  {
  }
  
  public void ChatHandler(string text, RAGE.Events.CancelEventArgs cancel)
  {
    if(text == "cancelme")
    {
    	cancel.Cancel = true;
    }
  }
  
  // known as "render" in JS
  public void Tick(System.Collections.Generic.List<RAGE.Events.TickNametagData> nametags)
  {
  }
#elseif (scriptType == "nativeui")
    private bool ketchup = false;
    private string dish = "Banana";
    private MenuPool _menuPool;
    private UIMenu _mainMenu;

    public Company.RageMpClientScript()
    {
        _menuPool = new MenuPool();
        var mainMenu = new UIMenu("Native UI", "~b~NATIVEUI SHOWCASE");
      
      	// original NativeUI replicates GTA V "interaction menu", 
      	//changing FreezeAllInput to true makes the player completely frozen
      	// while the menu is active
        mainMenu.FreezeAllInput = true;
      
        _menuPool.Add(mainMenu);
        AddMenuKetchup(mainMenu);
        AddMenuFoods(mainMenu);
        AddMenuCook(mainMenu);
        AddMenuAnotherMenu(mainMenu);
        _menuPool.RefreshIndex();

        RAGE.Events.Tick += DrawMenu;

        mainMenu.Visible = true;
    }

    public static void Notify(string text)
    {
        RAGE.Game.Ui.SetNotificationTextEntry("STRING");
        RAGE.Game.Ui.AddTextComponentSubstringPlayerName(text);
        RAGE.Game.Ui.DrawNotification(false, false);
    }

    public void AddMenuKetchup(UIMenu menu)
    {        
        var newitem = new UIMenuCheckboxItem("Add ketchup?", ketchup, "Do you wish to add ketchup?");
        menu.AddItem(newitem);
        menu.OnCheckboxChange += (sender, item, checked_) =>
        {
            if (item == newitem)
            {
                ketchup = checked_;
                Notify("~r~Ketchup status: ~b~" + ketchup);
            }
        };
    }

    public void AddMenuFoods(UIMenu menu)
    {
        var foods = new List<dynamic>
        {
            "Banana",
            "Apple",
            "Pizza",
            "Quartilicious",
            0xF00D, // Dynamic!
        };
        var newitem = new UIMenuListItem("Food", foods, 0);
        menu.AddItem(newitem);
        menu.OnListChange += (sender, item, index) =>
        {
            if (item == newitem)
            {
                dish = item.IndexToItem(index).ToString();
                Notify("Preparing ~b~" + dish + "~w~...");
            }

        };
    }

    public void AddMenuCook(UIMenu menu)
    {
        var newitem = new UIMenuItem("Cook!", "Cook the dish with the appropiate ingredients and ketchup.");
        newitem.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
        newitem.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
        menu.AddItem(newitem);
        menu.OnItemSelect += (sender, item, index) =>
        {
            if (item == newitem)
            {
                string output = ketchup ? "You have ordered ~b~{0}~w~ ~r~with~w~ ketchup." : "You have ordered ~b~{0}~w~ ~r~without~w~ ketchup.";
                Notify(String.Format(output, dish));
            }
        };
        menu.OnIndexChange += (sender, index) =>
        {
            if (sender.MenuItems[index] == newitem)
                newitem.SetLeftBadge(UIMenuItem.BadgeStyle.None);
        };
    }

    public void AddMenuAnotherMenu(UIMenu menu)
    {
        var submenu = _menuPool.AddSubMenu(menu, "Another Menu");
        for (int i = 0; i < 20; i++)
            submenu.AddItem(new UIMenuItem("PageFiller", "Sample description that takes more than one line. Moreso, it takes way more than two lines since it's so long. Wow, check out this length!"));
    }

    public void DrawMenu(System.Collections.Generic.List<RAGE.Events.TickNametagData> nametags)
    {
        if (RAGE.Input.IsDown((int)ConsoleKey.M))
        {
            _mainMenu.Visible = !_mainMenu.Visible;
        }

        if (_mainMenu.Visible)
            _menuPool.ProcessMenus();
    }  
#endif
}