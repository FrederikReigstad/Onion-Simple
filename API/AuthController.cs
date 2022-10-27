using Microsoft.AspNetCore.Mvc;

namespace API;

[ApiController]
[Route(("[controller]"))]
public class AuthController : ControllerBase
{
    public AuthController()
    {
        
    }

    public AcceptedResult Login()
    {
        return null;
    }

    public ActionResult Register()
    {
        return null;
    }
    
    
}