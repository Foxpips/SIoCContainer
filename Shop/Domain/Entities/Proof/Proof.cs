namespace Shop.Domain.Entities.Proof
{
    public class Proof : IProof
    {
        public bool HasProof { get; set; }
        public IProofType CustomerProof { get; set; }

        public Proof(IProofType prooftype)
        {
            CustomerProof = prooftype;
        }
    }
}