using System;
using System.Drawing;
using System.Numerics;
using System.Windows;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ImGuiNET;

public static class GuiLayouts
{
    private static bool _showAnotherWindow = false;
    private static uint s_tab_bar_flags = (uint)ImGuiTabBarFlags.Reorderable;
    static bool[] s_opened = { true, true, true, true }; // Persistent user state

    private static void SetGlobalStyling()
    {
        ImGuiStylePtr style = ImGui.GetStyle();

        style.WindowBorderSize = 0;
        style.WindowTitleAlign = new Vector2(0.5f, 0.5f);
        style.WindowMinSize = new Vector2(900.0f, 430.0f);
        style.WindowRounding = 0.0f;

        style.FramePadding = new Vector2(8.0f, 6.0f);

        style.Colors[(int)ImGuiCol.TitleBg] = new Vector4(255.0f / 255, 101.0f / 255, 53.0f / 255, 255.0f / 255);
        style.Colors[(int)ImGuiCol.TitleBgActive] = new Vector4(255.0f / 255, 101.0f / 255, 53.0f / 255, 255.0f / 255);
        style.Colors[(int)ImGuiCol.TitleBgCollapsed] = new Vector4(0.0f / 255, 0.0f / 255, 0.0f / 255, 130.0f / 255);

        style.Colors[(int)ImGuiCol.Button] = new Vector4(31.0f / 255, 30.0f / 255, 31.0f / 255, 255.0f / 255);
        style.Colors[(int)ImGuiCol.ButtonActive] = new Vector4(31.0f / 255, 30.0f / 255, 31.0f / 255, 255.0f / 255);
        style.Colors[(int)ImGuiCol.ButtonHovered] = new Vector4(41.0f / 255, 40.0f / 255, 41.0f / 255, 255.0f / 255);

        style.Colors[(int)ImGuiCol.Separator] = new Vector4(70.0f / 255, 70.0f / 255, 70.0f / 255, 255.0f / 255);
        style.Colors[(int)ImGuiCol.SeparatorActive] = new Vector4(76.0f / 255, 76.0f / 255, 76.0f / 255, 255.0f / 255);
        style.Colors[(int)ImGuiCol.SeparatorHovered] = new Vector4(76.0f / 255, 76.0f / 255, 76.0f / 255, 255.0f / 255);

        style.Colors[(int)ImGuiCol.FrameBg] = new Vector4(37.0f / 255, 36.0f / 255, 37.0f / 255, 255.0f / 255);
        style.Colors[(int)ImGuiCol.FrameBgActive] = new Vector4(37.0f / 255, 36.0f / 255, 37.0f / 255, 255.0f / 255);
        style.Colors[(int)ImGuiCol.FrameBgHovered] = new Vector4(37.0f / 255, 36.0f / 255, 37.0f / 255, 255.0f / 255);

        style.Colors[(int)ImGuiCol.Header] = new Vector4(0.0f / 255, 0.0f / 255, 0.0f / 255, 0.0f / 255);
        style.Colors[(int)ImGuiCol.HeaderActive] = new Vector4(0.0f / 255, 0.0f / 255, 0.0f / 255, 0.0f / 255);
        style.Colors[(int)ImGuiCol.HeaderHovered] = new Vector4(46.0f / 255, 46.0f / 255, 46.0f / 255, 255.0f / 255);

        style.Colors[(int)ImGuiCol.WindowBg].W = 1.0f;
    }

