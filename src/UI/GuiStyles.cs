using System;
using System.Drawing;
using System.Numerics;
using System.Windows;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ImGuiNET;

public static class GuiStyles
{
    public static void SetGlobalStyling()
    {
        ImGuiStylePtr style = ImGui.GetStyle();

        //Handle WINDOW
        style.WindowTitleAlign = new Vector2(0.5f, 0.5f);
        style.WindowRounding = 0.0f;
        style.WindowBorderSize = 2.0f;
        style.WindowMenuButtonPosition = ImGuiDir.Right; //Hide dropdown for multi window menu
        style.WindowPadding = new Vector2(0.0f, 0.0f);
        style.ColorButtonPosition = ImGuiDir.Right; //Hide dropdown for color picker
        
        //Handle FrRAMEPADDING
        style.FramePadding = new Vector2(8.0f, 6.0f);
        style.FrameRounding = 0.0f;
        style.FrameBorderSize = 0.0f;
        style.Colors[(int)ImGuiCol.FrameBg] = new Vector4(0.14509803921f, 0.14117647058f, 0.14509803921f, 1.0f);
        style.Colors[(int)ImGuiCol.FrameBgActive] = new Vector4(0.14509803921f, 0.14117647058f, 0.14509803921f, 1.0f);
        style.Colors[(int)ImGuiCol.FrameBgHovered] = new Vector4(0.14509803921f, 0.14117647058f, 0.14509803921f, 1.0f);

        style.Colors[(int)ImGuiCol.TitleBg] = new Vector4(0.2f, 0.2f, 0.2f, 1.0f);
        style.Colors[(int)ImGuiCol.TitleBgActive] = new Vector4(0.2f, 0.2f, 0.2f, 1.0f);
        style.Colors[(int)ImGuiCol.TitleBgCollapsed] = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);

        style.Colors[(int)ImGuiCol.Button] = new Vector4(0.12156862745f, 0.11764705882f, 0.12156862745f, 1.0f);
        style.Colors[(int)ImGuiCol.ButtonActive] = new Vector4(0.12156862745f, 0.11764705882f, 0.12156862745f, 1.0f);
        style.Colors[(int)ImGuiCol.ButtonHovered] = new Vector4(0.16078431372f, 0.15686274509f, 0.16078431372f, 1.0f);

        style.Colors[(int)ImGuiCol.Separator] = new Vector4(0.27450980392f, 0.27450980392f, 0.27450980392f, 1.0f);
        style.Colors[(int)ImGuiCol.SeparatorActive] = new Vector4(0.29803921568f, 0.29803921568f, 0.29803921568f, 1.0f);
        style.Colors[(int)ImGuiCol.SeparatorHovered] = new Vector4(0.29803921568f, 0.29803921568f, 0.29803921568f, 1.0f);

        style.Colors[(int)ImGuiCol.Header] = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);
        style.Colors[(int)ImGuiCol.HeaderActive] = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);
        style.Colors[(int)ImGuiCol.HeaderHovered] = new Vector4(0.18039215686f, 0.18039215686f, 0.18039215686f, 1.0f);

        //Handle DOCKING
        style.Colors[(int)ImGuiCol.DockingEmptyBg] = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);

        //Handle
        //style.IndentSpacing = 15.0f;

        //Handle TABS
        style.TabRounding = 0.0f;
        style.TabBorderSize = 0.5f;
        style.Colors[(int)ImGuiCol.TabActive] = new Vector4(0.3f, 0.3f, 0.3f, 1.0f);
        style.Colors[(int)ImGuiCol.TabHovered] = new Vector4(0.35f, 0.35f, 0.35f, 1.0f);
        style.Colors[(int)ImGuiCol.TabUnfocused] = new Vector4(0.25f, 0.25f, 0.25f, 1.0f);
        style.Colors[(int)ImGuiCol.TabUnfocusedActive] = new Vector4(0.25f, 0.25f, 0.25f, 1.0f);
        style.Colors[(int)ImGuiCol.Tab] = new Vector4(0.25f, 0.25f, 0.25f, 1.0f);
    }
}