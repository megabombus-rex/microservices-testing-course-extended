using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using ShoppingProject.Coupon.API.Interfaces;
using ShoppingProject.Coupon.API.Models.Dtos;

namespace ShoppingProject.Coupon.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet("all")]
        public IActionResult GetAllCoupons()
        {
            try
            {
                var result = _couponService.GetCoupons();
                var response = new ResponseDto(result, true, "");
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseDto(null, false, ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet("{Id:guid}")]
        public IActionResult GetCoupon([FromRoute] Guid id)
        {
            try
            {
                var result = _couponService.GetById(id);
                var response = new ResponseDto(result, true, "");
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseDto(null, false, ex.Message);
                return BadRequest(response);
            }
        }
    }
}
