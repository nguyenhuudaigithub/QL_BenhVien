using HospitalManagement.Data;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecureWebsiteController(SignInManager<NguoiDung> sm, UserManager<NguoiDung> um) : Controller
    {
        private readonly SignInManager<NguoiDung> signInManager = sm;
        private readonly UserManager<NguoiDung> userManager = um;

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterModel user)
        {
            string message = "";
            IdentityResult result = new();

            NguoiDung nguoiDung = await userManager.FindByEmailAsync(user.Email);

            if (nguoiDung != null && !nguoiDung.EmailConfirmed)
            {
                return BadRequest("Email đã tồn tại");
            }

            try
            {
                NguoiDung nguoiDungMoi = new NguoiDung()
                {
                    Email = user.Email,
                    UserName = user.Email,
                    CCCD = user.CCCD,
                    HoDem = user.HoDem,
                    Ten = user.Ten,
                    PhoneNumber = user.SDT,
                    NgaySinh = user.NgaySinh,
                    GioiTinh = user.GioiTinh,
                    IdPhuong = user.IdPhuong,
                    Duong = user.Duong,
                };

                result = await userManager.CreateAsync(nguoiDungMoi, user.Password);

                if (!result.Succeeded)
                {
                    return BadRequest(result);
                }

                message = "Đăng ký thành công";
            }
            catch (Exception ex)
            {
                return BadRequest("Có lỗi đăng ký " + ex.Message);
            }

            return Ok(new { message = message, result = result });
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginModel login)
        {
            string message = "";
            NguoiDung userInfo = null;

            try
            {
                NguoiDung nguoiDung = await userManager.FindByEmailAsync(login.Email);

                if (nguoiDung != null && !nguoiDung.EmailConfirmed)
                {
                    nguoiDung.EmailConfirmed = true;
                }

                // Kiểm tra thông tin đăng nhập
                var result = await signInManager.PasswordSignInAsync(nguoiDung, login.Password, true, false);

                if (!result.Succeeded)
                {
                    return Unauthorized("Kiểm tra đăng nhập");
                }

                userInfo = nguoiDung;
                message = "Đăng Nhập thành công";
            }
            catch (Exception ex)
            {
                return BadRequest("Có lỗi đăng nhập " + ex.Message);
            }

            return Ok(new { message = message, userInfo = userInfo });
        }


        [HttpGet("logout"), Authorize]
        public async Task<IActionResult> LogoutUser()
        {
            string message = "Bạn đã đăng xuất";

            try
            {
                await signInManager.SignOutAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Có lỗi đăng xuất " + ex.Message);
            }

            return Ok(new { message = message });
        }

        [HttpPost("addRoleToUser")]
        //[Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> AddRoleToUser(string email, string role)
        {
            string[] roleNames = { "BacSi", "BacSiChiDinh", "DuocSi", "Admin" };
            if (!roleNames.Contains(role))
            {
                return BadRequest("Quyền " + role + " không tồn tại");
            }

            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound("Người dùng không tồn tại");
            }

            var currentRoles = await userManager.GetRolesAsync(user);

            // Remove all existing roles
            var removeResult = await userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!removeResult.Succeeded)
            {
                return BadRequest("Không thể xóa quyền hiện tại: " + string.Join(", ", removeResult.Errors.Select(e => e.Description)));
            }

            // Add new role
            var addResult = await userManager.AddToRoleAsync(user, role);
            if (!addResult.Succeeded)
            {
                return BadRequest("Không thể thêm quyền mới: " + string.Join(", ", addResult.Errors.Select(e => e.Description)));
            }

            return Ok("Đã cập nhật quyền cho người dùng " + email + " thành " + role);
        }

        [HttpGet("get-users-in-role")]
        //[Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> GetUsersInRole(string role)
        {
            var usersInRole = await userManager.GetUsersInRoleAsync(role);
            //if (usersInRole == null || !usersInRole.Any())
            //{
            //    return NotFound("Không có người dùng nào có vai trò " + role);
            //}

            return Ok(usersInRole);
        }

        //[HttpPost("get-bac-si")]
        ////[Authorize(Policy = "RequireAdmin")]
        //public async Task<IActionResult> GetBacSis()
        //{
        //    var usersInRole = await userManager.GetUsersInRoleAsync("BacSi");
        //    if (usersInRole == null || !usersInRole.Any())
        //    {
        //        return NotFound("Không có người dùng nào có vai trò BacSi");
        //    }

        //    return Ok(usersInRole);
        //}

    }
}
