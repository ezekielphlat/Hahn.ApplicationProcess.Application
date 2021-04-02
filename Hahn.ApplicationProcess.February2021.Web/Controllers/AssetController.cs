using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using Hahn.ApplicationProcess.February2021.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hahn.ApplicationProcess.February2021.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {

        private readonly ILogger<AssetController> _logger;
        private readonly IAssetRepository _asset;

        public AssetController(ILogger<AssetController> logger, IAssetRepository asset)
        {
            _logger = logger;
            _asset = asset;
        }
        // GET: api/<AssetController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _asset.FindAllAsync();

            _logger.LogInformation($"{DateTime.Now} {"AssetController: "} request for all asset is successful");
            return Ok(new ResponseMessageViewModel { Status = 200, Message = "Successful", Data = result });              
                     
           
        }

        // GET api/<AssetController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var result = await _asset.FindByIdAsync(Id);
         
            _logger.LogInformation($"{DateTime.Now} {"AssetController: "} request for specific asset is successful");
             return Ok(new ResponseMessageViewModel { Status = 200, Message = "Successful", Data = result });          
        }

        // POST api/<AssetController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]AssetViewModel model)
        {
            //implement fluent validation validation
            return Ok();
        }

        // PUT api/<AssetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AssetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
