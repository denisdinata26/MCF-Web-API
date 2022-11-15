using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("v1")]
    [ApiController]
    public class TransaksiBpkbController : ControllerBase
    {
        private readonly MCFContext _dbContext;
        public TransaksiBpkbController(MCFContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("inputproses")]
        public IActionResult InsertTransaksiBpkb(tr_bpkb data) 
        {
           data.Insert(_dbContext); 
           return Ok(new { status = true, type = "success", message = "Transaksi berhasil" });
        }

        [HttpGet("getdata")]
        public IActionResult getdata() 
        {
          try
          {
             var data = _dbContext.ms_storage_location?.ToList(); 
             return Ok(new { status = true, type = "success",data = data,message = "Transaksi berhasil" });
          }
          catch (System.Exception e)
          {   
            throw e;
          }          
           
        }

    }
}