    public static void Render()
    {
        SetGlobalStyling();

        ImGuiIOPtr io = ImGui.GetIO();
        io.BackendFlags |= ImGuiBackendFlags.PlatformHasViewports;

        io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
        io.ConfigFlags |= ImGuiConfigFlags.ViewportsEnable;
        io.ConfigWindowsMoveFromTitleBarOnly = true;


        
        //ImGui.SetNextWindowSizeConstraints(new Vector2(1280, 720), new Vector2(2560, 1440));

        if (ImGui.Begin("Main Window", ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoMove))
        {
            
            // if (ImGui.IsMouseDragging(ImGuiMouseButton.Left) && moveDeltaOffscreen != Vector2.Zero)
            // {
            //     //io.MouseDelta
            //     //ImGui.CaptureMouseFromApp(true);
            //     //ImGui.ResetMouseDragDelta();
                
            //     Vector2 moveDelta = ImGui.GetMouseDragDelta(ImGuiMouseButton.Left);

            //     GuiController._window!.X += (int)moveDelta.X;
            //     GuiController._window!.Y += (int)moveDelta.Y;
            //     Console.WriteLine("Dragging detected!: " + moveDelta);
            // }

            //ImGui
            //GuiController._window!.Moved
            //GuiController._window!.X = (int)(ImGui.GetWindowPos().X);
            //GuiController._window!.Y = (int)(ImGui.GetWindowPos().Y);
            // ImGui.SetWindowPos(new Vector2(0, 0));
            //GuiController._window!.Width = (int)(windowPosX + ImGui.GetWindowSize().X + 1);
            //GuiController._window!.Height = (int)(windowPosY + ImGui.GetWindowSize().Y + 1);
            //GuiController._window!.

            //CreateMainMenu();

            ImGui.Text("Window Position X: " + ImGui.GetWindowPos().X.ToString());
            ImGui.Text("Window Position Y: " + ImGui.GetWindowPos().Y.ToString());
            ImGui.Text("Window Width: " + ImGui.GetWindowSize().X.ToString());
            ImGui.Text("Window Height: " + ImGui.GetWindowSize().Y.ToString());
            ImGui.Text("Mouse X: " + ImGui.GetMousePos().X.ToString());
            ImGui.Text("Mouse Y: " + ImGui.GetMousePos().Y.ToString());

            //ImGui.Text("Mouse POS Extern: " + GetCursorPosition());
            //ImGui.Text("Mouse DELTA Extern: <" + (moveDeltaOffscreen.X) + ", " + (moveDeltaOffscreen.Y) + ">");
            //ImGui.Text("Mouse Relative Pos: " + relativeDragPosition);
            //ImGui.Text("Window Pos: <" + GuiController._window!.X + ", " + GuiController._window!.Y + ">");
            ImGui.Text("Test");
            ImGui.End();

            //Console.WriteLine("Mouse POS Extern: " + GetCursorPosition());
            //Console.WriteLine("Mouse Relative Pos: " + relativeDragPosition);
        }

        //ImGui.GetWindowPos().x;
        //ImGui.GetWindowSize();
        
        //ImGui.SetNextWindowViewport(0);
        // }
        // ImGui.End();


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

            ImGui.Text("\n" + "Frame time = " + io.DeltaTime.ToString());
            ImGui.Text(ImGui.GetKeyIndex(ImGuiKey.Tab).ToString());
            ImGui.Text(io.MousePos.X.ToString());
            ImGui.Text(io.MousePos.Y.ToString());
            ImGui.Text(io.KeysDown.ToString());

            //Enable docking flag for windows
            //io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;

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
            
                // ImGui.   (ImGuiStyleVar.Alpha, 1.0f);
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


















/*
REVIEW THIS INFO IN C++ and port some to C#



static int initialized = 0;
		static int new_window = 0;
		ImGuiWindowFlags flags = ImGuiWindowFlags_MenuBar;
		flags |= ImGuiWindowFlags_NoDocking;
		ImGuiViewport* viewport = ImGui::GetMainViewport();
		ImGui::SetNextWindowPos(viewport->Pos);
		ImGui::SetNextWindowSize(viewport->Size);
		ImGui::SetNextWindowViewport(viewport->ID);
		ImGui::PushStyleVar(ImGuiStyleVar_WindowRounding, 0.0f);
		flags |= ImGuiWindowFlags_NoTitleBar | ImGuiWindowFlags_NoCollapse | ImGuiWindowFlags_NoResize | ImGuiWindowFlags_NoMove;
		flags |= ImGuiWindowFlags_NoBringToFrontOnFocus | ImGuiWindowFlags_NoNavFocus;
		ImGui::PushStyleVar(ImGuiStyleVar_WindowPadding, ImVec2(0.0f, 0.0f));
		ImGui::Begin("DockSpace Demo", 0, flags);
		ImGui::PopStyleVar();

		if (ImGui::BeginMenuBar())
		{
			if (initialized == 0)
			{
				if (ImGui::Button("1. Initialize"))
					initialized = 1;
			}
			if (initialized > 0 && new_window == 0)
			{
				if (ImGui::Button("2. New Window"))
					new_window = 1;
			}
			ImGui::EndMenuBar();
		}

		ImGuiIO& io = ImGui::GetIO();
		ImGuiID dockspace_id = ImGui::GetID("MyDockspace");

		if (initialized == 1)
		{
			initialized = 2;
			ImGuiContext* ctx = ImGui::GetCurrentContext();
			ImGui::DockBuilderRemoveNode(ctx, dockspace_id); // Clear out existing layout
			ImGui::DockBuilderAddNode(ctx, dockspace_id, ImGui::GetMainViewport()->Size); // Add empty node

			ImGuiID dock_main_id = dockspace_id; // This variable will track the document node, however we are not using it here as we aren't docking anything into it.
			ImGuiID dock_id_prop = ImGui::DockBuilderSplitNode(ctx, dock_main_id, ImGuiDir_Left, 0.20f, NULL, &dock_main_id);
			ImGuiID dock_id_bottom = ImGui::DockBuilderSplitNode(ctx, dock_main_id, ImGuiDir_Down, 0.20f, NULL, &dock_main_id);

			ImGui::DockBuilderDockWindow(ctx, "Log", dock_id_bottom);
			ImGui::DockBuilderDockWindow(ctx, "Properties", dock_id_prop);
			ImGui::DockBuilderFinish(ctx, dockspace_id);
		}

		ImGui::DockSpace(dockspace_id);
		if (initialized == 2)
		{
			ImGui::Begin("Properties");
			ImGui::End();

			ImGui::Begin("Log");
			ImGui::End();
		}

		if (new_window == 1)
		{
			// Should dock window to empty space, instead window is not docked anywhere.
			ImGui::SetNextWindowDockId(dockspace_id, ImGuiCond_Once);
			ImGui::Begin("New Window");
			ImGui::End();
		}

		ImGui::End();
		ImGui::PopStyleVar();
*/