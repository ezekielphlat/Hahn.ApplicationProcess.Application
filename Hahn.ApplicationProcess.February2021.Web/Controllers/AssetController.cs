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
    /// <summary>
    /// Asset Api: contains method to Get/Post/Put and delete assets
    /// </summary>
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
        /// <summary>
        /// Gets all Assets in db asynchronously
        /// </summary>
        /// <returns>A response message containing the data for all assets</returns>
        // GET: api/<AssetController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _asset.FindAllAsync();

            _logger.LogInformation($"{DateTime.Now} {"AssetController: "} request for all asset is successful");
            return Ok(new ResponseMessageViewModel { Status = 200, Message = "Successful", Data = result });              
                     
           
        }
        /// <summary>
        /// This method gets specific asset by Id. it takes an id parameter
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        ///     Sample Request
        ///     
        ///     {
        ///     "id": 1
        ///     }
        /// </remarks>
        /// <returns>It returns a response message with single asset data</returns>
        // GET api/<AssetController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _asset.FindByIdAsync(id);
         
            _logger.LogInformation($"{DateTime.Now} {"AssetController: "} request for specific asset is successful");
             return Ok(new ResponseMessageViewModel { Status = 200, Message = "Successful", Data = result });          
        }

        /// <summary>
        /// Post Method 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST api/<AssetController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]AssetViewModel model)
        {
            //implement fluent validation validation
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/<AssetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]AssetViewModel model)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/<AssetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
