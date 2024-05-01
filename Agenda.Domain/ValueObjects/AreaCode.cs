using Agenda.Domain.Entities;

namespace Agenda.Domain.ValueObjects
{
    public record AreaCode : BaseValueObject
    {
        public AreaCode(string code, string capital, string federalUnity)
        {
            Code = code;
            Capital = capital;
            FederalUnity = federalUnity;
        }

        public AreaCode() { }

        public string Code { get; set; }
        public string Capital { get; set; }
        public string FederalUnity { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Code;
            yield return Capital;
            yield return FederalUnity;
        }
    }
}
