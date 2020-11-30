namespace Hermes.Identity.Common
{
    public class IdentityException : DomainException
    {
        public override string Code { get; } = "invalid_identity_property_exception";

        public IdentityException(string message) : base(message)
        {

        }

        public IdentityException(string message, string code) : base(message)
        {
            Code = code;
        }
    }
}