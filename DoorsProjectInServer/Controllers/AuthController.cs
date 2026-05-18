using Bl.Models;
using Bl.Services;
using Bl.Api;
using Dal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DoorsProjectInServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IBlEmployees _service;
        private readonly JwtService _jwt;

        public AuthController(IBlEmployees  service, JwtService jwt)
        {
            _service = service;
            _jwt = jwt;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(BlLogin model)
        {
            var user = await _service.Login(model.Email, model.Password);

            if (user == null)
                return Unauthorized();

            var token = _jwt.GenerateToken(user);

            return Ok(new
            {
                token,
                user = new
                {
                    user.Id,
                    user.Name,
                    role = user.Status.ToString()
                }
            });
        }
    }
}
