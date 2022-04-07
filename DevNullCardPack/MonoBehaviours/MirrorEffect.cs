using ModdingUtils.MonoBehaviours;
using DevNullCardPack.Extensions;

namespace DevNullCardPack.MonoBehaviours
{
    internal class MirrorEffect : ReversibleEffect
    {
        public override void OnStart()
        {
            data.GetDevNullData().reverseControls = true;
        }
    }
}
