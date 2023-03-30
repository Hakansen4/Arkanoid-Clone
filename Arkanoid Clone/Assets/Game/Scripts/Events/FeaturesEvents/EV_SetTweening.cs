
namespace Events.Features
{
    public readonly struct EV_SetTweening
    {
        public readonly int TweenValue;
        public readonly bool Randomizer;
        public EV_SetTweening(int tweenValue, bool randomizer)
        {
            TweenValue = tweenValue;
            Randomizer = randomizer;
        }
    }
}
