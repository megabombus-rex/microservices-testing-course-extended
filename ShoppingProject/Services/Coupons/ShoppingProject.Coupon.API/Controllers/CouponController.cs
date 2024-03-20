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
        private readonly ILogger<CouponController> _logger;

        public CouponController(ICouponService couponService, ILogger<CouponController> logger)
        {
            _couponService = couponService;
            _logger = logger;
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
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(ex.Message);
                }
                var response = new ResponseDto(null, false, ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet("{id:guid}")]
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
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(ex.Message);
                }
                var response = new ResponseDto(null, false, ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPut("archive/{id:guid}")]
        public IActionResult ArchiveCoupon([FromRoute] Guid id)
        {
            try
            {
                _couponService.ArchiveCoupon(id);
                return Ok(new ResponseDto(null, true, string.Format("Coupon with id {0} has been archived.", id)));
            }
            catch (Exception ex)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(ex.Message);
                }
                var response = new ResponseDto(null, false, ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPut("restore/{id:guid}")]
        public IActionResult RestoreCoupon([FromRoute] Guid id)
        {
            try
            {
                _couponService.RestoreCoupon(id);
                return Ok(new ResponseDto(null, true, string.Format("Coupon with id {0} has been restored.", id)));
            }
            catch (Exception ex)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(ex.Message);
                }
                var response = new ResponseDto(null, false, ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPost("add")]
        public IActionResult CreateCoupon([FromBody] CreateUpdateCouponDto dto)
        {
            try
            {
                var guid = _couponService.CreateCoupon(dto);
                return Ok(new ResponseDto(guid, true, string.Format("Coupon with id {0} has been created.", guid)));
            }
            catch (Exception ex)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(ex.Message);
                }
                var response = new ResponseDto(null, false, ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPut("update/{id:guid}")]
        public IActionResult UpdateCoupon([FromRoute] Guid id, [FromBody] CreateUpdateCouponDto dto)
        {
            try
            {
                _couponService.UpdateCoupon(id, dto);
                return Ok(new ResponseDto(id, true, string.Format("Coupon with id {0} has been updated.", id)));
            }
            catch (Exception ex)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(ex.Message);
                }
                var response = new ResponseDto(null, false, ex.Message);
                return BadRequest(response);
            }
        }
    }
}
