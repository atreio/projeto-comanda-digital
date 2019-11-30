using System.Security.Claims;

namespace ComandaDigital.Helpers
{
    public class UsuarioConectadoHelper
    {
        public static string GetNome(ClaimsIdentity claimsIdentity)
        {
            if (claimsIdentity != null)
            {
                var c = claimsIdentity.FindFirst(ClaimTypes.Name);

                if (c != null)
                {
                    return @c.Value.ToString();
                }
            }
            return string.Empty;
        }

        public static string GetId(ClaimsIdentity claimsIdentity)
        {
            if (claimsIdentity != null)
            {
                var c = claimsIdentity.FindFirst("IdUsuario");

                if (c != null)
                {
                    return @c.Value.ToString();
                }
            }
            return string.Empty;
        }

        public static string GetTipo(ClaimsIdentity claimsIdentity)
        {
            if (claimsIdentity != null)
            {
                var c = claimsIdentity.FindFirst(ClaimTypes.Role);

                if (c != null)
                {
                    return @c.Value.ToString();
                }
            }
            return string.Empty;
        }
    }
}
