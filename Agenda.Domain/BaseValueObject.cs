namespace Agenda.Domain
{
    public abstract record BaseValueObject : IEquatable<BaseValueObject>
    {
        public virtual bool Equals(BaseValueObject? other) =>
            other is not null && ValuesAreEqual(other);

        public override int GetHashCode() =>
            GetAtomicValues().Aggregate(
                default(int),
                (hashcode, value) =>
                    HashCode.Combine(hashcode, value.GetHashCode()));

        protected abstract IEnumerable<object> GetAtomicValues();

        private bool ValuesAreEqual(BaseValueObject BaseValueObject) =>
            GetAtomicValues().SequenceEqual(BaseValueObject.GetAtomicValues());
    }
}
