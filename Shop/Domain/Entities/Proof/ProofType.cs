using IoCContainer.Attributes;

namespace Shop.Domain.Entities.Proof
{
    public class ProofType : IProofType
    {
        [Injectable("Passport")]
        public string Description { get; set; }

        [Injectable(10)]
        public int Id { get; set; }
    }
}