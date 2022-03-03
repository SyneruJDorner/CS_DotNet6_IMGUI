using System;
using System.Numerics;
using System.Collections.Generic;
using ImGuiNET;

public static class GuiLayouts
{
    private static bool _showAnotherWindow = false;
    private static uint s_tab_bar_flags = (uint)ImGuiTabBarFlags.Reorderable;
    static bool[] s_opened = { true, true, true, true }; // Persistent user state

    public static void Render()
    {
        //Create a menu bar with IMGUI
        ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 0.75f);
        //ImGui.SetNextWindowSize(new Vector2(250, 250));
        //ImGui.SetNextWindowPos(new Vector2(100, 100));
        //ImGui.Begin("Test", ImGuiWindowFlags.NoDecoration | ImGuiWindowFlags.ChildMenu);
        CreateMainMenu();
        //ImGui.PopStyleVar();
        
        ImGui.BeginDragDropTarget();

        if (GuiController._debug == true)
        {
            //ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 0.2f);

            ImGui.Text("Hello, world!");
            ImGui.Text($"Mouse position: {ImGui.GetMousePos()}");
            if (ImGui.Button("Button"))
            {
                ImGui.Text("Button clicked");
            }
            float framerate = ImGui.GetIO().Framerate;
            ImGui.Text($"Application average {1000.0f / framerate:0.##} ms/frame ({framerate:0.#} FPS)");
            ImGui.Checkbox("Another Window", ref _showAnotherWindow);
            //ImGui.PopStyleVar();

            // 2. Show another simple window. In most cases you will use an explicit Begin/End pair to name your windows.
            if (_showAnotherWindow)
            {
                ImGui.Begin("Another Window", ref _showAnotherWindow, ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize);
                ImGui.Text("Hello from another window!");
                if (ImGui.Button("Close Me"))
                    _showAnotherWindow = false;
                ImGui.End();
            }

            if (ImGui.TreeNode("Tabs"))
            {
                if (ImGui.TreeNode("Basic"))
                {
                    ImGuiTabBarFlags tab_bar_flags = ImGuiTabBarFlags.None;
                    if (ImGui.BeginTabBar("MyTabBar", tab_bar_flags))
                    {
                        if (ImGui.BeginTabItem("Avocado"))
                        {
                            ImGui.Text("This is the Avocado tab!\nblah blah blah blah blah");
                            ImGui.EndTabItem();
                        }
                        if (ImGui.BeginTabItem("Broccoli"))
                        {
                            ImGui.Text("This is the Broccoli tab!\nblah blah blah blah blah");
                            ImGui.EndTabItem();
                        }
                        if (ImGui.BeginTabItem("Cucumber"))
                        {
                            ImGui.Text("This is the Cucumber tab!\nblah blah blah blah blah");
                            ImGui.EndTabItem();
                        }
                        ImGui.EndTabBar();
                    }
                    ImGui.Separator();
                    ImGui.TreePop();
                }

                if (ImGui.TreeNode("Advanced & Close Button"))
                {
                    // Expose a couple of the available flags. In most cases you may just call BeginTabBar() with no flags (0).
                    ImGui.CheckboxFlags("ImGuiTabBarFlags_Reorderable", ref s_tab_bar_flags, (uint)ImGuiTabBarFlags.Reorderable);
                    ImGui.CheckboxFlags("ImGuiTabBarFlags_AutoSelectNewTabs", ref s_tab_bar_flags, (uint)ImGuiTabBarFlags.AutoSelectNewTabs);
                    ImGui.CheckboxFlags("ImGuiTabBarFlags_NoCloseWithMiddleMouseButton", ref s_tab_bar_flags, (uint)ImGuiTabBarFlags.NoCloseWithMiddleMouseButton);
                    if ((s_tab_bar_flags & (uint)ImGuiTabBarFlags.FittingPolicyMask) == 0)
                        s_tab_bar_flags |= (uint)ImGuiTabBarFlags.FittingPolicyDefault;
                    if (ImGui.CheckboxFlags("ImGuiTabBarFlags_FittingPolicyResizeDown", ref s_tab_bar_flags, (uint)ImGuiTabBarFlags.FittingPolicyResizeDown))
                s_tab_bar_flags &= ~((uint)ImGuiTabBarFlags.FittingPolicyMask ^ (uint)ImGuiTabBarFlags.FittingPolicyResizeDown);
                    if (ImGui.CheckboxFlags("ImGuiTabBarFlags_FittingPolicyScroll", ref s_tab_bar_flags, (uint)ImGuiTabBarFlags.FittingPolicyScroll))
                s_tab_bar_flags &= ~((uint)ImGuiTabBarFlags.FittingPolicyMask ^ (uint)ImGuiTabBarFlags.FittingPolicyScroll);

                    // Tab Bar
                    string[] names = { "Artichoke", "Beetroot", "Celery", "Daikon" };

                    for (int n = 0; n < s_opened.Length; n++)
                    {
                        if (n > 0) { ImGui.SameLine(); }
                        ImGui.Checkbox(names[n], ref s_opened[n]);
                    }

                    // Passing a bool* to BeginTabItem() is similar to passing one to Begin(): the underlying bool will be set to false when the tab is closed.
                    if (ImGui.BeginTabBar("MyTabBar", (ImGuiTabBarFlags)s_tab_bar_flags))
                    {
                        for (int n = 0; n < s_opened.Length; n++)
                            if (s_opened[n] && ImGui.BeginTabItem(names[n], ref s_opened[n]))
                            {
                                ImGui.Text($"This is the {names[n]} tab!");
                                if ((n & 1) != 0)
                                    ImGui.Text("I am an odd tab.");
                                ImGui.EndTabItem();
                            }
                        ImGui.EndTabBar();
                    }
                    ImGui.Separator();
                    ImGui.TreePop();
                }
                ImGui.TreePop();
            }

            ImGuiIOPtr io = ImGui.GetIO();
            ImGui.Text("\n" + "Frame time = " + io.DeltaTime.ToString());
            ImGui.Text(ImGui.GetKeyIndex(ImGuiKey.Tab).ToString());
            ImGui.Text(io.MousePos.X.ToString());
            ImGui.Text(io.MousePos.Y.ToString());
            ImGui.Text(io.KeysDown.ToString());

            if (ImGui.ArrowButton("##test", ImGuiDir.Down))
            {
                ImGui.Text("ArrowButton");
            }

            if (ImGui.IsKeyDown(ImGuiKey.Tab))
            {
                ImGui.Text("Tab is down");
            }

            if (ImGui.IsMouseDown(0))
            {
                ImGui.Text("Mouse 0 is down");
            }

            if (ImGui.IsKeyPressed(ImGuiKey.Tab))
            {
                ImGui.Text("Tab is pressed");
            }

            if (ImGui.IsKeyReleased(ImGuiKey.Tab))
            {
                ImGui.Text("Tab is released");
            }
            // foreach (var activeText in _activeTexts)
            // {
                // ImGui.SetNextWindowSize(new Vector2(100, 100));
                // ImGui.SetNextWindowPos(new Vector2(100, 100));
                // ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 0.2f);
                // var name = "Test";//activeText.GetHashCode().ToString();
                // ImGui.Begin(name, ImGuiWindowFlags.NoDecoration | ImGuiWindowFlags.NoMove);
                // ImGui.PopStyleVar();
            
                // ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 1.0f);
                // ImGui.BeginChild(name + "text");
                // ImGui.Text(name);
                // ImGui.EndChild();
                // ImGui.PopStyleVar();
            
                // ImGui.End();
            // }

        }
    }

    public static void CreateMainMenu()
    {
        var menu = new Dictionary<string, Dictionary<string[], Action[]>>();
        var submenu = new Dictionary<string[], Action[]>();

        //Create menus here and actions per menu item
        submenu.Add(new string[]
        {
            "New",
            "Options",
            "Quit"
        },
        new Action[]
        {
            () => {
                Console.WriteLine("New Menu Clicked");
            },
            () => {
                Console.WriteLine("Option Menu Clicked");
            },
            () => {
                GuiController._window?.Close();
            }
        });

        menu.Add("File", submenu);

        MainMenuConstructor(menu);
    }

    //A function that creates Main Menu Bar and submenus in IMGUI
    private static void MainMenuConstructor(Dictionary<string, Dictionary<string[], Action[]>> menuOptions)
    {            
        if (ImGui.BeginMainMenuBar())
        {
            foreach(var menuOption in menuOptions)
            {
                string menu = menuOption.Key.ToString();
                var submenuOptionsDict = menuOption.Value;
                
                if (ImGui.BeginMenu(menu))
                {
                    foreach(var submenuOptions in submenuOptionsDict)
                    {
                        string submenus;
                        for (int i = 0; i < submenuOptions.Key.Length; i++)
                        {
                            submenus = submenuOptions.Key[i].ToString();
                            
                            //Create a clickable submenu
                            //If clicked, execute the matching function for this submenu
                            if (ImGui.MenuItem(submenus))
                                submenuOptions.Value[i]();
                        }
                    }
                    ImGui.EndMenu();
                }
            }
            ImGui.EndMainMenuBar();
        }
    }
}