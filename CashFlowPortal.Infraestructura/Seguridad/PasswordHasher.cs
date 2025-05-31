namespace CashFlowPortal.Infraestructura.Seguridad
{
    public static class PasswordHasher
    {
        public static string HashPassword(string plain)
            => BCrypt.Net.BCrypt.HashPassword(plain);

        public static bool Verify(string plain, string hashed)
        {
            bool isSame = BCrypt.Net.BCrypt.Verify(plain, hashed);
            //string a =BCrypt.Net.BCrypt.HashPassword(plain);
            return isSame;
        }
    }
}
