namespace Events.Features
{
    public readonly struct EV_BallHitSound
    {
        public readonly string Type;
        public EV_BallHitSound(string type)
        {
            Type = type;
        }
    }
}