using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Models.Dtos;
using Core.Interfaces;
using Api.Helpers;
using Core.Entities;

namespace Api.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class MovementMedicineController : BaseApiController{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _Mapper;
    private readonly ILogger<MovementMedicineController> _Logger;

    public MovementMedicineController (
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<MovementMedicineController> logger
    ){
        _UnitOfWork = unitOfWork;
        _Mapper = mapper;
        _Logger = logger;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get(){
        try{
            var records = await _UnitOfWork.MovementMedicines.GetAllAsync();
            if (records == null){return NotFound();}
            if (!records.Any()){return NoContent();}
            return Ok(_Mapper.Map<List<MovementMedicineDto>>(records));
        }catch (Exception ex){
            _Logger.LogError(ex.Message);
            return StatusCode(500,"Some Wrong");
        }
    }

    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get(int id){
        try{
            var record = await _UnitOfWork.MovementMedicines.GetByIdAsync(id);
            if (record == null){return NotFound();}
            return Ok(_Mapper.Map<MovementMedicineDto>(record));
        }catch (Exception ex){
            _Logger.LogError(ex.Message);
            return StatusCode(500,"Some Wrong");
        }
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get11([FromQuery] Params conf){
        try{
            var param = new Param(conf);
            var records = await _UnitOfWork.MovementMedicines.GetAllAsync();
            if (records == null){return NotFound();}
            if (!records.Any()){return NoContent();}
            var recordDtos = _Mapper.Map<List<MovementMedicineDto>>(records);
            IPager<MovementMedicineDto> pager = new Pager<MovementMedicineDto>(recordDtos,records?.Count(),param) ;
            return Ok(pager);
        }catch (Exception ex){
            _Logger.LogError(ex.Message);
            return StatusCode(500,"Some Wrong");
        }
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> Post(MovementMedicineDto recordDto){
        try{
            if(recordDto == null){return BadRequest();}
            if(_UnitOfWork.MovementMedicines.ItAlreadyExists(recordDto)){
                return Conflict("ya se encuentra registrado");
            }
            var record = _Mapper.Map<MovementMedicine>(recordDto);
            _UnitOfWork.MovementMedicines.Add(record);
            await _UnitOfWork.SaveAsync();
            return Created(nameof(Post),new {id= record.Id, recordDto});
        }catch (Exception ex){
            _Logger.LogError(ex.Message);
            return StatusCode(500,"Some Wrong");
        }

    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator,Manager")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status304NotModified)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<MovementMedicineDto>> Put(int id, [FromBody]MovementMedicineDto? recordDto){
        try{
            if(recordDto == null){return BadRequest();}
            if(_UnitOfWork.MovementMedicines.ItAlreadyExists(recordDto)){
                return Conflict("ya se encuentra registrado");
            }
            var record = _Mapper.Map<MovementMedicine>(recordDto);
            record.Id = id;
            _UnitOfWork.MovementMedicines.Update(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }catch (Exception ex){
            _Logger.LogError(ex.Message);
            return StatusCode(500,"Some Wrong");
        }

    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        try{
            var record = await _UnitOfWork.MovementMedicines.GetByIdAsync(id);
            if(record == null){return NotFound();}
            _UnitOfWork.MovementMedicines.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }catch (Exception ex){
            _Logger.LogError(ex.Message);
            return StatusCode(500,"Some Wrong");
        }

    }

}