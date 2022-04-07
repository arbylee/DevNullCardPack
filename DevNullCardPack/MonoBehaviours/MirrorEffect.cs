using ModdingUtils.MonoBehaviours;
using DevNullCardPack.Extensions;

namespace DevNullCardPack.MonoBehaviours
{
    internal class MirrorEffect : ReversibleEffect
    {
        public override void OnStart()
        {
            Toggle();
        }

        public override void OnOnDestroy()
        {
            data.GetDevNullData().reverseControls = data.GetDevNullData().reverseControlsOnStart;
        }

        public void Toggle()
        {
            data.GetDevNullData().reverseControls = !data.GetDevNullData().reverseControls;
        }
    }
}
