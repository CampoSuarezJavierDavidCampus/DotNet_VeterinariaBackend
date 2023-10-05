using Api.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Models.Dtos;
using Core.Interfaces;
using Api.Helpers;
using Core.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiIncidencias.Controllers;
[ApiVersion("1.0")]
public class ProductController : BaseApiController{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _Mapper;
    private readonly ILogger<ProductController> _Logger;

    public ProductController (IUnitOfWork unitOfWork,IMapper mapper,ILogger<ProductController> logger){
        _UnitOfWork = unitOfWork;
        _Mapper = mapper;
        _Logger = logger;
    }

    [HttpGet]    
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Get(){
       try{
            var records = await _UnitOfWork.Products.GetAllAsync();
            if (records == null){return NotFound();}
            if (!records.Any()){return NoContent();}
            return Ok(_Mapper.Map<List<ProductDto>>(records));            
       }catch (Exception ex){
            _Logger.LogError(ex.Message);
            return BadRequest();
       }
    }

    [HttpGet("{id}")]    
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Get(int id){
       try{
            var record = await _UnitOfWork.Products.GetByIdAsync(id);
            if (record == null){return NotFound();}
            return Ok(_Mapper.Map<ProductDto>(record));
       }catch (Exception ex){
            _Logger.LogError(ex.Message);
            return BadRequest();
       }
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Get11([FromQuery] Params conf){
       var param = new Param(conf);
       var records = await _UnitOfWork.Products.GetAllAsync(param);
       var recordDtos = _Mapper.Map<List<ProductDto>>(records);
       IPager<ProductDto> pager = new Pager<ProductDto>(recordDtos,records?.Count(),param) ;
       return Ok(pager);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductDto>> Post(ProductDto recordDto){
       var record = _Mapper.Map<Product>(recordDto);
       _UnitOfWork.Products.Add(record);
       await _UnitOfWork.SaveAsync();
       if (record == null){
           return BadRequest();
       }
       return CreatedAtAction(nameof(Post),new {id= record.Id, recordDto});
    }

    [HttpPut("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductDto>> Put(int id, [FromBody]ProductDto? recordDto){
       if(recordDto == null)
           return NotFound();
       var record = _Mapper.Map<Product>(recordDto);
       record.Id = id;
       _UnitOfWork.Products.Update(record);
       await _UnitOfWork.SaveAsync();
       return recordDto;
    }

    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
       var record = await _UnitOfWork.Products.GetByIdAsync(id);
       if(record == null){
           return NotFound();
       }
       _UnitOfWork.Products.Remove(record);
       await _UnitOfWork.SaveAsync();
       return NoContent();
    }
}