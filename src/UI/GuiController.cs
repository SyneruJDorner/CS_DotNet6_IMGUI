using System.Numerics;
using ImGuiNET;
using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;

public static class GuiController
{
    #region Variables
    public static Sdl2Window? _window { get; private set; }
    private static GraphicsDevice? _gd;
    private static CommandList? _cl;
    private static ImGuiHelper? _helper;
    public static ImGuiIOPtr io;
    public static bool _debug { get; private set; } = false;
    private static readonly Vector3 _clearColor = new Vector3(0f, 0f, 0f);
    #endregion

    public static void Update(string[]? args = null)
    {
        #region Initialize
        //Determine if we in debug mode
        if (args?.Length >= 1 && args[0] == "--debug")
        {
            _debug = true;
        }

        //Create our window as well as the graphic device
        var title = "ImGui.NET ImGUI Application";
        _window = new Sdl2Window(title, 100, 100, 1440, 900, SDL_WindowFlags.Resizable, false);
        _gd = VeldridStartup.CreateDefaultD3D11GraphicsDevice(new GraphicsDeviceOptions(false, null, true), _window);
    
        _cl = _gd.ResourceFactory.CreateCommandList();
        _helper = new ImGuiHelper(_gd, _gd.MainSwapchain.Framebuffer.OutputDescription, _window.Width, _window.Height);

        //Make window resizable
        _window.Resized += () =>
        {
            _gd.MainSwapchain.Resize((uint)_window.Width, (uint)_window.Height);
            _helper!.WindowResized(_window.Width, _window.Height);
        };
        #endregion

        #region Main Loop
        //Main loop of the running application
        while (_window!.Exists)
        {
            //Ensure window exists, otherwise we end the loop and stop the application
            if (!_window.Exists) { break; }

            //Set the framerate 1/fps where fps is the desired framerate
            int fps = 144;
            _helper.Update(1f / fps, _window.PumpEvents()!);

            //Main frontend layout renderer
            IoFlags.SetIoFlags();
            GuiStyles.SetGlobalStyling();
            //GUIDragable.MakeWindowDraggable();
            GuiLayouts.Render();
            
            //Render the ImGui based on the rules above for this frame
            _cl.Begin();
            _cl.SetFramebuffer(_gd.MainSwapchain.Framebuffer);
            _cl.ClearColorTarget(0, new RgbaFloat(_clearColor.X, _clearColor.Y, _clearColor.Z, 0.0f));
            _helper.Render(_gd, _cl);
            _cl.End();
            _gd.SubmitCommands(_cl);
            _gd.SwapBuffers(_gd.MainSwapchain);
        }
        #endregion

        #region Quit
        //On quit we need to dispose of all resources
        _gd.WaitForIdle();
        _helper.Dispose();
        _cl.Dispose();
        _gd.Dispose();
        #endregion
    }
}