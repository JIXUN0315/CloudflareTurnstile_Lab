using CloudflareTurnstile_Lab.Models;
using CloudflareTurnstile_Lab.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudflareTurnstile_Lab.Controllers.api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        private readonly CaptchaService _captchaService;
        public ValidateController(CaptchaService captchaService)
        {
            _captchaService = captchaService;
        }

        [HttpPost]
        public IActionResult ValidateTurnstile([FromBody] Token recaptchaToken)
        {
            var userIP = HttpContext.Connection.RemoteIpAddress.ToString();
            // 與 Turnstile 驗證
            var isValid = _captchaService.ValidateTurnstileToken(recaptchaToken.Id, userIP);

            if (isValid)
            {
                // 驗證成功，執行正常的邏輯，例如處理表單提交
                return Content("Form submitted successfully!");
            }
            else
            {
                // 驗證失敗，返回錯誤信息
            }
            return Content("Turnstile token validation failed!");
        }
    }
}
