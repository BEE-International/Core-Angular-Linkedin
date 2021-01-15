using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Logic.Services;
using Microsoft.AspNetCore.Authorization;

namespace LinkedInWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILinkedInService _linkedInService;

        public LoginController(ILinkedInService linkedInService)
        {
            _linkedInService = linkedInService;
        }

        /// <summary>
        /// Uses result from :
        /// https://www.linkedin.com/uas/oauth2/authorization..
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Specific LinkedIn UserData</returns>
        [AllowAnonymous]
        [HttpGet("LinkedInAuth")]
        public async Task<IActionResult> LinkedInAuth(string code)
        {
            try
            {
                var linkedInUserData = await _linkedInService.LinkedInLogin(code).ConfigureAwait(false);
                return Ok(linkedInUserData);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest("Failed to login");
            }
        }
    }
}
