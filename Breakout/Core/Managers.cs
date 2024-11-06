using Breakout.Core.Input;
using Breakout.Core.Update;
using Breakout.Core.Timing;
using Breakout.Core.Physics;
using System.Media;

namespace Breakout.Core
{
    public struct Managers
    {
        public GameWorld gameWorld;
        public TimerManager timerManager;
        public InputManager inputManager;
        public UpdateManager updateManager;
        public PhysicsManager physicsManager;
    }
}
