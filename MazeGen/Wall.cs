using System;

namespace MazeGen
{
    [Flags]
    public enum Wall
    {
        Hx = 1,
        Lx = 2,
        Hy = 4,
        Ly = 8,
        Hz = 16,
        Lz = 32,
        All = Hx | Lx | Hy | Ly | Hz | Lz,
        None = 0,
        BothX = Hx | Lx,
        BothY = Hy | Ly,
        BothZ = Hz | Lz
    }
}
