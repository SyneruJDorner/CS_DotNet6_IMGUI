using System;
using System.Drawing;
using System.Numerics;
using System.Windows;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ImGuiNET;

public static class GuiLayouts
{
    //private static bool _showAnotherWindow = false;
    //private static uint s_tab_bar_flags = (uint)ImGuiTabBarFlags.Reorderable;
    //static bool[] s_opened = { true, true, true, true }; // Persistent user state
    public static void Render()
    {
        ImGui.Begin("Main Menu Window", ImGuiWindowFlags.NoBackground | ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoDecoration | ImGuiWindowFlags.AlwaysUseWindowPadding | ImGuiWindowFlags.NoDocking | ImGuiWindowFlags.NoBringToFrontOnFocus);
        ImGui.SetWindowPos(new Vector2(0, 0));
        ImGui.SetWindowSize(new Vector2(GuiController._window!.Width, GuiController._window!.Height));
        CreateMainMenu();
        ImGui.End();

        ImGui.Begin("Main Docking Zone", ImGuiWindowFlags.DockNodeHost | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoDecoration);
        ImGui.SetWindowPos(new Vector2(0.0f, 25.0f));
        ImGui.SetWindowSize(new Vector2(GuiController._window!.Width, GuiController._window!.Height));
        uint dockspaceID = ImGui.DockSpace(ImGui.GetID("MainMenu_DockSpace"), new Vector2(0.0f, 0.0f), ImGuiDockNodeFlags.None | ImGuiDockNodeFlags.PassthruCentralNode);
        ImGui.SetNextWindowDockID(dockspaceID, ImGuiCond.Once);
        ImGui.End();

        //ImGuiDockNodeFlags.NoResize;

        ImGui.Begin("Game", ImGui.IsWindowDocked() == true ? ImGuiWindowFlags.NoBringToFrontOnFocus : ImGuiWindowFlags.None);
        ImGui.PushID("Game");
        ImGui.Text("This is the Game Window.");
        ImGui.SetNextWindowDockID(dockspaceID, ImGuiCond.Once);
        ImGui.End();

        ImGui.Begin("Project", ImGui.IsWindowDocked() == true ? ImGuiWindowFlags.NoBringToFrontOnFocus : ImGuiWindowFlags.None);
        ImGui.PushID("Project");
        ImGui.Text("This is the Project Window.");
        ImGui.SetNextWindowDockID(dockspaceID, ImGuiCond.Once);
        ImGui.End();

        ImGui.Begin("Inspector", ImGui.IsWindowDocked() == true ? ImGuiWindowFlags.NoBringToFrontOnFocus : ImGuiWindowFlags.None);
        ImGui.PushID("Inspector");
        ImGui.Text("This is the Inspector Window.");
        ImGui.SetNextWindowDockID(dockspaceID, ImGuiCond.Once);
        ImGui.End();

        ImGui.Begin("Scene", ImGui.IsWindowDocked() == true ? ImGuiWindowFlags.NoBringToFrontOnFocus : ImGuiWindowFlags.None);
        ImGui.PushID("Scene");
        ImGui.Text("This is the Scene Window.");
        ImGui.SetNextWindowDockID(dockspaceID, ImGuiCond.Once);
        ImGui.End();

        ImGui.Begin("Hierarchy", ImGui.IsWindowDocked() == true ? ImGuiWindowFlags.NoBringToFrontOnFocus : ImGuiWindowFlags.None);
        ImGui.PushID("Hierarchy");
        ImGui.Text("This is the Hierarchy Window.");
        ImGui.SetNextWindowDockID(dockspaceID, ImGuiCond.Once);
        ImGui.End();

        ImGui.Begin("Console", ImGui.IsWindowDocked() == true ? ImGuiWindowFlags.NoBringToFrontOnFocus : ImGuiWindowFlags.None);
        ImGui.PushID("Console");
        ImGui.Text("This is the Console Window.");
        ImGui.SetNextWindowDockID(dockspaceID, ImGuiCond.Once);
        ImGui.End();

        // if (GuiController._debug == true)
        // {
        //     ImGui.Text("Hello, world!");
        //     ImGui.Text($"Mouse position: {ImGui.GetMousePos()}");
        //     if (ImGui.Button("Button"))
        //     {
        //         ImGui.Text("Button clicked");
        //     }

        //     float framerate = ImGui.GetIO().Framerate;
        //     ImGui.Text($"Application average {1000.0f / framerate:0.##} ms/frame ({framerate:0.#} FPS)");
        //     ImGui.Checkbox("Another Window", ref _showAnotherWindow);
        //     //ImGui.PopStyleVar();

        //     // 2. Show another simple window. In most cases you will use an explicit Begin/End pair to name your windows.
        //     if (_showAnotherWindow)
        //     {
        //         ImGui.Begin("Another Window", ref _showAnotherWindow, ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize);
        //         ImGui.Text("Hello from another window!");
        //         if (ImGui.Button("Close Me"))
        //             _showAnotherWindow = false;
        //         ImGui.End();
        //     }

        //     if (ImGui.TreeNode("Tabs"))
        //     {
        //         if (ImGui.TreeNode("Basic"))
        //         {
        //             ImGuiTabBarFlags tab_bar_flags = ImGuiTabBarFlags.None;
        //             if (ImGui.BeginTabBar("MyTabBar", tab_bar_flags))
        //             {
        //                 if (ImGui.BeginTabItem("Avocado"))
        //                 {
        //                     ImGui.Text("This is the Avocado tab!\nblah blah blah blah blah");
        //                     ImGui.EndTabItem();
        //                 }
        //                 if (ImGui.BeginTabItem("Broccoli"))
        //                 {
        //                     ImGui.Text("This is the Broccoli tab!\nblah blah blah blah blah");
        //                     ImGui.EndTabItem();
        //                 }
        //                 if (ImGui.BeginTabItem("Cucumber"))
        //                 {
        //                     ImGui.Text("This is the Cucumber tab!\nblah blah blah blah blah");
        //                     ImGui.EndTabItem();
        //                 }
        //                 ImGui.EndTabBar();
        //             }
        //             ImGui.Separator();
        //             ImGui.TreePop();
        //         }

        //         if (ImGui.TreeNode("Advanced & Close Button"))
        //         {
        //             // Expose a couple of the available flags. In most cases you may just call BeginTabBar() with no flags (0).
        //             ImGui.CheckboxFlags("ImGuiTabBarFlags_Reorderable", ref s_tab_bar_flags, (uint)ImGuiTabBarFlags.Reorderable);
        //             ImGui.CheckboxFlags("ImGuiTabBarFlags_AutoSelectNewTabs", ref s_tab_bar_flags, (uint)ImGuiTabBarFlags.AutoSelectNewTabs);
        //             ImGui.CheckboxFlags("ImGuiTabBarFlags_NoCloseWithMiddleMouseButton", ref s_tab_bar_flags, (uint)ImGuiTabBarFlags.NoCloseWithMiddleMouseButton);
        //             if ((s_tab_bar_flags & (uint)ImGuiTabBarFlags.FittingPolicyMask) == 0)
        //                 s_tab_bar_flags |= (uint)ImGuiTabBarFlags.FittingPolicyDefault;
        //             if (ImGui.CheckboxFlags("ImGuiTabBarFlags_FittingPolicyResizeDown", ref s_tab_bar_flags, (uint)ImGuiTabBarFlags.FittingPolicyResizeDown))
        //         s_tab_bar_flags &= ~((uint)ImGuiTabBarFlags.FittingPolicyMask ^ (uint)ImGuiTabBarFlags.FittingPolicyResizeDown);
        //             if (ImGui.CheckboxFlags("ImGuiTabBarFlags_FittingPolicyScroll", ref s_tab_bar_flags, (uint)ImGuiTabBarFlags.FittingPolicyScroll))
        //         s_tab_bar_flags &= ~((uint)ImGuiTabBarFlags.FittingPolicyMask ^ (uint)ImGuiTabBarFlags.FittingPolicyScroll);

        //             // Tab Bar
        //             string[] names = { "Artichoke", "Beetroot", "Celery", "Daikon" };

        //             for (int n = 0; n < s_opened.Length; n++)
        //             {
        //                 if (n > 0) { ImGui.SameLine(); }
        //                 ImGui.Checkbox(names[n], ref s_opened[n]);
        //             }

        //             // Passing a bool* to BeginTabItem() is similar to passing one to Begin(): the underlying bool will be set to false when the tab is closed.
        //             if (ImGui.BeginTabBar("MyTabBar", (ImGuiTabBarFlags)s_tab_bar_flags))
        //             {
        //                 for (int n = 0; n < s_opened.Length; n++)
        //                     if (s_opened[n] && ImGui.BeginTabItem(names[n], ref s_opened[n]))
        //                     {
        //                         ImGui.Text($"This is the {names[n]} tab!");
        //                         if ((n & 1) != 0)
        //                             ImGui.Text("I am an odd tab.");
        //                         ImGui.EndTabItem();
        //                     }
        //                 ImGui.EndTabBar();
        //             }
        //             ImGui.Separator();
        //             ImGui.TreePop();
        //         }
        //         ImGui.TreePop();
        //     }

        //     ImGui.Text("\n" + "Frame time = " + GuiController.io.DeltaTime.ToString());
        //     ImGui.Text(ImGui.GetKeyIndex(ImGuiKey.Tab).ToString());
        //     ImGui.Text(GuiController.io.MousePos.X.ToString());
        //     ImGui.Text(GuiController.io.MousePos.Y.ToString());
        //     ImGui.Text(GuiController.io.KeysDown.ToString());

        //     if (ImGui.ArrowButton("##test", ImGuiDir.Down))
        //     {
        //         ImGui.Text("ArrowButton");
        //     }

        //     if (ImGui.IsKeyDown(ImGuiKey.Tab))
        //     {
        //         ImGui.Text("Tab is down");
        //     }

        //     if (ImGui.IsMouseDown(0))
        //     {
        //         ImGui.Text("Mouse 0 is down");
        //     }

        //     if (ImGui.IsKeyPressed(ImGuiKey.Tab))
        //     {
        //         ImGui.Text("Tab is pressed");
        //     }

        //     if (ImGui.IsKeyReleased(ImGuiKey.Tab))
        //     {
        //         ImGui.Text("Tab is released");
        //     }
        // }
    }

