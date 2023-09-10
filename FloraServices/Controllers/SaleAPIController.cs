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
    [Route("api/sale")]
    [ApiController]
    public class SaleAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        public SaleAPIController(AppDbContext db)
        {
            _db = db;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<SalesModel> objList = _db.INV_Sale.ToList();
                if (objList.Count() > 0)
                {
                    _response.Result = objList.ToList();
                    _response.IsSuccess = true;
                    _response.Message = "Success";
                }
                else
                {
                    _response.Result = new List<SalesModel>();
                    _response.IsSuccess = false;
                    _response.Message = "No record Found";
                }
            }
            catch (Exception ex)
            {
                _response.Result = new List<SalesModel>();
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
                SalesModel obj = _db.INV_Sale.First(u => u.SaleID == id);
                if (obj != null)
                {
                    _response.Result = obj;
                    _response.IsSuccess = true;
                    _response.Message = "Success";
                }
                else
                {
                    _response.Result = new SalesModel();
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
        
        public ResponseDto Insert([FromBody] SalesModel saleDto)
        {
            try 
            {
                _db.INV_Sale.Add(saleDto);
                 var result =  _db.SaveChanges();
                if(result == 1)
                {
                    _response.Result = saleDto;
                    _response.IsSuccess = true;
                    _response.Message = "Success";
                }
                else
                {
                    _response.Result = new SalesModel();
                    _response.IsSuccess = false;
                    _response.Message = "No record Found";
                }
                return _response;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                _response.Result = new SalesModel();
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return _response;
            }
        }

        [HttpPut]

        public ResponseDto Update([FromBody] SalesModel saleDto)
        {
            try
            {
                _db.INV_Sale.Update(saleDto);
                var result = _db.SaveChanges();
                if (result == 1)
                {
                    _response.Result = saleDto;
                    _response.IsSuccess = true;
                    _response.Message = "Success";
                }
                else
                {
                    _response.Result = new SalesModel();
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
                var obj = _db.INV_Sale.First(u => u.SaleID == id);
                _db.INV_Sale.Remove(obj);
                var result = _db.SaveChanges();
                if (result == 1)
                {
                    _response.Result = id;
                    _response.IsSuccess = true;
                    _response.Message = "Success";
                }
                else
                {
                    _response.Result = new SalesModel();
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
    }
}
