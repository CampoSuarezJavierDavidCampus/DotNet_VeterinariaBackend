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
public class MedicalTreatmentController : BaseApiController{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _Mapper;
    private readonly ILogger<MedicalTreatmentController> _Logger;

    public MedicalTreatmentController (
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<MedicalTreatmentController> logger
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
            var records = await _UnitOfWork.MedicalTreatments.GetAllAsync();
            if (records == null){return NotFound();}
            if (!records.Any()){return NoContent();}
            return Ok(_Mapper.Map<List<MedicalTreatmentDto>>(records));
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
            var record = await _UnitOfWork.MedicalTreatments.GetByIdAsync(id);
            if (record == null){return NotFound();}
            return Ok(_Mapper.Map<MedicalTreatmentDto>(record));
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
            var records = await _UnitOfWork.MedicalTreatments.GetAllAsync();
            if (records == null){return NotFound();}
            if (!records.Any()){return NoContent();}
            var recordDtos = _Mapper.Map<List<MedicalTreatmentDto>>(records);
            IPager<MedicalTreatmentDto> pager = new Pager<MedicalTreatmentDto>(recordDtos,records?.Count(),param) ;
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
    public async Task<ActionResult> Post(MedicalTreatmentDto recordDto){
        try{
            if(recordDto == null){return BadRequest();}
            if(_UnitOfWork.MedicalTreatments.ItAlreadyExists(recordDto)){
                return Conflict("ya se encuentra registrado");
            }
            var record = _Mapper.Map<MedicalTreatment>(recordDto);
            _UnitOfWork.MedicalTreatments.Add(record);
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
    public async Task<ActionResult<MedicalTreatmentDto>> Put(int id, [FromBody]MedicalTreatmentDto? recordDto){
        try{
            if(recordDto == null){return BadRequest();}
            if(_UnitOfWork.MedicalTreatments.ItAlreadyExists(recordDto)){
                return Conflict("ya se encuentra registrado");
            }
            var record = _Mapper.Map<MedicalTreatment>(recordDto);
            record.Id = id;
            _UnitOfWork.MedicalTreatments.Update(record);
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
            var record = await _UnitOfWork.MedicalTreatments.GetByIdAsync(id);
            if(record == null){return NotFound();}
            _UnitOfWork.MedicalTreatments.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }catch (Exception ex){
            _Logger.LogError(ex.Message);
            return StatusCode(500,"Some Wrong");
        }

    }

}