    public static void CreateMainMenu()
    {
        var menu = new Dictionary<string, Dictionary<string[], Action[]>>();
        var submenu_file = new Dictionary<string[], Action[]>();

        //Create menus here and actions per menu item
        submenu_file.Add(new string[]
        {
            "New Scene",
            "Open Scene",
            "Save",
            "Save As",
            "New Project",
            "Open Project",
            "Save Project",
            "Build Settings",
            "Build and Run",
            "Exit"
        },
        new Action[]
        {
            () => {
                Console.WriteLine("'New Scene' Clicked");
            },
            () => {
                Console.WriteLine("'Open Scene' Clicked");
            },
            () => {
                Console.WriteLine("'Save' Clicked");
            },
            () => {
                Console.WriteLine("'Save As' Clicked");
            },
            () => {
                Console.WriteLine("'New Project' Clicked");
            },
            () => {
                Console.WriteLine("'Open Project' Clicked");
            },
            () => {
                Console.WriteLine("'Save Project' Clicked");
            },
            () => {
                Console.WriteLine("'Build Settings' Clicked");
            },
            () => {
                Console.WriteLine("'Build and Run' Clicked");
            },
            () => {
                GuiController._window?.Close();
            }
        });

        menu.Add("File", submenu_file);

        var submenu_edit = new Dictionary<string[], Action[]>();
        submenu_edit.Add(new string[]
        {
            "Undo",
            "Redo",
            "Cut",
            "Copy",
            "Paste",
            "Rename",
            "Duplicate",
            "Delete",
            "Play",
            "Pause",
            "Stop",
            "Project Settings",
            "Preferences"
        },
        new Action[]
        {
            () => {
                Console.WriteLine("'Undo' Clicked");
            },
            () => {
                Console.WriteLine("'Redo' Clicked");
            },
            () => {
                Console.WriteLine("'Cut' Clicked");
            },
            () => {
                Console.WriteLine("'Copy' Clicked");
            },
            () => {
                Console.WriteLine("'Paste' Clicked");
            },
            () => {
                Console.WriteLine("'Rename' Clicked");
            },
            () => {
                Console.WriteLine("'Duplicate' Clicked");
            },
            () => {
                Console.WriteLine("'Delete' Clicked");
            },
            () => {
                Console.WriteLine("'Play' Clicked");
            },
            () => {
                Console.WriteLine("'Pause' Clicked");
            },
            () => {
                Console.WriteLine("'Stop' Clicked");
            },
            () => {
                Console.WriteLine("'Project Settings' Clicked");
            },
            () => {
                Console.WriteLine("'Preferences' Clicked");
            }
        });

        menu.Add("Edit", submenu_edit);
        MainMenuConstructor(menu);
    }

    //A function that creates Main Menu Bar and submenus in IMGUI
    private static void MainMenuConstructor(Dictionary<string, Dictionary<string[], Action[]>> menuOptions)
    {            
        if (ImGui.BeginMenuBar())
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
            ImGui.EndMenuBar();
        }
    }
}
