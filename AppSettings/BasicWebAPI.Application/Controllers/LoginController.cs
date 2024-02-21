using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppSettings.BasicWebAPI.Application.Contexts;
using AppSettings.BasicWebAPI.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using AppSettings.BasicWebAPI.Application.Identity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicWebAPI.Application.Controllers {
    [Authorize]
    [Route("api/[controller]")]    
    [ApiController]
    public class LoginController : ControllerBase {

        private readonly IBasicWebAPISettingsContext _context;

        public LoginController(IBasicWebAPISettingsContext context) {
            _context = context;
        }

        // GET: api/Companies
        //[HttpGet(Name = "GetLoginsAsync"), Authorize]
        [AllowAnonymous] //Replaces Authorize and allow request to display without Authentication/Authorization  [Authorize] is now at the top of the controller and not in each of the requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Login>>> GetLoginsAsync() {
            if(_context.Login == null) {
                return NotFound();
            }
            return await _context.Login.ToListAsync();
        }

        // GET: api/Companies/5
        //[HttpGet(Name = "GetLoginByIdAsync/{id}"), Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Login>> GetLoginByIdAsync(int id) {
            if(_context.Login == null) {
                return NotFound();
            }
            var login = await _context.Login.FindAsync(id);

            if(login == null) {
                return NotFound();
            }

            return login;
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut(Name = "PutLoginAsync/{id}"), Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginAsync(int id , Login login) {
            if(id != login.Id) {
                return BadRequest();
            }

            _context.Entry(login).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException) {
                if(!LoginExists(id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        [HttpPost]
        public async Task<ActionResult<Login>> PostLoginAsync(Login login) {
            if(_context.Login == null) {
                return Problem("Entity set 'BasicWebAPISettingsContext.Login'  is null.");
            }
            _context.Login.Add(login);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoginByIdAsync" , new { id = login.Id } , login);
        }
        

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        //[Authorize(Policy = IdentityData.AdminUserPolicyName)]  // Should respond not with 401 - Unauthorized; but with 403 - Forbidden
        [Authorize]
        [RequiresClaim(IdentityData.AdminUserClaimName, "true")]
        //[HttpDelete("{id}")]   //There is also another level of authorization that is implemented with claims, for example everybody is allowed to get Logins but only admins can delete Logins
        public async Task<IActionResult> DeleteLoginByIdAsync(int id) {
            if(_context.Login == null) {
                return NotFound();
            }
            var login = await _context.Login.FindAsync(id);
            if(login == null) {
                return NotFound();
            }

            _context.Login.Remove(login);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginExists(int id) {
            return (_context.Login?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        /*
        [HttpPost]
        public IActionResult PostLogin(Login loginDTO) {
            try {
                if(string.IsNullOrEmpty(loginDTO.UserName) || string.IsNullOrEmpty(loginDTO.Password)) {
                    return BadRequest("Username and/or Password not specified");
                }

                /*if(loginDTO.UserName.Equals("joao") && loginDTO.Password.Equals("joao")) {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisisasecretkey@123"));
                    var signinCredentials = new SigningCredentials(secretKey , SecurityAlgorithms.HmacSha256);

                    var jwtSecurityToken = new JwtSecurityToken(issuer: "ABCXYZ" ,
                                                                audience: "https://localhost:7082",
                                                                claims: new List<Claim>() ,
                                                                expires: DateTime.Now.AddMinutes(10) ,
                                                                signingCredentials: signinCredentials);

                     Ok(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken));
                }
                /

                if(loginDTO.UserName.Equals("joao") && loginDTO.Password.Equals("joao")) {

                    var tokenHandler = new JwtSecurityTokenHandler();

                    var key = Convert.FromBase64String("this is my custom Secret key for authentication");

                    var tokenDescriptor = new SecurityTokenDescriptor {

                        Subject = new ClaimsIdentity(new[] {
                            new Claim(ClaimTypes.Name, "joao"),
                            new Claim(ClaimTypes.Role, "joao")

                        }) ,
                        //Expires = DateTime.UtcNow.AddHours(1) , // Token expiration time
                        Expires = DateTime.Now.AddMinutes(10) ,
                        Issuer = "joao",
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key) , 
                                                                    SecurityAlgorithms.HmacSha256Signature)

                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    var tokenWritten = tokenHandler.WriteToken(token);
                    return Ok(tokenWritten);
                }


                }
            catch {
                return BadRequest("An error occurred in generating the token");
            }
            //return Unauthorized();
            return Unauthorized();

        }
        */
    }
}

