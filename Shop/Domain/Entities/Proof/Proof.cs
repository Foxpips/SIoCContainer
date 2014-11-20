using SIoCContainer.Attributes;

namespace Shop.Domain.Entities.Proof
{
    public class Proof : IProof
    {
        public bool HasProof { get; set; }
        public ProofType CustomerProof { get; set; }

        public class ProofType
        {
            [Injectable("Passport")]
            public string Description { get; set; }

            [Injectable(10)]
            public int Id { get; set; }
        }
    }
}