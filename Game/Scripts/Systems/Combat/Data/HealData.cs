namespace Game.Systems.Combat.Data
{
    public readonly struct HealData
    {
        public float Amount { get; }

        public HealData(float amount)
        {
            Amount = amount;
        }
    }
}
