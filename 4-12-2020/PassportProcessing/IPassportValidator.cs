namespace PassportProcessing
{
    public interface IPassportValidator
    {
        bool IsPassportValid(Passport passport);
    }
}