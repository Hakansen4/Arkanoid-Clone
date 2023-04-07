namespace Events.Features
{
    public readonly struct EV_BoxDestroyEffect
    {
        public readonly BoxDestroyEffect effect;
        public EV_BoxDestroyEffect(BoxDestroyEffect effect)
        {
            this.effect = effect;
        }
    }
}