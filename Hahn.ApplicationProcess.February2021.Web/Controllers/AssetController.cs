using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using Hahn.ApplicationProcess.February2021.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
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

            Log.Information($"{DateTime.Now} {"AssetController: "} request for all asset is successful");
            return Ok(new ResponseMessageViewModel { Status = 200, Message = "Successful", Data = result });              
                     
           
        }
        /// <summary>
        /// This method gets specific asset by Id. it takes an id parameter
        /// </summary>
        /// <param name="id"></param>        
        /// <returns>It returns a response message with single asset data</returns>
        // GET api/<AssetController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _asset.FindByIdAsync(id);

            Log.Information($"{DateTime.Now} {"AssetController:GetByIdAsync "} request for specific asset is successful");
             return Ok(new ResponseMessageViewModel { Status = 200, Message = "Successful", Data = result });          
        }

        /// <summary>
        /// This method posts new assets to the db
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/asset
        ///     {
        ///         "Name": "Television",
        ///         "Department": 2,
        ///          "Country": "Germany",
        ///         "Email": "store1@hahn.com",
        ///         "Date": "2021-04-03T09:24:32.647557+01:00",
        ///         "isBroken": false
        ///     }
        /// </remarks>
        /// <returns>a response message with data of asset ID</returns>
        // POST api/<AssetController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]AssetViewModel model)
        {
            //implement fluent validation validation
            if (ModelState.IsValid)
            {
                try
                {
                    await _asset.SaveAsync(model);
                    _logger.LogInformation($"{DateTime.Now} {"AssetController:PostAsync"} asset with name: {model.Name} has been successfully saved");
                    return Ok(new ResponseMessageViewModel { Status = 200, Message = "successfully", Data = model.Name });
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{DateTime.Now} {"AssetController:PostAsync "} an asset with Name: {model.Name} encountered an error while saving. full stacktrace: {ex}");
                    return Ok(new ResponseMessageViewModel { Status = 500, Message = "An error occure while trying to save your request", Data = ex.Message });

                }
            }
            else
            {
                return BadRequest();
            }
         
        }

        /// <summary>
        /// Update method for assets
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/asset/1
        ///     {
        ///         "Name": "PlayStation 5",
        ///         "Department": 3,
        ///        
        ///     }
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="model"></param>
        // PUT api/<AssetController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody]AssetViewModel model)
        {
            if (id >= 1 && ModelState.IsValid)
            {

                try
                {
                    await _asset.UpdateAsync(id,model);
                    _logger.LogInformation($"{DateTime.Now} {"AssetController:PostAsync"} asset with Id: {id} has been successfully updated");
                    return Ok(new ResponseMessageViewModel { Status = 200, Message = "successfully", Data = model.Name });
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{DateTime.Now} {"AssetController:PostAsync "} an asset with Name: {id} encountered an error while updating. full stacktrace: {ex}");
                    return Ok(new ResponseMessageViewModel { Status = 500, Message = "An error occure while trying to save your request", Data = ex.Message });

                }
            }
            else
            {
                return BadRequest();
            }
        
       }

        /// <summary>     
        /// Method to delete an asset
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/<AssetController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id >= 1) {
                try
                {
                    await _asset.DeleteAsync(id);
                    _logger.LogInformation($"{DateTime.Now} {"AssetController:PostAsync"} asset with Id: {id} has been successfully Deleted");
                    return Ok(new ResponseMessageViewModel { Status = 200, Message = "successfully", Data = id });
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{DateTime.Now} {"AssetController:PostAsync "} an asset with Name: {id} encountered an error while deleting. full stacktrace: {ex}");
                    return Ok(new ResponseMessageViewModel { Status = 500, Message = "An error occure while trying to save your request", Data = ex.Message });

                }
            }
            else
            {
                return BadRequest("Not a valid asset id");

            }

          
        }
    }
}
