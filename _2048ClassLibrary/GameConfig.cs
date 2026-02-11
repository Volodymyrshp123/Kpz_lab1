using System.Drawing;
namespace _2048ClassLibrary
{
   public static class GameConfig
    {
        public const int BoardSize = 4;
        public static readonly Size WindowSize = new Size(400, 460);

        public static Color GetColorForValue(int value) => value switch
        {
            2 => Color.LightYellow,
            4 => Color.Khaki,
            8 => Color.Orange,
            16 => Color.OrangeRed,
            32 => Color.Red,
            64 => Color.DarkRed,
            128 => Color.Purple,
            256 => Color.MediumPurple,
            512 => Color.Blue,
            1024 => Color.DarkBlue,
            2048 => Color.Gold,
            _ => Color.WhiteSmoke,
        };
    }
}
