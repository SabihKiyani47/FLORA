using Azure;
using FloraServices.Data;
using FloraServices.Extensions;
using FloraServices.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static Azure.Core.HttpHeader;

namespace FloraServices.Controllers
{
    [Route("api/saledetails")]
    [ApiController]
    public class SaleDetailAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        public SaleDetailAPIController(AppDbContext db)
        {
            _db = db;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<SaleDetailModel> objList = _db.INV_SaleDetail.ToList();
                if (objList.Count() > 0)
                {
                    _response.Result = objList.ToList();
                    _response.IsSuccess = true;
                    _response.Message = "Success";
                }
                else
                {
                    _response.Result = new List<SaleDetailModel>();
                    _response.IsSuccess = false;
                    _response.Message = "No record Found";
                }
            }
            catch (Exception ex)
            {
                _response.Result = new List<SaleDetailModel>();
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto GetByID(int id)
        {
            try
            {
                SaleDetailModel obj = _db.INV_SaleDetail.First(u => u.SaleDetailID == id);
                if (obj != null)
                {
                    _response.Result = obj;
                    _response.IsSuccess = true;
                    _response.Message = "Success";
                }
                else
                {
                    _response.Result = new SaleDetailModel();
                    _response.IsSuccess = false;
                    _response.Message = "No record Found";
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]

        public ResponseDto Insert([FromBody] SaleDetailModel saleDto)
        {
            try
            {
                _db.INV_SaleDetail.Add(saleDto);
                var result = _db.SaveChanges();
                if (result == 1)
                {
                    _response.Result = saleDto;
                    _response.IsSuccess = true;
                    _response.Message = "Success";
                }
                else
                {
                    _response.Result = new SaleDetailModel();
                    _response.IsSuccess = false;
                    _response.Message = "No record Found";
                }
                return _response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _response.Result = new SaleDetailModel();
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return _response;
            }
        }

        [HttpPut]

        public ResponseDto Update([FromBody] SaleDetailModel saleDto)
        {
            try
            {
                _db.INV_SaleDetail.Update(saleDto);
                var result = _db.SaveChanges();
                if (result == 1)
                {
                    _response.Result = saleDto;
                    _response.IsSuccess = true;
                    _response.Message = "Success";
                }
                else
                {
                    _response.Result = new SaleDetailModel();
                    _response.IsSuccess = false;
                    _response.Message = "No record Found";
                }
                return _response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _response.Result = new SalesModel();
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return _response;
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                var obj = _db.INV_SaleDetail.First(u => u.SaleDetailID == id);
                _db.INV_SaleDetail.Remove(obj);
                var result = _db.SaveChanges();
                if (result == 1)
                {
                    _response.Result = id;
                    _response.IsSuccess = true;
                    _response.Message = "Success";
                }
                else
                {
                    _response.Result = new SaleDetailModel();
                    _response.IsSuccess = false;
                    _response.Message = "No record Found";
                }
                return _response;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpGet]
        [Route("GetSaleDetailsByID/{saleid:int}")]
        public ResponseDto GetSaleDetailsByID(int saleid)
        {
            try
            {
                var obj = _db.INV_SaleDetail.Where(u => u.SaleID == saleid).ToList();
                if (obj != null)
                {
                    _response.Result = obj;
                    _response.IsSuccess = true;
                    _response.Message = "Success";
                }
                else
                {
                    _response.Result = new SaleDetailModel();
                    _response.IsSuccess = false;
                    _response.Message = "No record Found";
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
